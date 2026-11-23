# Cat & Fish Adventure - Android Educational & AR Game

Aplikasi game edukasi berbasis Android yang menggabungkan dua mode permainan interaktif—**Augmented Reality (AR) Game** dan **Memory Card Game** untuk melatih daya ingat, konsentrasi, dan pengenalan pola pengguna. Dikembangkan menggunakan **Unity Engine** dan bahasa pemrograman **C#**.

## 📲 Unduh Aplikasi (Android APK)
* **File Instalasi (.apk):** [Unduh Cat & Fish Adventure v1.0.0 di GitHub Releases](https://github.com)

## Fitur Utama
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

## 📸 Tampilan Aplikasi (UI & Gameplay)
<p align="center">
  <img width="200" alt="Splash Screen" src="https://github.com/user-attachments/assets/c2e98aa7-ca6f-40cb-9d63-9fbbbfba3381" />
  <img width="200" alt="Main Menu" src="https://github.com/user-attachments/assets/c617fe64-fabc-4627-a688-93fb92f093a9" />
  <img width="200" alt="Menu AR" src="https://github.com/user-attachments/assets/cc7b0f7e-32fe-4085-b9fe-540c9c492756" />
  <img width="200" alt="Gameplay AR" src="https://github.com/user-attachments/assets/30be5d2a-a8d8-42ca-bb57-578d74c30802" />
  <img width="200" alt="Menu Memory Card" src="https://github.com/user-attachments/assets/460cf848-3586-44e8-bc64-96d209b52cbd" />
  <img width="200" alt="Gameplay Easy" src="https://github.com/user-attachments/assets/1a12430b-496d-4206-9ebb-4aeb9902e8ba" />
  <img width="200" alt="Gameplay Medium" src="https://github.com/user-attachments/assets/6c3b7a61-65c2-404c-bfa0-40c6161d41ac" />
  <img width="200" alt="Gameplay Hard" src="https://github.com/user-attachments/assets/58c190a8-5931-4117-a138-70e177031d45" />
  <img width="200" alt="How to Play" src="https://github.com/user-attachments/assets/18befd70-3750-4af2-a75a-2a14099756f3" />
  <img width="200" alt="About Game" src="https://github.com/user-attachments/assets/e4ef363a-21ef-4e77-85f0-318a3f397678" />
  <img width="200" alt="Settings" src="https://github.com/user-attachments/assets/ef4048b0-4c1e-4986-959a-270acffc1554" />
</p>

## 📂 Struktur Repositori
* `Assets/Scripts` — Logika permainan C# (kontrol karakter AR, pengacakan kartu, sistem skor, timer, dan manajemen UI).
* `Assets/Scenes` — Susunan *scene* aplikasi (*Splash Screen*, *Main Menu*, *AR Mode*, dan *Memory Card Mode*).
* `Assets/Prefabs` — Komponen objek 3D dan kartu permainan siap pakai.
* `Assets/UI` — Tata letak antarmuka pengguna yang responsif untuk berbagai ukuran layar Android.
* `Packages` & `ProjectSettings` — Konfigurasi dependensi dan pengaturan *build* Android.
