
namespace LacunaRecipes.Models;
public class IngredientDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Quantity { get; set; } = string.Empty;
    public string Unit { get; set; } = string.Empty;
}

public class RecipeDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string PreparationMethod { get; set; } = string.Empty;
    public List<IngredientDto> Ingredients { get; set; } = new();
}

