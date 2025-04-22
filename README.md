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

## 🧪 Nasıl Test Edilir / How to Test

### 👤 Kullanıcı Kaydı / Register User

**Endpoint:**  
`POST https://localhost:7202/api/authentication/register`  

**Headers:**  
`Content-Type: application/json`

**Request Body:**
```json
{
  "firstName": "zeyd",
  "lastName": "alcan",
  "username": "zeydovic",
  "password": "zeyd1907",
  "email": "zeydalcan00@gmail.com",
  "phonenumber": "5414559156",
  "roles": ["User"]
}

