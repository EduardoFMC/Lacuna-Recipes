using LacunaRecipes.Business.Repositories;
using LacunaRecipes.Entities;

namespace LacunaRecipes.Business;

public class IngredientService {
	private readonly IIngredientRepository ingredientRepository;
	private readonly IRecipeRepository recipeRepository;
	private readonly IRecipeAndIngredientRepository recipeAndIngredientRepository;
	private readonly IPersistenceRepository persistenceRepository;

	public IngredientService(
		IIngredientRepository ingredientRepository,
		IRecipeRepository recipeRepository,
		IRecipeAndIngredientRepository recipeAndIngredientRepository,
		IPersistenceRepository persistenceRepository
		) {
		this.ingredientRepository = ingredientRepository;
		this.recipeRepository = recipeRepository;
		this.recipeAndIngredientRepository = recipeAndIngredientRepository;
		this.persistenceRepository = persistenceRepository;
	}

	public async Task<List<Ingredient>> GetAllIngredientsAsync() {
		return await ingredientRepository.GetAllAsync();
	}

	public async Task<Ingredient?> GetIngredientByIdAsync(Guid id) {
		return await ingredientRepository.GetByIdAsync(id);
	}

	public async Task<Ingredient> AddIngredientAsync(Ingredient ingredient) {
		return await persistenceRepository.TransactionAsync(
			() => ingredientRepository.AddAsync(ingredient)
		);
	}

	public async Task<Ingredient> UpdateIngredientAsync(Ingredient ingredient) {
		return await persistenceRepository.TransactionAsync(
			() => ingredientRepository.UpdateAsync(ingredient)
		);
	}

	public async Task DeleteAllRecipeAndIngredientsAsync(Guid ingredientId) {
		var recipeAndIngredients = await recipeAndIngredientRepository.GetRecipeIngredientsByIngredientIdAsync(ingredientId);
		foreach (var recipeAndIngredient in recipeAndIngredients) {
			await recipeAndIngredientRepository.DeleteAsync(recipeAndIngredient.Id);
		}
		var recipes = await recipeRepository.GetAllAsync();
		foreach (var recipe in recipes) {
			await recipeRepository.DeleteAsync(recipe.Id);
		}
	}

	public async Task DeleteIngredientAsync(Guid id) {
		await persistenceRepository.TransactionAsync(
			() => ingredientRepository.DeleteAsync(id)
		);
	}
}
