# Asset Management System

A comprehensive asset management system built with ASP.NET Core Web API that helps organizations track, manage, and maintain their assets efficiently.

## Features

- **Asset Management**
  - Track asset details (name, serial number, warranty information)
  - Categorize assets
  - Monitor asset status (active/inactive)
  - Warranty tracking with start and end dates

- **Category Management**
  - Create and manage asset categories
  - Track category details (name, kilogram, created by)
  - Active/inactive status tracking

- **User Management**
  - User authentication and authorization
  - Role-based access control
  - User profile management

- **Maintainer Management**
  - Track maintainer details (name, email, phone, city)
  - Active/inactive status tracking
  - Maintainer contact information

- **Supplier Management**
  - Track supplier details (name, email, phone)
  - Active/inactive status tracking
  - Supplier contact information

## API Endpoints

### Assets
- `GET /api/asset` - Get all assets (with pagination)
- `GET /api/asset/{id}` - Get asset by ID
- `POST /api/asset` - Create new asset
- `PUT /api/asset/{id}` - Update asset
- `DELETE /api/asset/{id}` - Delete asset

### Categories
- `GET /api/categories` - Get all categories (with pagination)
- `GET /api/categories/{id}` - Get category by ID
- `POST /api/categories` - Create new category
- `PUT /api/categories/{id}` - Update category
- `DELETE /api/categories/{id}` - Delete category

### Users
- `GET /api/users` - Get all users (with pagination)
- `GET /api/users/{id}` - Get user by ID
- `POST /api/users` - Create new user
- `PUT /api/users/{id}` - Update user
- `DELETE /api/users/{id}` - Delete user

### Maintainers
- `GET /api/maintainer` - Get all maintainers (with pagination)
- `GET /api/maintainer/{id}` - Get maintainer by ID
- `POST /api/maintainer` - Create new maintainer
- `PUT /api/maintainer/{id}` - Update maintainer
- `DELETE /api/maintainer/{id}` - Delete maintainer

### Suppliers
- `GET /api/supplier` - Get all suppliers (with pagination)
- `GET /api/supplier/{id}` - Get supplier by ID
- `POST /api/supplier` - Create new supplier
- `PUT /api/supplier/{id}` - Update supplier
- `DELETE /api/supplier/{id}` - Delete supplier

## Search and Pagination

All list endpoints support:
- Pagination with customizable page size
- Search by various fields
- Sorting options
- Response headers for pagination info:
  - X-Total-Count
  - X-Total-Pages
  - X-Current-Page
  - X-Page-Size

## Technologies Used

- ASP.NET Core 8.0
- Entity Framework Core
- SQL Server
- AutoMapper
- Swagger/OpenAPI
- CORS enabled

## Getting Started

1. Clone the repository
2. Update the connection string in `appsettings.json`
3. Run the following commands:
   ```bash
   dotnet restore
   dotnet ef database update
   dotnet run
   ```

## Database Migrations

To create a new migration:
```bash
dotnet ef migrations add MigrationName
```

To update the database:
```bash
dotnet ef database update
```

## API Documentation

The API documentation is available through Swagger UI when running the application:
- Development: `https://localhost:5001/swagger`
- Production: `https://your-domain/swagger`

## Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## License

This project is licensed under the MIT License - see the LICENSE file for details. 