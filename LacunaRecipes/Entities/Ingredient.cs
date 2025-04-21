using System.ComponentModel.DataAnnotations;

namespace LacunaRecipes.Entities {
	public class Ingredient {
		public Guid Id { get; set; }

		[Required]
		public string Name { get; set; } = string.Empty;

		[Required]
		public string Unit { get; set; } = string.Empty;
	}
}
