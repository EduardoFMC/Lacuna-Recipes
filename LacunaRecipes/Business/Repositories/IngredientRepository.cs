using LacunaRecipes.Entities;
using Microsoft.EntityFrameworkCore;

namespace LacunaRecipes.Business.Repositories;

public class IngredientRepository : IIngredientRepository{
	private readonly IPersistenceRepository persistenceRepository;
	private readonly AppDbContext dbContext;

	public IngredientRepository(
		AppDbContext dbContext,
		IPersistenceRepository persistenceRepository
	) {
		this.dbContext = dbContext;
		this.persistenceRepository = persistenceRepository;
	}

	public async Task<List<Ingredient>> GetAllAsync() {
		return await dbContext.Ingredients.ToListAsync();
	}

	public async Task<Ingredient?> GetByIdAsync(Guid id) {
		return await dbContext.Ingredients.FindAsync(id);
	}

	public async Task<Ingredient> AddAsync(Ingredient ingredient) {
		dbContext.Ingredients.Add(ingredient);
		await persistenceRepository.SaveChangesAsync();
		return ingredient;
	}

	public async Task<Ingredient> UpdateAsync(Ingredient ingredient) {
		dbContext.Ingredients.Update(ingredient);
		await persistenceRepository.SaveChangesAsync();
		return ingredient;
	}

	public async Task DeleteAsync(Guid id) {
		var rowsAffected = await dbContext.Ingredients
			.Where(ingredient => ingredient.Id == id)
			.ExecuteDeleteAsync();

		if (rowsAffected == 0) {
			throw new KeyNotFoundException($"Ingredient with ID {id} not found.");
		}
	}
}

