# PixelMarketPlace

**PixelMarketPlace** — A compact ASP.NET Core MVC game store demo built with **.NET 10**, Entity Framework Core, Bootstrap UI, seeded demo data, and unit tests.

---

## Overview

**PixelMarketPlace** demonstrates a full end‑to‑end workflow for managing video game records. The app includes browsing, searching, creating, editing, and deleting game entries. It ships with EF Core migrations and seeded demo data so the app works out of the box, and it includes unit tests that run against an in‑memory database.

This repository is ideal as a portfolio piece to show practical knowledge of ASP.NET Core MVC, EF Core, and automated testing.

---

## Features

- Full **CRUD** for `Game` entities (Create, Read, Update, Delete)  
- **Search** by title or author from Home and Index pages  
- **Seeded demo data** so the app shows content immediately after applying migrations  
- **Server and client validation** using data annotations and unobtrusive validation  
- **EF Core migrations** included for schema versioning and easy setup  
- **Unit tests** for controllers and model behavior (xUnit, in‑memory provider)  
- **Responsive UI** built with Bootstrap (Index, Create, Edit, Details, Delete, Home, Privacy)

---

## Tech Stack

- **.NET 10** (ASP.NET Core MVC)  
- **Entity Framework Core** (SQL Server by default)  
- **xUnit** for unit tests  
- **Bootstrap** for responsive UI  
- **In‑memory EF provider** for fast unit tests

---

## Getting Started

### Prerequisites

- **.NET 10 SDK** installed  
- **SQL Server** or **LocalDB** available (or change provider in `Program.cs`)  
- Optional: **EF Core Tools**  
```bash
dotnet tool install --global dotnet-ef
```
## Clone the repository
```bash
git clone https://github.com/MIhajloS07/PixelMarketPlace.git
cd PixelMarketPlace
```
## Configure database connection

Open `appsettings.json` and update the `ConnectionStrings:GameStoreContext` value to match your SQL Server instance. Example:

    "ConnectionStrings": {
      "GameStoreContext": "Server=.\\SQLEXPRESS;Database=PixelMarketPlaceDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
    }

**Notes**

- For local development you can use LocalDB or SQL Express.
- For CI or production, prefer environment variables or a secrets manager instead of committing credentials.

---

## Apply migrations and seed data

The repository includes EF Core migrations and seed data defined in `GameStoreContext.OnModelCreating`. To create the database and apply migrations, run:

    dotnet restore
    dotnet ef database update

If you modify the model or seed data later, create and apply a new migration:

    dotnet ef migrations add <MigrationName>
    dotnet ef database update

If you need to reset the database during development:

    dotnet ef database drop
    dotnet ef database update

---

## Run the application

    dotnet run

Open the URL shown in the console (typically `https://localhost:5001`) and navigate the app. Use the **Games** section to browse seeded games, create new entries, edit, or delete.

---

## Running Tests

Run all unit tests with:

    dotnet test

Tests use an in‑memory EF Core provider so they run quickly and do not require a live database.

---

---

## Seed Data Note

Seed data is defined in `GameStoreContext.OnModelCreating`. The included seed entries (example titles) are inserted when you run `dotnet ef database update`. If you change seed data or model annotations, add a new migration to keep the model snapshot in sync:

    dotnet ef migrations add <MigrationName>
    dotnet ef database update

---

## Architecture

<img width="1080" height="421" alt="image" src="https://github.com/user-attachments/assets/30834cca-c37f-4ffe-8757-705aa0db74bb" />

*MVC architecture — request flow: Browser → Routing/Middleware → Controller → Service → Repository → DbContext → SQL Server Database.*

*Screenshot: Diagram created by Mihajlo.*

## Database

<img width="421" height="204" alt="image" src="https://github.com/user-attachments/assets/a4e54fae-89da-41d9-adb9-6ced5c4954c5" />

*Example: Query results from the GameStore development database showing seeded game records (Id, Title, Author, Price, releaseDate).*


## Project structure
```
/PixelMarketPlace
├─ /Controllers        # GamesController, HomeController
├─ /Models             # Game model with data annotations, view models
├─ /Data               # GameStoreContext (DbContext), seed data, migrations
├─ /Views              # Razor views (Home, Games: Index/Create/Edit/Details/Delete), Shared
├─ /wwwroot            # Static files (css, js, images)
├─ /Migrations         # EF Core migration files and model snapshot
├─ /Tests              # xUnit tests (controllers, services, model validation)
├─ Properties          # launchSettings.json
├─ Program.cs
├─ Startup.cs (if present)
├─ appsettings.json
├─ appsettings.Development.json
├─ README.md
├─ LICENSE
└─ .gitignore
```

## Screenshots


<img width="1907" height="901" alt="image" src="https://github.com/user-attachments/assets/46bea185-87d2-4ab0-8d05-357c07764b5f" />

<img width="1862" height="890" alt="image" src="https://github.com/user-attachments/assets/37257aac-39ff-44b0-bff5-b137d859ada9" />

<img width="1894" height="903" alt="image" src="https://github.com/user-attachments/assets/f272a339-74e4-494b-9940-092d2b33fed2" />

<img width="1892" height="889" alt="image" src="https://github.com/user-attachments/assets/c50492ff-0dec-45c1-ae88-9ca505530a2b" />

<img width="1892" height="899" alt="image" src="https://github.com/user-attachments/assets/2a1ea138-90af-423e-93d3-2786c5bdeef3" />


---

## Contributing

- Pull requests are welcome. For major changes, open an issue first to discuss the change.
- Keep secrets out of the repo. Use environment variables or User Secrets for local development.
- Follow the existing code style and add tests for new features.

---

## License

This project is licensed under the **MIT License**.
<br>
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
