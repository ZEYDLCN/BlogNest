# BlogNest Documentation

![BlogNest Banner](https://via.placeholder.com/1200x400?text=BlogNest+ASP.NET+Core+Project)

## Table of Contents
1. [Project Overview](#project-overview)
2. [Technical Specifications](#technical-specifications)
3. [System Architecture](#system-architecture)
4. [API Documentation](#api-documentation)
5. [Authentication Flow](#authentication-flow)
6. [Database Schema](#database-schema)
7. [Installation Guide](#installation-guide)
8. [Testing Guide](#testing-guide)
9. [Deployment](#deployment)
10. [Troubleshooting](#troubleshooting)
11. [Contributing](#contributing)

---

## Project Overview

### English
BlogNest is a multi-layer ASP.NET Core blog platform featuring:
- User authentication with JWT
- Role-based authorization
- CRUD operations for blog posts
- Advanced API features (caching, rate limiting)
- Clean architecture implementation

### Türkçe
BlogNest, çok katmanlı bir ASP.NET Core blog platformudur:
- JWT ile kullanıcı kimlik doğrulama
- Rol tabanlı yetkilendirme
- Blog gönderileri için CRUD işlemleri
- Gelişmiş API özellikleri (önbellekleme, istek sınırlama)
- Temiz mimari uygulaması

---

## Technical Specifications

### Backend
```plaintext
- ASP.NET Core 7.0
- Entity Framework Core 7.0
- SQL Server 2022
- AutoMapper 12.0
- FluentValidation 11.0
- Swashbuckle (Swagger) 6.5.0
