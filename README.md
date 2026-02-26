# Product Selling App

An interactive product selling website built with ASP.NET Core MVC.

## Features
- Home page
- Product listing
- Product details
- Shopping cart (session-based)

## Getting Started
1. Install .NET 7 SDK: https://dotnet.microsoft.com/download
2. Clone the repository.
3. Navigate to the project folder.
4. Run `dotnet restore` to install dependencies.
5. Run `dotnet run` to start the application.
6. Open https://localhost:5001 in your browser.

## Project Structure
- Data: Entity Framework Core DbContext and seed data.
- Models: Product and CartItem models.
- Services: Business logic for products and cart management.
- Controllers: MVC controllers.
- Views: Razor views (UI).
- wwwroot: Static files (CSS, images).
