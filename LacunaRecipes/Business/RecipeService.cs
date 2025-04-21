using LacunaRecipes.Business.Repositories;
using LacunaRecipes.Entities;

namespace LacunaRecipes.Business;

public class RecipeService {
	private readonly IRecipeRepository recipeRepository;
	private readonly IIngredientRepository ingredientRepository;
	private readonly IRecipeAndIngredientRepository recipeAndIngredientRepository;

	public RecipeService(
		IRecipeRepository recipeRepository,
		IIngredientRepository ingredientRepository,
		IRecipeAndIngredientRepository recipeAndIngredientRepository
		) {
		this.recipeRepository = recipeRepository;
		this.ingredientRepository = ingredientRepository;
		this.recipeAndIngredientRepository = recipeAndIngredientRepository;
	}

	public async Task<List<Recipe>> GetAllRecipesAsync() {
		return await recipeRepository.GetAllAsync();
	}

	public async Task<Recipe?> GetRecipeByIdAsync(Guid id) {
		return await recipeRepository.GetByIdAsync(id);
	}

	public async Task<Recipe> AddRecipeAsync(Recipe recipe) {
		return await recipeRepository.AddAsync(recipe);
	}

	public async Task<Recipe> UpdateRecipeAsync(Recipe recipe) {
		return await recipeRepository.UpdateAsync(recipe);
	}

	public async Task DeleteRecipeAsync(Guid id) {
		await recipeRepository.DeleteAsync(id);
	}
}
