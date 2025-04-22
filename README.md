# BlogNest 📝

**BlogNest** is a multi-layer ASP.NET Core project where users can create, update, and view blog posts. It features a robust architecture with modern development practices.

## 🔧 Technologies Used

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

## 📁 Project Structure

- **Entities**: Models, DTOs, and custom exceptions  
- **Repositories**: Data access operations (with EF Core)  
- **Services**: Business logic layer  
- **Presentation**: API layer (Controllers, Filters)  
- **BlogNest**: Entry points (Program.cs, appsettings.json)

## ✨ Getting Started

### Prerequisites
- .NET 6+ SDK
- SQL Server
- IDE (Visual Studio, VS Code, etc.)

### Installation

1. Clone the repository:
```bash
git clone https://github.com/kullanici-adi/BlogNest.git



### ▶️ Uygulamayı Çalıştırma / Run the Application
Uygulamayı başlatmak için aşağıdaki komutu kullanın:
Use the following command to start the application:

```bash

dotnet run
Uygulama varsayılan olarak https://localhost:7202 adresinde çalışacaktır (veya yapılandırmanıza göre farklı bir port).
The application will run by default at https://localhost:7202 (or a different port based on your configuration).
