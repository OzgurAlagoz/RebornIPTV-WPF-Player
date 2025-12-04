using System.Collections.ObjectModel;
using System.ComponentModel; // INotifyPropertyChanged için
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Win32;
using LibVLCSharp.Shared; // VLC Kütüphanesi
using RebornIPTV.Models;
using RebornIPTV.Services;

namespace RebornIPTV.ViewModels
{
    // INotifyPropertyChanged: Arayüze "Benim değerim değişti, kendini güncelle" diyen arayüzdür.
    public class MainViewModel : INotifyPropertyChanged
    {
        // VLC Oynatıcı Nesneleri
        private LibVLC _libVLC;
        public MediaPlayer MediaPlayer { get; private set; }

        private List<Channel> _allChannels;
        private string _searchText;
        public string SearchText { 
            get => _searchText;
            set 
            {
                _searchText = value;
                OnPropertyChanged();

                Channels.Clear();
                if (String.IsNullOrEmpty(value))
                {
                    foreach (var channel in _allChannels)
                    {
                        Channels.Add(channel);
                    }
                }
                else
                {
                    string text = value.Trim();
                    var channels = _allChannels
                        .FindAll(x => x.Name.Contains(text, StringComparison.OrdinalIgnoreCase));

                    foreach (var channel in channels)
                    {
                        Channels.Add(channel);
                    }
                        
                }
            } 
        }
        public ObservableCollection<Channel> Channels { get; set; }

        // Seçili Kanalı Tutan Değişken
        private Channel _selectedChannel;
        public ICommand OpenFileCommand { get; }
        public ICommand StopCommand { get; }
        public Channel SelectedChannel
        {
            get => _selectedChannel;
            set
            {
                // Eğer seçilen kanal aynıysa işlem yapma
                if (_selectedChannel == value) return;

                _selectedChannel = value;

                // Seçim değiştiği an videoyu oynat!
                PlayChannel(value);

                // Arayüze haber ver: "Seçili kanal değişti!"
                OnPropertyChanged();
            }
        }

        private M3uService _m3uService;

        public MainViewModel()
        {
            // 1. VLC Kurulumu
            _libVLC = new LibVLC();
            MediaPlayer = new MediaPlayer(_libVLC);

            // 2. Kanal Listesi Hazırlığı
            Channels = new ObservableCollection<Channel>();
            _allChannels = new List<Channel>();
            _m3uService = new M3uService();

            // ... Eski kodlar (VLC, Channels vs.) burada kalsın ...

            // Komutları Tanımla:
            // "Butona basılınca OpenFile metodunu çalıştır"
            OpenFileCommand = new RelayCommand(OpenFile);

            // "Butona basılınca videoyu durdur"
            StopCommand = new RelayCommand(() => MediaPlayer.Stop());

        }

        private void PlayChannel(Channel channel)
        {
            if (channel == null) return;
            if (string.IsNullOrEmpty(channel.StreamUrl)) return;

            // Medyayı internetten oluştur
            using (var media = new Media(_libVLC, channel.StreamUrl, FromType.FromLocation))
            {
                MediaPlayer.Play(media);
            }
        }

        private async void OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "M3U Playlist (*.m3u;*.m3u8)|*.m3u;*.m3u8"; // Sadece M3U dosyaları

            if (openFileDialog.ShowDialog() == true)
            {
                // 1. Dosya yolunu al
                string filePath = openFileDialog.FileName;

                // 2. Senin yazdığın servisi kullan
                var newChannels = await _m3uService.ParseM3uFile(filePath);

                // 3. Mevcut listeyi temizle
                Channels.Clear();
                _allChannels.Clear();

                // 4. Yeni kanalları ekle
                foreach (var channel in newChannels)
                {
                    Channels.Add(channel);
                    _allChannels.Add(channel);
                }
            }
        }

        // --- MVVM Altyapısı (Standart Kod) ---
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
}