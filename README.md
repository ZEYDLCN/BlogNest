# BlogNest 📝

**BlogNest**, kullanıcıların blog gönderileri oluşturabileceği, güncelleyebileceği ve görüntüleyebileceği çok katmanlı bir **ASP.NET Core** projesidir.  
**BlogNest** is a multi-layer ASP.NET Core project where users can create, update, and view blog posts.

---

## 🔧 Kullanılan Teknolojiler / Technologies Used

- ASP.NET Core MVC  
- Entity Framework Core  
- SQL Server  
- AutoMapper  
- FluentValidation  
- Swagger (API Documentation)  
- Repository Pattern  
- API Versioning  
- Caching (Memory Cache)  
- Rate Limiting  
- Data Shaping  
- JWT Authentication  
- Identity (User Management & Roles)

---

## 📁 Proje Yapısı / Project Structure

- **Entities**: Modeller, DTO'lar ve özel istisnalar  
- **Repositories**: Veri erişim işlemleri (EF Core ile)  
- **Services**: İş mantığı katmanı (Business Layer)  
- **Presentation**: API katmanı (Controllers, Filters)  
- **BlogNest**: Başlangıç noktaları (Program.cs, appsettings.json)

---

## ✨ Kurulum / Getting Started

🔽 Bu repoyu klonlayın / Clone this repo:

```bash
git clone https://github.com/kullanici-adi/BlogNest.git
📦 Gerekli NuGet paketlerini yükleyin / Restore dependencies:

bash
Kopyala
Düzenle
dotnet restore
🛠️ Veritabanı bağlantısını yapılandırın / Configure your DB connection:
appsettings.json dosyasındaki ConnectionStrings alanını düzenleyin.

🗄️ Migration ve veritabanı oluşturma işlemini gerçekleştirin / Apply migrations:

bash
Kopyala
Düzenle
dotnet ef database update
▶️ Uygulamayı başlatın / Run the application:

bash
Kopyala
Düzenle
dotnet run
🌐 Swagger arayüzü ile test edin / Use Swagger UI:
Göz at / Visit

🧪 Nasıl Test Edilir / How to Test
👤 Kullanıcı Kaydı / Register User
Endpoint:
POST https://localhost:7202/api/authentication/register

Headers:
Content-Type: application/json

Request Body:

json
Kopyala
Düzenle
{
  "firstName": "zeyd",
  "lastName": "alcan",
  "username": "zeydovic",
  "password": "zeyd1907",
  "email": "zeydalcan00@gmail.com",
  "phonenumber": "5414559156",
  "roles": ["User"]
}
🔐 Giriş Yap / Login
Endpoint:
POST https://localhost:7202/api/authentication/login

Headers:
Content-Type: application/json

Request Body:

json
Kopyala
Düzenle
{
  "username": "zeydovic",
  "password": "zeyd1907"
}
✅ Token Kullanımı / Using the JWT Token
Dönen JWT Token'ı kopyalayın

Test edeceğiniz endpoint'in Authorization header'ına şu şekilde ekleyin:

http
Kopyala
Düzenle
Authorization: Bearer <token>
Artık yetkili endpoint'leri test edebilirsiniz.
Örneğin: Blog gönderisi oluşturma (POST /api/posts)

🛠️ Derleme ve Çalıştırma / Build & Run
bash
Kopyala
Düzenle
dotnet restore
dotnet build
dotnet ef database update
dotnet run
🌍 Tarayıcıdan Swagger UI üzerinden veya Postman ile endpoint'ler test edilebilir:
https://localhost:7202/swagger

🛡️ Güvenlik / Security
Kimlik doğrulama ve yetkilendirme için JWT Token yapısı kullanılmıştır

Kullanıcı yönetimi ASP.NET Core Identity ile sağlanır

API Rate Limiting ve Caching ile performans ve güvenlik iyileştirmeleri yapılmıştır

Role tabanlı erişim kontrolleri mevcuttur

👨‍💻 Geliştirici / Developer
Zeyd Alcan
GitHub Profilim

Her türlü geri bildirime açığım. ⭐ Repo hoşuna gittiyse yıldızlamayı unutma!

css
Kopyala
Düzenle
