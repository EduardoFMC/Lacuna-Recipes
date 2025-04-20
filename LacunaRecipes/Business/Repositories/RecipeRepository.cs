using LacunaRecipes.Entities;
using Microsoft.EntityFrameworkCore;

namespace LacunaRecipes.Business.Repositories;

public class RecipeRepository : IRecipeRepository {
	private readonly IPersistenceRepository persistenceRepository;
	private readonly AppDbContext dbContext;

	public RecipeRepository(
		AppDbContext dbContext,
		PersistenceRepository persistenceRepository
	) {
		this.dbContext = dbContext;
		this.persistenceRepository = persistenceRepository;
	}

	public async Task<List<Recipe>> GetAllAsync() {
		return await dbContext.Recipes.ToListAsync();
	}

	public async Task<Recipe?> GetByIdAsync(Guid id) {
		return await dbContext.Recipes.FindAsync(id);
	}

	public async Task<Recipe> AddAsync(Recipe recipe) {
		dbContext.Recipes.Add(recipe);
		await persistenceRepository.SaveChangesAsync();
		return recipe;
	}

	public async Task<Recipe> UpdateAsync(Recipe recipe) {
		dbContext.Recipes.Update(recipe);
		await persistenceRepository.SaveChangesAsync();
		return recipe;
	}

	public async Task DeleteAsync(Guid id) {
		var rowsAffected = await dbContext.Recipes
			.Where(recipe => recipe.Id == id)
			.ExecuteDeleteAsync();

		if (rowsAffected == 0) {
			throw new KeyNotFoundException($"Recipe with ID {id} not found.");
		}
	}
}

