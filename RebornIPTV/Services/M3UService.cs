using System;
using System.Collections.Generic;
using System.IO; // Dosya işlemleri için
using RebornIPTV.Models;

namespace RebornIPTV.Services
{
    public class M3uService
    {
        // Bu metot dosya yolunu (path) alır, sana temiz bir Kanal Listesi verir.
        public async Task<List<Channel>> ParseM3uFile(string filePath)
        {
            List<Channel> channels = new List<Channel>();

            // HATA KONTROLÜ: Dosya var mı?
            if (!File.Exists(filePath))
            {
                // Hata fırlatmak yerine boş liste dönmek daha güvenlidir.
                return channels;
            }

            // Dosyanın tüm satırlarını string dizisi olarak oku
            string[] lines = await File.ReadAllLinesAsync(filePath);

            Channel tempChannel = null; // Geçici hafıza

            foreach (string line in lines)
            {
                // Boş satırları atla
                if (string.IsNullOrWhiteSpace(line)) continue;

                if (line.StartsWith("#EXTINF"))
                {
                    tempChannel = new Channel();

                    // 1. İSİM PARSE ETME (Virgülden sonrası)
                    int commaIndex = line.IndexOf(',');
                    if (commaIndex != -1)
                    {
                        // Virgülden sonraki her şeyi al ve boşlukları temizle
                        tempChannel.Name = line.Substring(commaIndex + 1).Trim();
                    }
                    else
                    {
                        tempChannel.Name = "İsimsiz Kanal";
                    }

                    // 2. GRUP PARSE ETME (group-title="...")
                    // Her satırda grup olmayabilir, kontrol şart!
                    if (line.Contains("group-title=\""))
                    {
                        try
                        {
                            // Basit string bölme taktiği
                            string[] parts = line.Split(new string[] { "group-title=\"" }, StringSplitOptions.None);
                            // parts[1] şununla başlar: Spor",TRT 1...
                            // Şimdi ilk tırnağa kadar olanı alacağız.
                            string afterGroupTitle = parts[1];
                            tempChannel.Group = afterGroupTitle.Split('"')[0];
                        }
                        catch
                        {
                            tempChannel.Group = "Genel"; // Hata olursa varsayılan grup ata
                        }
                    }
                    else
                    {
                        tempChannel.Group = "Genel";
                    }
                }
                else if (line.StartsWith("http") && tempChannel != null)
                {
                    tempChannel.StreamUrl = line.Trim();
                    channels.Add(tempChannel);
                    tempChannel = null; // Sıfırla
                }
            }

            return channels;
        }
    }
}