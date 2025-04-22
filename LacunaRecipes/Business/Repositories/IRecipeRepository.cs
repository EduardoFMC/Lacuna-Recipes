using LacunaRecipes.Entities;

namespace LacunaRecipes.Business.Repositories;

public interface IRecipeRepository {
	Task<List<Recipe>> GetAllAsync();
	Task<Recipe?> GetByIdAsync(Guid id);
	Task<Recipe> AddAsync(Recipe recipe);
	Task<Recipe> UpdateAsync(Recipe recipe);
	Task<List<RecipeAndIngredient>> GetRecipeIngredientsByIdAsync(Guid id);
	Task DeleteAsync(Guid id);
}
