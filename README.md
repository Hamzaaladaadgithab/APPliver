
# AR-Karaciğer: Karaciğer Nakli Hastaları İçin Mobil Artırılmış Gerçeklik Eğitim Sistemi

Bu proje, karaciğer nakli operasyonu geçirmiş hastaların taburculuk sonrası adaptasyon süreçlerini desteklemek,
ilaç uyumlarını maksimize etmek ve olası komplikasyonları erken safhada tespit edebilmelerini sağlamak amacıyla tasarlanmış,
interaktif bir **Mobil Artırılmış Gerçeklik (AR)** eğitim sistemidir. 


Geleneksel broşür ve sözlü bilgilendirme yöntemlerinin yetersiz kaldığı noktalarda, hastaların soyut tıbbi kavramları somutlaştırarak öğrenmesini sağlayan bu sistem; Unity 2022 oyun motoru,
Vuforia Engine AR SDK'sı ve veri yönetimi için Firebase altyapısı kullanılarak hayata geçirilmektedir.



##  Temel Özellikler
* **Etkileşimli 3B Karaciğer Modeli:** Hasta kararlarına göre anlık görsel tepki veren (renk değişimi: sağlıklı/hasarlı) dinamik organ simülasyonu.
* **Klinik Karar Senaryoları:** İlaç yönetimi ve komplikasyon belirtilerine yönelik, uzman onaylı çoktan seçmeli karar ağaçları.
* **Gerçek Zamanlı Veri Senkronizasyonu:** Firebase entegrasyonu ile hastaların senaryo bazlı performanslarının ve oturum loglarının (Session Logs) anlık olarak buluta aktarılması.
* **Yönetici (Admin) Paneli:** Doktorların ve sağlık profesyonellerinin, hastaların gelişim süreçlerini, skorlarını ve yaptıkları hataları takip edebileceği özel yetkilendirilmiş arayüz.



## 📌 Sistem Tasarımı ve İşleyiş Mimarisi
Kullanıcıların karaciğer anatomisini ve klinik hasta senaryolarını uygulamalı olarak deneyimlemelerine olanak tanıyan sistemin genel akış diyagramı,
projenin temel hedefleri ve teknolojik altyapısı aşağıda sunulmuştur.

<img width="1365" height="751" alt="sistem mimarisi " src="https://github.com/user-attachments/assets/51aa80e6-5943-492e-b942-660128949f64" />




##  Katmanlı Sistem Mimarisi
Uygulama, sürdürülebilirlik ve bağımsızlık ilkeleri gereği üç ana bileşenin entegre çalıştığı modüler bir mimari (N-Tier Architecture) üzerine inşa edilmiştir:
1. **Sunum Katmanı (UI Katmanı):** Kullanıcı arayüzleri, menüler ve istatistik ekranları.
2. **İş Mantığı ve AR Katmanı (Senaryo Motoru):** Vuforia Engine ile görüntü işleme, marker tanıma ve 3B obje etkileşimlerinin yönetildiği alan.
3. **Veri Katmanı (Backend):** Firebase Authentication ile güvenli kimlik doğrulama ve Cloud Firestore (NoSQL) ile JSON tabanlı senaryo/log yönetimi.

<img width="1536" height="1024" alt="sistemtasarımı" src="https://github.com/user-attachments/assets/16752b35-141c-4965-8579-07d9e81bd985" />






## 🛠️ Kullanılan Teknolojiler
* **Oyun Motoru & Ortam:** Unity 2022.3 LTS
* **Programlama Dili:** C# (Nesne Yönelimli Programlama)
* **AR Altyapısı:** Vuforia Engine SDK
* **Backend & Veritabanı:** Firebase Auth, Cloud Firestore
* **Versiyon Kontrol:** Git & GitHub

## 🛡️ Güvenilirlik ve Sürdürülebilirlik (RAMS İlkeleri)
Projenin yazılım altyapısı, mühendislik standartlarına tam uyumlu olarak; sistemin hatasız çalışmasını ifade eden **Güvenilirlik (Reliability)**, 
çevrimdışı mod destekli **Erişilebilirlik (Availability)**, modüler kod yapısıyla **Bakım Yapılabilirlik (Maintainability)** ve hastayı yanlış yönlendirmeyen **Emniyet (Safety)** ilkeleri ekseninde projelendirilmiştir.

<img width="1254" height="1254" alt="RAMS" src="https://github.com/user-attachments/assets/4989296f-8169-44dc-9072-15ff1f03094b" />





## 📊 Stratejik Değerlendirme: SWOT Analizi

1.	•  Güçlü Yönler: Unity ve C# bilgisi, AR deneyimi, Etkileşimli yapı 
2.	•  Zayıf Yönler: 3D model bağımlılığı, Tek geliştirici, Zaman kısıtı 
3.	•  Fırsatlar: AR eğitim uygulamalarının artması, Sağlık teknolojisi yenilikleri 
4.	•  Tehditler: Cihaz uyumsuzluğu, Performans sorunları, Kamera farkları

<img width="1254" height="1254" alt="SOWTanalizi" src="https://github.com/user-attachments/assets/48515348-69e3-4418-aa38-efdb37621658" />




---
**Geliştirici:** Hamza Aladaad (Backend Developer / Fırat Üniversitesi Yazılım Mühendisliği)








[KARACİĞER_NAKLİ_HASTASI_MOBİL_AR_EĞİTİM_SİSTEMİ.docx](https://github.com/user-attachments/files/27486239/KARACIGER_NAKLI_HASTASI_MOBIL_AR_EGITIM_SISTEMI.docx)
