# Cat & Fish Adventure — Android Educational & AR Game

Aplikasi game edukasi berbasis Android yang menggabungkan dua mode permainan interaktif—**Augmented Reality (AR) Game** dan **Memory Card Game**—untuk melatih daya ingat, konsentrasi, dan pengenalan pola pengguna. Dikembangkan menggunakan **Unity Engine** dan bahasa pemrograman **C#**.

## 📲 Unduh Aplikasi (Android APK)
* **File Instalasi (.apk):** [Unduh Cat & Fish Adventure v1.0.0 di GitHub Releases](https://github.com)

## ✨ Fitur Utama
* **Mode Augmented Reality (AR) Game:** Memanfaatkan kamera perangkat Android untuk memindai *marker* dan memunculkan karakter 3D kucing serta ikan secara *real-time*. Pemain mengendalikan karakter kucing untuk menangkap ikan dan mengumpulkan skor tertinggi.
* **Mode Memory Card Game:** Permainan mencocokkan pasangan kartu bergambar dengan sistem pengacakan posisi kartu dan penghitung waktu (*timer*). Tersedia dalam tiga tingkat kesulitan:
  * **Easy:** 12 kartu
  * **Medium:** 20 kartu
  * **Hard:** 30 kartu
* **Navigasi & Pengaturan Lengkap:** Dilengkapi halaman *Splash Screen*, *Main Menu*, *How to Play* (panduan bermain), *About*, serta *Settings* untuk mengatur volume musik latar dan efek suara secara terpisah.

## 🛠️ Teknologi & Arsitektur
* **Game Engine:** Unity
* **Bahasa Pemrograman:** C#
* **Platform Target:** Android (`.apk`)
* **Teknologi Inti:** Marker-based Augmented Reality, 3D Object Interaction, UI Responsive Layout, dan Black Box Testing.

## 📸 Marker AR & Tampilan Aplikasi
*(Catatan: Unggah gambar marker AR dan screenshot dari Gambar 4 laporanmu ke folder `docs/` di GitHub, lalu tampilkan di sini agar rekruter bisa langsung memindai marker-nya saat mencoba APK!)*

## 📂 Struktur Repositori
* `Assets/Scripts` — Logika permainan C# (kontrol karakter AR, pengacakan kartu, sistem skor, timer, dan manajemen UI).
* `Assets/Scenes` — Susunan *scene* aplikasi (*Splash Screen*, *Main Menu*, *AR Mode*, dan *Memory Card Mode*).
* `Assets/Prefabs` — Komponen objek 3D dan kartu permainan siap pakai.
* `Assets/UI` — Tata letak antarmuka pengguna yang responsif untuk berbagai ukuran layar Android.
* `Packages` & `ProjectSettings` — Konfigurasi dependensi dan pengaturan *build* Android.
