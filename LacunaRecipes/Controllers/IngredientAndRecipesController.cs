using LacunaRecipes.Business;
using LacunaRecipes.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LacunaRecipes.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientAndRecipesController : ControllerBase {
	private readonly IngredientAndRecipeService ingredientAndRecipeService;

	public IngredientAndRecipesController(IngredientAndRecipeService ingredientAndRecipeService) {
		this.ingredientAndRecipeService = ingredientAndRecipeService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll() {
		var result = await ingredientAndRecipeService.GetAllAsync();
		return Ok(result);
	}

	[HttpGet("{id:guid}")]
	public async Task<IActionResult> GetById(Guid id) {
		var result = await ingredientAndRecipeService.GetByIdAsync(id);
		if (result == null) {
			return NotFound();
		}
		return Ok(result);
	}

	[HttpPost]
	public async Task<IActionResult> Add([FromBody] RecipeAndIngredient recipeAndIngredient) {
		if (!ModelState.IsValid) {
			return BadRequest(ModelState);
		}

		var result = await ingredientAndRecipeService.AddAsync(recipeAndIngredient);
		// no ID, só for now the action is created from recipe id
		return CreatedAtAction(nameof(GetById), new { id = recipeAndIngredient.RecipeId }, result);
	}

	[HttpPut("{id:guid}")]
	public async Task<IActionResult> Update(Guid id, [FromBody] RecipeAndIngredient recipeAndIngredient) {
		var existing = await ingredientAndRecipeService.GetByIdAsync(id);
		if (existing == null) {
			return NotFound();
		}

		var result = await ingredientAndRecipeService.UpdateAsync(recipeAndIngredient);
		return Ok(result);
	}
}
