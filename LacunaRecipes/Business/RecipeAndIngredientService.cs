using LacunaRecipes.Business.Repositories;
using LacunaRecipes.Entities;

namespace LacunaRecipes.Business;

public class RecipeAndIngredientService
{
    private readonly IIngredientRepository ingredientRepository;
    private readonly IRecipeRepository recipeRepository;
    private readonly IRecipeAndIngredientRepository recipeAndIngredientRepository;
    private readonly IPersistenceRepository persistenceRepository;

    public RecipeAndIngredientService(
        IIngredientRepository ingredientRepository,
        IRecipeRepository recipeRepository,
        IRecipeAndIngredientRepository recipeAndIngredientRepository,
        IPersistenceRepository persistenceRepository
        )
    {
        this.ingredientRepository = ingredientRepository;
        this.recipeRepository = recipeRepository;
        this.recipeAndIngredientRepository = recipeAndIngredientRepository;
        this.persistenceRepository = persistenceRepository;
    }

    public async Task<List<RecipeAndIngredient>> GetAllAsync()
    {
        return await recipeAndIngredientRepository.GetAllAsync();
    }

    public async Task<RecipeAndIngredient?> GetByIdAsync(Guid id)
    {
        return await recipeAndIngredientRepository.GetByIdAsync(id);
    }

    public async Task<RecipeAndIngredient> AddAsync(RecipeAndIngredient recipeAndIngredient)
    {
        return await persistenceRepository.TransactionAsync(
            () => recipeAndIngredientRepository.AddAsync(recipeAndIngredient)
        );
    }

    public async Task<RecipeAndIngredient> UpdateAsync(RecipeAndIngredient recipeAndIngredient)
    {
        return await persistenceRepository.TransactionAsync(
            () => recipeAndIngredientRepository.UpdateAsync(recipeAndIngredient)
        );
    }

    public async Task DelectAsync(Guid id)
    {
        await persistenceRepository.TransactionAsync(
            () => recipeAndIngredientRepository.DeleteAsync(id)
        );
    }
}
