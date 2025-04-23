# LacunaRecipes API

A simple recipe management API built with ASP.NET Core in Visual Studio 2022. It uses Entity Framework Core for data access and SQL Server 2022 as the database. Swagger is integrated for interactive API documentation.

- Manage **Ingredients** and **Recipes**
- Associate ingredients with recipes (many-to-many relationship)
- CRUD endpoints for all entities
- Auto-generated Swagger UI for easy exploration

## Technologies & Packages

- **Framework:** .NET 8 / ASP.NET Core
- **IDE:** Visual Studio 2022
- **ORM:** Entity Framework Core 9.0.4
  - `Microsoft.EntityFrameworkCore`
  - `Microsoft.EntityFrameworkCore.SqlServer`
  - `Microsoft.EntityFrameworkCore.Tools`
- **API Docs:** Swashbuckle.AspNetCore 6.6.2
- **Database:** SQL Server 2022

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) with ASP.NET and web development workload
- SQL Server 2022 instance

## Getting Started

1. **Configure the connection string** in the User Secrets or `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SQL_SERVER;Database=LacunaRecipes;Trusted_Connection=True;"
   }
   ```

2. **Restore packages & build**
   ```bash
   dotnet build
   ```

3. **Apply migrations** (Package Manager Console)
   ```bash
   Update-Database
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```
   Particularly for this project, the ISS Express was used
   The API will be available at `https://localhost:44345` by default.

## Swagger UI

Once the application is running, navigate to:

```
https://localhost:44345/swagger/index.html
```

Here you can explore and test all available endpoints, check you localhost.

## Data Model

### Ingredient

| Property | Type   | Description                           |
|----------|--------|---------------------------------------|
| `Id`     | GUID   | Primary key                           |
| `Name`   | string | Name of the ingredient (required)     |
| `Unit`   | string | Unit of measurement (required)        |

### Recipe

| Property             | Type   | Description                         |
|----------------------|--------|-------------------------------------|
| `Id`                 | GUID   | Primary key                         |
| `Title`              | string | Title of the recipe (required)      |
| `PreparationMethod`  | string | Preparation steps (required)        |

### RecipeAndIngredient (Join Table)

| Property       | Type   | Description                                             |
|----------------|--------|---------------------------------------------------------|
| `Id`                 | GUID   | Primary key                                       |
| `RecipeId`     | GUID   | FK to Recipe                                            |
| `IngredientId` | GUID   | FK to Ingredient                                        |
| `Quantity`     | string | Quantity for this ingredient in the recipe (required)   |


## Sample SQL Seed Data

Use the following SQL script to insert initial data:

```sql
-- Ingredients
INSERT INTO Ingredients (Id, Name, Unit) VALUES
('11111111-1111-1111-1111-111111111111', 'Flour', 'grams'),
('22222222-2222-2222-2222-222222222222', 'Sugar', 'grams'),
('33333333-3333-3333-3333-333333333333', 'Eggs', 'units'),
('44444444-4444-4444-4444-444444444444', 'Milk', 'ml'),
('55555555-5555-5555-5555-555555555555', 'Butter', 'grams');

-- Recipes
INSERT INTO Recipes (Id, Title, PreparationMethod) VALUES
('aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa', 'Pancakes', 'Mix all ingredients and cook on a skillet.'),
('bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb', 'Cake', 'Mix, bake at 180°C for 40 minutes.');

-- RecipeAndIngredients
INSERT INTO RecipeAndIngredients (Id, RecipeId, IngredientId, Quantity) VALUES
('a1a1a1a1-a1a1-a1a1-a1a1-a1a1a1a1a1a1', 'aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa', '11111111-1111-1111-1111-111111111111', '200'),
('a2a2a2a2-a2a2-a2a2-a2a2-a2a2a2a2a2a2', 'aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa', '22222222-2222-2222-2222-222222222222', '50'),
('a3a3a3a3-a3a3-a3a3-a3a3-a3a3a3a3a3a3', 'aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa', '33333333-3333-3333-3333-333333333333', '2'),
('a4a4a4a4-a4a4-a4a4-a4a4-a4a4a4a4a4a4', 'aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa', '44444444-4444-4444-4444-444444444444', '250'),

('b1b1b1b1-b1b1-b1b1-b1b1-b1b1b1b1b1b1', 'bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb', '11111111-1111-1111-1111-111111111111', '300'),
('b2b2b2b2-b2b2-b2b2-b2b2-b2b2b2b2b2b2', 'bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb', '22222222-2222-2222-2222-222222222222', '150'),
('b3b3b3b3-b3b3-b3b3-b3b3-b3b3b3b3b3b3', 'bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb', '33333333-3333-3333-3333-333333333333', '3'),
('b4b4b4b4-b4b4-b4b4-b4b4-b4b4b4b4b4b4', 'bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb', '55555555-5555-5555-5555-555555555555', '100');
```
## License
No License
