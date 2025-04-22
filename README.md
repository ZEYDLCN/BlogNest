# BlogNest 📝

**BlogNest** is a multi-layered ASP.NET Core Web API project designed for creating, managing, and viewing blog posts. It implements a clean, layered architecture adhering to modern software development principles and best practices for scalability and maintainability.

---

## ✨ Core Features & Technology Stack

This project leverages a range of technologies and patterns to deliver a robust backend system:

* **Backend Framework:** ASP.NET Core 6+ (Cross-platform, high-performance framework)
* **Architecture:** N-Tier Layered Architecture (Entities, Repositories, Services, Presentation)
* **Data Access:**
    * Entity Framework Core (ORM for database interactions)
    * Repository Pattern (Abstracts data access logic)
    * SQL Server (Relational Database)
* **API Development:**
    * ASP.NET Core MVC (Building Web APIs)
    * RESTful Principles
    * Swagger/OpenAPI (API documentation and testing UI)
    * API Versioning (Manages different versions of the API)
    * Data Shaping (Allows clients to specify desired response fields)
* **Business Logic & Validation:**
    * Service Layer (Encapsulates business rules)
    * FluentValidation (Declarative input validation)
    * AutoMapper (Object-to-object mapping, e.g., Entities to DTOs)
* **Security:**
    * ASP.NET Core Identity (User management, authentication, roles)
    * JWT (JSON Web Tokens) Bearer Authentication (Stateless authentication mechanism)
    * Role-Based Authorization
* **Performance & Resilience:**
    * In-Memory Caching (Improves response time for frequently accessed data)
    * Rate Limiting (Protects the API from abuse)
* **Cross-Cutting Concerns:**
    * Custom Exception Handling Middleware
    * Dependency Injection (Built-in)

---

## 📁 Project Architecture

The solution follows a standard N-Tier layered architecture to promote separation of concerns:

1.  **Entities (.Domain / .Entities)**
    * Contains Plain Old CLR Objects (POCOs) representing core domain entities.
    * Includes Data Transfer Objects (DTOs) for API interactions.
    * Defines custom exceptions specific to the application domain.
2.  **Repositories (.Infrastructure / .Persistence / .Repositories)**
    * Handles data access logic using Entity Framework Core.
    * Implements the Repository pattern to abstract persistence details from the service layer.
    * Contains the `DbContext` and EF Core configurations/migrations.
3.  **Services (.Application / .Core / .Services)**
    * Orchestrates business logic and application workflows.
    * Uses repository interfaces for data access.
    * Performs validation (using FluentValidation) and mapping (using AutoMapper).
    * Acts as a mediator between the Presentation layer and the Repositories.
4.  **Presentation (.API / .Web)**
    * Exposes the application's functionality via RESTful API endpoints using ASP.NET Core Controllers.
    * Handles HTTP requests and responses.
    * Manages API versioning, routing, and model binding.
    * Integrates authentication and authorization filters.
5.  **BlogNest (Host Project / Entry Point)**
    * The main executable project containing `Program.cs` and `Startup.cs` (or minimal API setup in .NET 6+).
    * Configures services, middleware pipeline, logging, and application settings (`appsettings.json`).
    * Acts as the composition root for dependency injection.

---

## 🚀 Getting Started

### Prerequisites

* .NET 6 SDK (or newer)
* SQL Server Instance (LocalDB, Express, Developer Edition, etc.)
* An IDE or Code Editor (e.g., Visual Studio 2022, JetBrains Rider, VS Code)
* Git

### Installation & Setup

1.  **Clone the Repository:**
    ```bash
    git clone [https://github.com/your-username/BlogNest.git](https://github.com/your-username/BlogNest.git) # Replace with actual URL
    cd BlogNest
    ```

2.  **Restore Dependencies:**
    Navigate to the solution directory (`.sln` file location) or the main project directory and run:
    ```bash
    dotnet restore
    ```

3.  **Configure Database Connection:**
    Open the `appsettings.Development.json` (or `appsettings.json`) file located in the main Host project (likely named `BlogNest` or `BlogNest.API`). Update the `ConnectionStrings` section with your SQL Server connection details.
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BlogNestDb;Trusted_Connection=True;MultipleActiveResultSets=true"
        // Or your specific connection string:
        // "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=BlogNestDb;User ID=YOUR_USER;Password=YOUR_PASSWORD;"
      },
      // ... other settings
    }
    ```

4.  **Apply Database Migrations:**
    Ensure you have the `dotnet-ef` tool installed (`dotnet tool install --global dotnet-ef`). Navigate to the project containing the `DbContext` (usually the Repositories/Infrastructure layer) or specify the startup project, and run:
    ```bash
    # Ensure you are in the directory with the .sln file or specify the startup project
    # Example: Assuming migrations are in the 'Repositories' project and 'BlogNest' is the startup project
    dotnet ef database update --project ./Repositories --startup-project ./BlogNest
    # If DbContext is in the startup project, it might be simpler:
    # dotnet ef database update
    ```
    This command will create the database (if it doesn't exist) and apply all pending migrations based on the EF Core configurations.

5.  **Run the Application:**
    Navigate to the main Host project directory (`BlogNest` or `BlogNest.API`) and run:
    ```bash
    dotnet run
    ```
    The API will typically start on `https://localhost:7202` or `http://localhost:5202` (check the console output or `launchSettings.json`).

---

##  TAPI Documentation & Testing

### Swagger UI

Once the application is running, access the interactive Swagger UI documentation in your browser. The default URL is usually:
[https://localhost:7202/swagger](https://localhost:7202/swagger) (Adjust port if necessary)

Swagger allows you to explore API endpoints, view request/response models, and execute requests directly.

### Authentication Flow

Most endpoints require authentication. Follow these steps:

1.  **Register a User:**
    * **Endpoint:** `POST /api/authentication/register`
    * **Request Body:** Provide user details (firstName, lastName, username, password, email, roles etc.) as specified in the Swagger documentation for this endpoint.
    * **Example:**
        ```json
        {
          "firstName": "Test",
          "lastName": "User",
          "username": "testuser",
          "password": "Password123!",
          "email": "test.user@example.com",
          "roles": ["User"]
        }
        ```

2.  **Login:**
    * **Endpoint:** `POST /api/authentication/login`
    * **Request Body:** Provide the registered `username` and `password`.
    * **Example:**
        ```json
        {
          "username": "testuser",
          "password": "Password123!"
        }
        ```
    * **Response:** A successful login returns a JWT Bearer token.

3.  **Using the JWT Token:**
    * Copy the `token` value received from the login response.
    * For accessing protected endpoints (e.g., creating a post `POST /api/posts`), include the token in the `Authorization` header of your HTTP requests:
        ```http
        Authorization: Bearer <PASTE_YOUR_TOKEN_HERE>
        ```
    * In Swagger UI, click the "Authorize" button and paste the token (including the `Bearer ` prefix if not automatically added) into the value field.

---

## 🏗️ Build & Run Summary

```bash
# Clone the repository (if not done)
git clone [https://github.com/your-username/BlogNest.git](https://github.com/your-username/BlogNest.git)
cd BlogNest

# Restore .NET dependencies
dotnet restore

# Configure appsettings.Development.json (Manual Step)

# Apply EF Core Migrations (adjust project paths if needed)
dotnet ef database update --project ./Repositories --startup-project ./BlogNest

# Run the application (from the Host project directory)
cd ./BlogNest
dotnet run
