# Product Service API

A .NET 10 ASP.NET Core Web API for reading and creating product records. Product data is persisted in SQL Server through Entity Framework Core, and API access is protected with Microsoft Entra ID bearer-token authentication.

## Features

- List products and retrieve a product by its integer ID.
- Create a product using its SKU, name, description, category, and brand.
- Store product records in the `prd.Products` SQL Server table.
- Expose Swagger/OpenAPI documentation in the Development environment.

## Technology

- .NET 10 / ASP.NET Core
- Entity Framework Core 10 with SQL Server
- Microsoft.Identity.Web and JWT bearer authentication
- Swashbuckle (Swagger)

## API

All routes are under `/api/products` and require a valid bearer token.

| Method | Route | Description |
| --- | --- | --- |
| `GET` | `/api/products` | Return all products. |
| `GET` | `/api/products/{id}` | Return the product with the specified integer ID. |
| `POST` | `/api/products` | Create a product. |

### Create a product

Request body:

```json
{
  "sku": "SKU-1001",
  "name": "Sample product",
  "description": "Product description",
  "category": "Accessories",
  "brand": "Example"
}
```

The service currently initializes inventory-related and pricing fields (`QuantityOnHand`, `ReorderLevel`, `UnitCost`, and `UnitPrice`) to `1`, generates a `RowVersion`, and sets `CreatedAt` to UTC. Other fields use their model defaults unless populated by the application.

Example request:

```http
POST /api/products HTTP/1.1
Host: localhost:5297
Authorization: Bearer <access-token>
Content-Type: application/json

{
  "sku": "SKU-1001",
  "name": "Sample product",
  "description": "Product description",
  "category": "Accessories",
  "brand": "Example"
}
```

## Requirements

- .NET 10 SDK
- SQL Server
- Microsoft Entra ID app registration/configuration for issuing API access tokens

## Configuration

The application expects a `DefaultConnection` connection string and an `AzureAd` configuration section. Neither is included in the checked-in `appsettings.json`; configure them using .NET User Secrets, environment variables, or a secure deployment configuration. Do not commit database credentials or identity secrets.

For local development, from the project directory:

```powershell
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "<SQL Server connection string>"
dotnet user-secrets set "AzureAd:Instance" "https://login.microsoftonline.com/"
dotnet user-secrets set "AzureAd:TenantId" "<tenant-id>"
dotnet user-secrets set "AzureAd:ClientId" "<api-application-client-id>"
```

Configure any additional identity settings required by your Entra ID registration and Microsoft.Identity.Web setup. Configure the client application to request an access token intended for this API.

## Run locally

1. Configure the connection string and AzureAd settings as described above.
2. Apply the EF Core migrations to the configured database:

   ```powershell
   dotnet ef database update
   ```

   If `dotnet ef` is not installed, install the EF Core command-line tool first.
3. Start the API:

   ```powershell
   dotnet run
   ```

The checked-in launch profiles use `http://localhost:5297` and `https://localhost:7003`. In Development, Swagger UI is available at `/swagger`.

## Project structure

- `Controllers/` — HTTP endpoints and request handling.
- `DTOs/` — API request types.
- `Data/` — EF Core database context.
- `Models/` — Product entity.
- `Repositories/` — Product persistence operations.
- `Services/` — Product business/application logic.
- `Migrations/` — EF Core database migrations.

## Authentication pipeline note

The controller is marked with `[Authorize]`, and the application registers JWT bearer authentication. Ensure the middleware pipeline calls `app.UseAuthentication()` before `app.UseAuthorization()`; without it, bearer tokens are not authenticated for protected endpoints.
