using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LacunaRecipes.Entities {
	public class RecipeAndIngredient {
		[Key]
		[Column(Order = 0)]
		[ForeignKey("Recipe")]
		public Guid RecipeId { get; set; }
		public Recipe Recipe { get; set; }

		[Key]
		[Column(Order = 1)]
		[ForeignKey("Document")]
		public Guid IngredientId { get; set; }
		public Ingredient Ingredient { get; set; }

		[Required]
		public string Quantity { get; set; }
	}
}
