# 🏢 Asset Management System

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4)](https://dotnet.microsoft.com/download/dotnet/8.0)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![Build Status](https://img.shields.io/badge/Build-Passing-brightgreen)](https://github.com/yourusername/AssetManagementSystem)
[![API Documentation](https://img.shields.io/badge/API-Documentation-blue)](https://your-domain/swagger)

<div align="center">
  <img src="https://via.placeholder.com/800x400?text=Asset+Management+System" alt="Asset Management System Banner" width="800"/>
</div>

## 📋 Overview

A robust and scalable asset management system built with ASP.NET Core Web API. This system provides comprehensive tools for organizations to track, manage, and maintain their assets efficiently.

## ✨ Key Features

### 📦 Asset Management
- **Asset Tracking**
  - Detailed asset information (name, serial number)
  - Warranty management with start/end dates
  - Status monitoring (active/inactive)
  - Category-based organization

### 📑 Category Management
- **Category Organization**
  - Hierarchical category structure
  - Weight tracking (kilogram)
  - Creation tracking
  - Status management

### 👥 User Management
- **User Administration**
  - Secure authentication
  - Role-based access control
  - Profile management
  - Activity tracking

### 🔧 Maintainer Management
- **Maintenance Tracking**
  - Contact information management
  - Location tracking
  - Status monitoring
  - Service history

### 🏭 Supplier Management
- **Vendor Management**
  - Supplier profiles
  - Contact details
  - Status tracking
  - Performance monitoring

## 🔌 API Endpoints

### Assets API
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/asset` | Retrieve all assets (paginated) |
| GET | `/api/asset/{id}` | Get specific asset |
| POST | `/api/asset` | Create new asset |
| PUT | `/api/asset/{id}` | Update asset |
| DELETE | `/api/asset/{id}` | Remove asset |

### Categories API
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/categories` | List all categories |
| GET | `/api/categories/{id}` | Get category details |
| POST | `/api/categories` | Create category |
| PUT | `/api/categories/{id}` | Update category |
| DELETE | `/api/categories/{id}` | Delete category |

### Users API
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/users` | List all users |
| GET | `/api/users/{id}` | Get user details |
| POST | `/api/users` | Create user |
| PUT | `/api/users/{id}` | Update user |
| DELETE | `/api/users/{id}` | Delete user |

### Maintainers API
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/maintainer` | List all maintainers |
| GET | `/api/maintainer/{id}` | Get maintainer details |
| POST | `/api/maintainer` | Create maintainer |
| PUT | `/api/maintainer/{id}` | Update maintainer |
| DELETE | `/api/maintainer/{id}` | Delete maintainer |

### Suppliers API
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/supplier` | List all suppliers |
| GET | `/api/supplier/{id}` | Get supplier details |
| POST | `/api/supplier` | Create supplier |
| PUT | `/api/supplier/{id}` | Update supplier |
| DELETE | `/api/supplier/{id}` | Delete supplier |

## 🔍 Search and Pagination

### Pagination Features
- Customizable page size
- Page navigation
- Total count tracking
- Current page indicator

### Search Capabilities
- Multi-field search
- Filter by status
- Sort by various fields
- Advanced filtering options

### Response Headers
```
X-Total-Count: Total number of items
X-Total-Pages: Total number of pages
X-Current-Page: Current page number
X-Page-Size: Items per page
```

## 🛠️ Technology Stack

- **Backend Framework**: ASP.NET Core 8.0
- **Database**: SQL Server
- **ORM**: Entity Framework Core
- **API Documentation**: Swagger/OpenAPI
- **Object Mapping**: AutoMapper
- **Cross-Origin**: CORS enabled
- **Version Control**: Git

## 🚀 Getting Started

### Prerequisites
- .NET 8.0 SDK
- SQL Server
- Visual Studio 2022 or VS Code

### Installation Steps
1. Clone the repository
   ```bash
   git clone https://github.com/yourusername/AssetManagementSystem.git
   ```

2. Configure the database
   - Update connection string in `appsettings.json`
   - Run database migrations

3. Build and run
   ```bash
   dotnet restore
   dotnet ef database update
   dotnet run
   ```

## 📦 Database Management

### Creating Migrations
```bash
dotnet ef migrations add MigrationName
```

### Updating Database
```bash
dotnet ef database update
```

## 📚 API Documentation

Access the interactive API documentation:
- **Development**: `https://localhost:5001/swagger`
- **Production**: `https://your-domain/swagger`

## 🤝 Contributing

We welcome contributions! Please follow these steps:

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

### Code Style
- Follow C# coding conventions
- Write meaningful commit messages
- Include unit tests for new features

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 📞 Support

For support, email support@yourdomain.com or create an issue in the repository.

---

<div align="center">
  <sub>Built with ❤️ by Your Name</sub>
</div> 