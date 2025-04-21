using LacunaRecipes.Business.Repositories;
using LacunaRecipes.Entities;

namespace LacunaRecipes.Business;

public class IngredientService {
	private readonly IIngredientRepository ingredientRepository;
	private readonly IRecipeRepository recipeRepository;
	private readonly IRecipeAndIngredientRepository recipeAndIngredientRepository;

	public IngredientService(
		IIngredientRepository ingredientRepository,
		IRecipeRepository recipeRepository,
		IRecipeAndIngredientRepository recipeAndIngredientRepository
		) {
		this.ingredientRepository = ingredientRepository;
		this.recipeRepository = recipeRepository;
		this.recipeAndIngredientRepository = recipeAndIngredientRepository;
	}

	public async Task<List<Ingredient>> GetAllIngredientsAsync() {
		return await ingredientRepository.GetAllAsync();
	}

	public async Task<Ingredient?> GetIngredientByIdAsync(Guid id) {
		return await ingredientRepository.GetByIdAsync(id);
	}

	public async Task<Ingredient> AddIngredientAsync(Ingredient ingredient) {
		return await ingredientRepository.AddAsync(ingredient);
	}

	public async Task<Ingredient> UpdateIngredientAsync(Ingredient ingredient) {
		return await ingredientRepository.UpdateAsync(ingredient);
	}

	public async Task DeleteIngredientAsync(Guid id) {
		await ingredientRepository.DeleteAsync(id);
	}
}
