using LacunaRecipes.Entities;

namespace LacunaRecipes.Business.Repositories;

public interface IIngredientRepository
{
    Task<List<Ingredient>> GetAllAsync();
    Task<Ingredient?> GetByIdAsync(Guid id);
    Task<Ingredient> AddAsync(Ingredient ingredient);
    Task<Ingredient> UpdateAsync(Ingredient ingredient);
    Task DeleteAsync(Guid id);
}

