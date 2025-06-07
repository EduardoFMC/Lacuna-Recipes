using LacunaRecipes.Entities;
using LacunaRecipes.Models;
using Microsoft.EntityFrameworkCore;

namespace LacunaRecipes.Business.Repositories;

public class RecipeRepository : IRecipeRepository
{
    private readonly IPersistenceRepository persistenceRepository;
    private readonly AppDbContext dbContext;

    public RecipeRepository(
        AppDbContext dbContext,
        IPersistenceRepository persistenceRepository
    )
    {
        this.dbContext = dbContext;
        this.persistenceRepository = persistenceRepository;
    }

    public async Task<List<RecipeDto>> GetAllAsync()
    {
        return await dbContext.Recipes
            .Include(r => r.RecipeAndIngredients)
              .ThenInclude(ri => ri.Ingredient)
            .Select(r => new RecipeDto
            {
                Id = r.Id,
                Title = r.Title,
                PreparationMethod = r.PreparationMethod,
                Ingredients = r.RecipeAndIngredients
                    .Select(ri => new IngredientDto
                    {
                        Id = ri.IngredientId,
                        Name = ri.Ingredient.Name,
                        Quantity = ri.Quantity,
                        Unit = ri.Ingredient.Unit
                    }).ToList()
            })
            .ToListAsync();
    }

    public async Task<RecipeDto?> GetByIdAsync(Guid id)
    {
        return await dbContext.Recipes
            .Where(r => r.Id == id)
            .Include(r => r.RecipeAndIngredients)
              .ThenInclude(ri => ri.Ingredient)
            .Select(r => new RecipeDto
            {
                Id = r.Id,
                Title = r.Title,
                PreparationMethod = r.PreparationMethod,
                Ingredients = r.RecipeAndIngredients
                    .Select(ri => new IngredientDto
                    {
                        Id = ri.IngredientId,
                        Name = ri.Ingredient.Name,
                        Quantity = ri.Quantity,
                        Unit = ri.Ingredient.Unit
                    }).ToList()
            })
            .FirstOrDefaultAsync();
    }

    public async Task<Recipe> AddAsync(Recipe recipe)
    {
        dbContext.Recipes.Add(recipe);
        await persistenceRepository.SaveChangesAsync();
        return recipe;
    }

    public async Task<Recipe> UpdateAsync(Recipe recipe)
    {
        dbContext.Recipes.Update(recipe);
        await persistenceRepository.SaveChangesAsync();
        return recipe;
    }

    public async Task<List<RecipeAndIngredient>> GetRecipeIngredientsByIdAsync(Guid id)
    {
        return await dbContext.RecipeAndIngredients
            .Where(ri => ri.RecipeId == id)
            .ToListAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var rowsAffected = await dbContext.Recipes
            .Where(recipe => recipe.Id == id)
            .ExecuteDeleteAsync();

        if (rowsAffected == 0)
        {
            throw new KeyNotFoundException($"Recipe with ID {id} not found.");
        }
    }
}

