<div align="center">

  <img src="https://media.giphy.com/media/M9gbBd9nbDrOTu1Mqx/giphy.gif" width="100" />

  <h1>🥯 BageryProject - Modern Bakery Automation Solution</h1>

  <p>
    <strong>.NET Core 8.0 | Clean Architecture | CQRS | Design Patterns</strong>
  </p>

  <p>
    <a href="https://github.com/muhammedgazi/bageryproject">
      <img src="https://img.shields.io/badge/Version-1.0.0-blue?style=for-the-badge&logo=none" alt="Version">
    </a>
    <a href="https://github.com/muhammedgazi/bageryproject/graphs/contributors">
      <img src="https://img.shields.io/github/contributors/muhammedgazi/bageryproject?style=for-the-badge&color=orange" alt="Contributors">
    </a>
    <a href="https://github.com/muhammedgazi/bageryproject/issues">
      <img src="https://img.shields.io/github/issues/muhammedgazi/bageryproject?style=for-the-badge&color=red" alt="Issues">
    </a>
    <a href="https://github.com/muhammedgazi/bageryproject/blob/master/LICENSE">
      <img src="https://img.shields.io/github/license/muhammedgazi/bageryproject?style=for-the-badge&color=green" alt="License">
    </a>
  </p>

  <h4>
    <a href="#-proje-hakkında">Proje Hakkında</a> •
    <a href="#-teknolojiler">Teknolojiler</a> •
    <a href="#-mimari-ve-tasarım">Mimari</a> •
    <a href="#-kurulum">Kurulum</a> •
    <a href="#-proje-galerisi">Galeri</a>
  </h4>
</div>

<br />

---

### 🚀 Proje Hakkında

**BageryProject**, modern yazılım geliştirme prensipleri kullanılarak tasarlanmış, uçtan uca bir fırın/pastane e-ticaret ve yönetim sistemidir. 

Bu proje sadece bir web sitesi değil, aynı zamanda **Sürdürülebilir (Maintainable)** ve **Ölçeklenebilir (Scalable)** kod yapısının bir örneğidir. Geleneksel katmanlı mimari yerine, bağımlılıkların içe doğru olduğu **Onion Architecture (Clean Architecture)** yapısı benimsenmiştir.

### 🛠 Teknolojiler ve Araçlar

Projede kullanılan teknoloji yığını ve kütüphaneler aşağıda görselleştirilmiştir:

<div align="center">
  <img src="https://skillicons.dev/icons?i=cs,dotnet,visualstudio" />
  <br/>
  <img src="https://skillicons.dev/icons?i=postgres,mssql,docker,git,github" />
  <br/>
  <img src="https://skillicons.dev/icons?i=html,css,js,bootstrap,jquery" />
</div>

| Kategori | Teknolojiler |
| --- | --- |
| **Backend** | .NET Core 8.0, C# 12 |
| **Mimari** | Clean Architecture (Onion), CQRS Pattern |
| **Veri Erişimi** | Entity Framework Core (Code First), LINQ |
| **Patternler** | Mediator, Repository, Unit of Work, Observer |
| **Medya Yönetimi** | Cloudinary API |
| **Frontend** | ASP.NET Core MVC, Razor Views, Bootstrap 5 |

---

### 🏗 Mimari ve Tasarım Desenleri

Proje 4 ana katmandan oluşmaktadır. Bu yapı sayesinde veritabanı nesneleri ile arayüz nesneleri birbirinden tamamen izole edilmiştir.

🧩 Uygulanan Tasarım Desenleri (Design Patterns)
CQRS (Command Query Responsibility Segregation):

Okuma (Query) ve Yazma (Command) işlemleri Features klasörü altında ayrıştırılmıştır.

Bu sayede performans optimizasyonu ve kod okunabilirliği artırılmıştır.

Mediator Pattern (MediatR):

Controller ile Service katmanı arasındaki bağımlılık ortadan kaldırılmıştır.

Request'ler Handler'lar aracılığıyla işlenir.

Observer Pattern:

Sistem içerisindeki önemli olaylar (Sipariş oluşturma vb.) NotificationObserver yapısı ile dinlenir ve ilgili aksiyonlar tetiklenir.

AOP (Aspect Oriented Programming):

LoggingBehavior ile metodların içine kod yazmadan, pipeline üzerinde loglama işlemleri merkezi olarak yönetilir.

### 📸 Proje Galerisi
Projenin Admin paneli ve Kullanıcı arayüzünden görseller.
<div align="center">
<img width="1909" height="1073" alt="Image" src="https://github.com/user-attachments/assets/58ca7aef-3453-4394-bb38-60ae54623130" />
<img width="1894" height="1065" alt="Image" src="https://github.com/user-attachments/assets/3c046980-f99e-477a-9080-bd56cd46db65" />
<img width="1893" height="1067" alt="Image" src="https://github.com/user-attachments/assets/77d1023f-507a-4ed7-bdee-e3ac6b09e032" />
<img width="1895" height="1075" alt="Image" src="https://github.com/user-attachments/assets/e72da9c6-6ee0-44c0-a6c4-963d2120755f" />
<img width="1887" height="1065" alt="Image" src="https://github.com/user-attachments/assets/e340577e-e403-4087-acef-8ffa72ec7a4a" />
<img width="1893" height="1067" alt="Image" src="https://github.com/user-attachments/assets/e069490c-21f6-4ba4-8130-94c43981d3d8" />
<img width="1882" height="1055" alt="Image" src="https://github.com/user-attachments/assets/94dad208-b5ba-4721-addf-3525d35254af" />
<img width="1905" height="1066" alt="Image" src="https://github.com/user-attachments/assets/9f238ae8-4514-4751-b3f2-d5e808cfc36b" />
<img width="1900" height="1069" alt="Image" src="https://github.com/user-attachments/assets/ec6e643c-0476-467d-976f-4beb014a8582" />
<img width="1907" height="1070" alt="Image" src="https://github.com/user-attachments/assets/3ca833b2-53ad-4ead-895c-9fa36fcf99be" />
<img width="1895" height="1067" alt="Image" src="https://github.com/user-attachments/assets/7576e2af-2276-4bc6-a4e0-84ce402e3504" />
<img width="1884" height="1061" alt="Image" src="https://github.com/user-attachments/assets/f93d7746-6fab-4b48-8d2f-56fcb546b4b1" />
<img width="1899" height="1065" alt="Image" src="https://github.com/user-attachments/assets/91afb431-62d7-4de4-96c8-1b1c4d2df0e9" />
<img width="1904" height="1066" alt="Image" src="https://github.com/user-attachments/assets/b19bb053-4c2a-46c2-9ee0-696b509e3806" />
<img width="1899" height="1066" alt="Image" src="https://github.com/user-attachments/assets/7ea2d827-155a-4a55-9b0d-c4424a77b95c" />
<img width="1906" height="1066" alt="Image" src="https://github.com/user-attachments/assets/7b4c8928-82f2-4573-848e-312adf65a5a8" />
<img width="1906" height="1075" alt="Image" src="https://github.com/user-attachments/assets/e3037377-4b6d-4b6f-b6da-8498d068bf87" />
<img width="1919" height="957" alt="Image" src="https://github.com/user-attachments/assets/3c7d1719-c591-4322-b680-6347cd4e61e7" />

</div>

BageryProject
├── 📂 Bagery.Core          # Varlıklar (Entities), Arayüzler ve DTO'lar
├── 📂 Bagery.DataAccess    # Veritabanı Bağlantıları, Migrations ve Repository Uygulamaları
├── 📂 Bagery.Business      # CQRS Handler'ları, Validasyonlar ve İş Mantığı
└── 📂 Bagery.WebUI         # MVC Controller'lar, View'lar ve Area Yapısı (Admin/User)
