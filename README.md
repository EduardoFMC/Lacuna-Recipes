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
  ('a1111111-1111-1111-1111-111111111111', 'Flour', 'grams'),
  ('b2222222-2222-2222-2222-222222222222', 'Sugar', 'grams'),
  ('c3333333-3333-3333-3333-333333333333', 'Eggs', 'pieces');

-- Recipes
INSERT INTO Recipes (Id, Title, PreparationMethod) VALUES
  ('d4444444-4444-4444-4444-444444444444', 'Pancakes', 'Mix ingredients and fry.'),
  ('e5555555-5555-5555-5555-555555555555', 'Chocolate Cake', 'Combine batter and bake at 180°C.');

-- Recipe-Ingredient Links
INSERT INTO RecipeAndIngredients (RecipeId, IngredientId, Quantity) VALUES
  ('d4444444-4444-4444-4444-444444444444', 'a1111111-1111-1111-1111-111111111111', '200', '00000000-0000-0000-0000-000000000001'),
  ('d4444444-4444-4444-4444-444444444444', 'b2222222-2222-2222-2222-222222222222', '50', '00000000-0000-0000-0000-000000000002'),
  ('d4444444-4444-4444-4444-444444444444', 'c3333333-3333-3333-3333-333333333333', '2', '00000000-0000-0000-0000-000000000003'),
  ('e5555555-5555-5555-5555-555555555555', 'a1111111-1111-1111-1111-111111111111', '250', '00000000-0000-0000-0000-000000000004'),
  ('e5555555-5555-5555-5555-555555555555', 'b2222222-2222-2222-2222-222222222222', '100', '00000000-0000-0000-0000-000000000005'),
  ('e5555555-5555-5555-5555-555555555555', 'c3333333-3333-3333-3333-333333333333', '3', '00000000-0000-0000-0000-000000000006');
```
## License
No License
