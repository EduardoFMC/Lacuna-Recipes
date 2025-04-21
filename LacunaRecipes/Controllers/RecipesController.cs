using LacunaRecipes.Business;
using LacunaRecipes.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LacunaRecipes.Controllers;

[ApiController]
[Route("api/recipes")]
public class RecipesController : ControllerBase {
	private readonly RecipeService recipeService;

	public RecipesController(RecipeService recipeService) {
		this.recipeService = recipeService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAllRecipes() {
		var recipes = await recipeService.GetAllRecipesAsync();
		return Ok(recipes);
	}

	[HttpGet("{id:guid}")]
	public async Task<IActionResult> GetRecipeById(Guid id) {
		var recipe = await recipeService.GetRecipeByIdAsync(id);
		if (recipe == null) {
			return NotFound();
		}
		return Ok(recipe);
	}

	[HttpPost]
	public async Task<IActionResult> AddRecipe([FromBody] Recipe recipe) {
		if (!ModelState.IsValid) {
			return BadRequest(ModelState);
		}
		var createdRecipe = await recipeService.AddRecipeAsync(recipe);
		return CreatedAtAction(nameof(GetRecipeById), new { id = createdRecipe.Id }, createdRecipe);
	}

	[HttpPut("{id:guid}")]
	public async Task<IActionResult> UpdateRecipe(Guid id, [FromBody] Recipe recipe) {
		if (!ModelState.IsValid) {
			return BadRequest(ModelState);
		}
		if (id != recipe.Id) {
			return BadRequest("Recipe ID mismatch.");
		}
		var updatedRecipe = await recipeService.UpdateRecipeAsync(recipe);
		return Ok(updatedRecipe);
	}

	[HttpDelete("{id:guid}")]
	public async Task<IActionResult> DeleteRecipe(Guid id) {
		var recipe = await recipeService.GetRecipeByIdAsync(id);
		if (recipe == null) {
			return NotFound();
		}
		await recipeService.DeleteRecipeAsync(id);
		return NoContent();
	}
}
