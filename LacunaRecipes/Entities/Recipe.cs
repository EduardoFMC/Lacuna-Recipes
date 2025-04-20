using System.ComponentModel.DataAnnotations;

namespace LacunaRecipes.Entities {
	public class Recipe {
		public Guid Id { get; set; }

		[Required]
		public string Title { get; set; } = string.Empty;

		[Required]
		public string PreparationMethod { get; set; } = string.Empty;
	}
}
