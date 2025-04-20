using LacunaRecipes.Entities;

namespace LacunaRecipes.Business.Repositories;

public interface IRecipeAndIngredientRepository {
	Task<List<RecipeAndIngredient>> GetAllAsync();
	Task<RecipeAndIngredient?> GetByIdAsync(Guid id);
	Task<RecipeAndIngredient> AddAsync(RecipeAndIngredient recipeAndIngredient);
	Task<RecipeAndIngredient> UpdateAsync(RecipeAndIngredient recipeAndIngredient);
}
