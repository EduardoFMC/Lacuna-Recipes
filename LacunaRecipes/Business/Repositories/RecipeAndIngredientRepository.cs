using LacunaRecipes.Entities;
using Microsoft.EntityFrameworkCore;

namespace LacunaRecipes.Business.Repositories;

public class RecipeAndIngredientRepository : IRecipeAndIngredientRepository {
	private readonly IPersistenceRepository persistenceRepository;
	private readonly AppDbContext dbContext;

	public RecipeAndIngredientRepository(
		AppDbContext dbContext,
		IPersistenceRepository persistenceRepository
	) {
		this.dbContext = dbContext;
		this.persistenceRepository = persistenceRepository;
	}

	public async Task<List<RecipeAndIngredient>> GetAllAsync() {
		return await dbContext.RecipeAndIngredients.ToListAsync();
	}

	public async Task<RecipeAndIngredient?> GetByIdAsync(Guid id) {
		return await dbContext.RecipeAndIngredients.FindAsync(id);
	}

	public async Task<RecipeAndIngredient> AddAsync(RecipeAndIngredient recipeAndIngredient) {
		dbContext.RecipeAndIngredients.Add(recipeAndIngredient);
		await persistenceRepository.SaveChangesAsync();
		return recipeAndIngredient;
	}

	public async Task<RecipeAndIngredient> UpdateAsync(RecipeAndIngredient recipeAndIngredient) {
		dbContext.RecipeAndIngredients.Update(recipeAndIngredient);
		await persistenceRepository.SaveChangesAsync();
		return recipeAndIngredient;
	}

	public async Task<List<RecipeAndIngredient>> GetRecipeIngredientsByIngredientIdAsync(Guid ingredientId) {
		return await dbContext.RecipeAndIngredients
			.Where(x => x.IngredientId == ingredientId)
			.ToListAsync();
	}

	public async Task DeleteAsync(Guid id) {
		var entity = await dbContext.RecipeAndIngredients.FindAsync(id);
		if (entity != null) {
			dbContext.RecipeAndIngredients.Remove(entity);
			await persistenceRepository.SaveChangesAsync();
		}
	}
}

