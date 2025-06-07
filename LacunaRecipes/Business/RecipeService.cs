using LacunaRecipes.Business.Repositories;
using LacunaRecipes.Entities;
using LacunaRecipes.Models;

namespace LacunaRecipes.Business;

public class RecipeService
{
    private readonly IRecipeRepository recipeRepository;
    private readonly IIngredientRepository ingredientRepository;
    private readonly IRecipeAndIngredientRepository recipeAndIngredientRepository;
    private readonly IPersistenceRepository persistenceRepository;

    public RecipeService(
        IRecipeRepository recipeRepository,
        IIngredientRepository ingredientRepository,
        IRecipeAndIngredientRepository recipeAndIngredientRepository,
        IPersistenceRepository persistenceRepository
        )
    {
        this.recipeRepository = recipeRepository;
        this.ingredientRepository = ingredientRepository;
        this.recipeAndIngredientRepository = recipeAndIngredientRepository;
        this.persistenceRepository = persistenceRepository;
    }

    public Task<List<RecipeDto>> GetAllRecipesAsync()
        => recipeRepository.GetAllAsync();

    public Task<RecipeDto?> GetRecipeByIdAsync(Guid id)
        => recipeRepository.GetByIdAsync(id);

    public async Task<Recipe> AddRecipeAsync(Recipe recipe)
    {
        return await persistenceRepository.TransactionAsync(async () =>
        {
            return await recipeRepository.AddAsync(recipe);
        });
    }

    public async Task<Recipe> UpdateRecipeAsync(Recipe recipe)
    {
        return await persistenceRepository.TransactionAsync(async () =>
        {
            return await recipeRepository.UpdateAsync(recipe);
        });
    }

    public async Task DeleteRecipeByIdAsync(Guid id)
    {
        var recipe = await recipeRepository.GetByIdAsync(id);
        if (recipe == null)
        {
            throw new KeyNotFoundException($"Recipe with ID {id} not found.");
        }

        var recipeAndIngredients = await recipeRepository.GetRecipeIngredientsByIdAsync(id);

        await persistenceRepository.TransactionAsync(async () =>
        {
            foreach (var recipeAndIngredient in recipeAndIngredients)
            {
                await recipeAndIngredientRepository.DeleteAsync(recipeAndIngredient.Id);
            }
            await recipeRepository.DeleteAsync(id);
        });
    }
}
