using System.ComponentModel.DataAnnotations;

namespace LacunaRecipes.Entities
{
    public class Recipe
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string PreparationMethod { get; set; } = string.Empty;

        public ICollection<RecipeAndIngredient> RecipeAndIngredients { get; set; } = new List<RecipeAndIngredient>();
    }
}
