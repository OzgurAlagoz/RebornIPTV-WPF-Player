# Reborn IPTV Player 📺

*[Read in Turkish / Türkçe Oku](#reborn-iptv-player--türkçe)*

Reborn IPTV Player is a modern, fast, and asynchronous desktop application developed using C# and WPF. It features a clean MVVM architecture and integrates the powerful VLC engine for smooth video playback.


<img width="1918" height="1036" alt="image" src="https://github.com/user-attachments/assets/e96db502-e63c-43a8-910f-7f16557d7ffd" />

## 🚀 Key Features

* **MVVM Architecture:** Clean separation of concerns (Model-View-ViewModel) for maintainable code.
* **VLC Engine Integration:** Uses `LibVLCSharp` for high-performance, stutter-free video playback.
* **Asynchronous I/O:** Implements `Async/Await` patterns to ensure the UI never freezes while loading large M3U files.
* **Smart Search:** Real-time, case-insensitive channel filtering and searching.
* **M3U Support:** Automatically parses standard `.m3u` and `.m3u8` playlist files.
* **Robust Error Handling:** Safe file parsing and null checks to prevent crashes.

## 🛠️ Tech Stack

* **Language:** C# (.NET 10.0)
* **Framework:** WPF (Windows Presentation Foundation)
* **Video Engine:** LibVLCSharp
* **Pattern:** MVVM (Model-View-ViewModel)
* **IDE:** Visual Studio 2022

## 📦 How to Run

1.  Clone the repository:
    ```bash
    git clone [https://github.com/OzgurAlagoz/RebornIPTV-WPF-Player.git](https://github.com/OzgurAlagoz/RebornIPTV-WPF-Player.git)
    ```
2.  Open the solution file (`RebornIPTV.sln`) in Visual Studio.
3.  Restore NuGet packages (Right-click solution -> Restore NuGet Packages).
4.  Build and Run (F5).
5.  Click **"OPEN FILE"** (DOSYA AÇ) and select your `.m3u` playlist.

---

# Reborn IPTV Player 📺 (Türkçe)

Reborn IPTV Player, C# ve WPF kullanılarak geliştirilmiş modern, hızlı ve asenkron çalışan bir masaüstü IPTV oynatıcısıdır. Temiz bir MVVM mimarisine sahiptir ve kesintisiz video oynatımı için güçlü VLC motorunu kullanır.

## 🚀 Özellikler

* **MVVM Mimarisi:** Sürdürülebilir ve temiz kod yapısı (Model-View-ViewModel).
* **VLC Motoru Entegrasyonu:** `LibVLCSharp` kütüphanesi ile donmadan, yüksek performanslı video oynatma.
* **Asenkron Yapı:** Büyük M3U dosyalarını yüklerken arayüzün donmasını engelleyen `Async/Await` yapısı.
* **Akıllı Arama:** Anlık (Real-time), büyük/küçük harf duyarsız kanal filtreleme.
* **M3U Desteği:** Standart `.m3u` ve `.m3u8` listelerini otomatik olarak ayrıştırır (parse eder).
* **Güçlü Hata Yönetimi:** Çökmeleri önleyen güvenli dosya okuma ve null kontrolleri.

## 🛠️ Kullanılan Teknolojiler

* **Dil:** C# (.NET 10.0)
* **Arayüz:** WPF (Windows Presentation Foundation)
* **Video Motoru:** LibVLCSharp
* **Tasarım Deseni:** MVVM
* **Geliştirme Ortamı:** Visual Studio 2022

## 📦 Kurulum ve Çalıştırma

1.  Projeyi klonlayın:
    ```bash
    git clone [https://github.com/OzgurAlagoz/RebornIPTV-WPF-Player.git](https://github.com/OzgurAlagoz/RebornIPTV-WPF-Player.git)
    ```
2.  `RebornIPTV.sln` dosyasını Visual Studio ile açın.
3.  NuGet paketlerini geri yükleyin (Solution'a sağ tık -> Restore NuGet Packages).
4.  Derleyin ve Başlatın (F5).
5.  **"DOSYA AÇ"** butonuna tıklayın ve `.m3u` listenizi seçin.

---

## 👨‍💻 Developer / Geliştirici

Developed by Özgür Alagöz.
