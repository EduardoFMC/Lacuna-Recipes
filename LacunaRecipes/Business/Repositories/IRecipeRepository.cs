using LacunaRecipes.Entities;
using LacunaRecipes.Models;

namespace LacunaRecipes.Business.Repositories;

public interface IRecipeRepository {
	Task<List<RecipeDto>> GetAllAsync();
	Task<RecipeDto?> GetByIdAsync(Guid id);
	Task<Recipe> AddAsync(Recipe recipe);
	Task<Recipe> UpdateAsync(Recipe recipe);
	Task<List<RecipeAndIngredient>> GetRecipeIngredientsByIdAsync(Guid id);
	Task DeleteAsync(Guid id);
}
