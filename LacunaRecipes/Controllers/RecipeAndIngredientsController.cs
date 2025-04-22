using LacunaRecipes.Business;
using LacunaRecipes.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LacunaRecipes.Controllers;

[ApiController]
[Route("api/recipe-and-ingredients")]
public class RecipeAndIngredientsController : ControllerBase {
	private readonly RecipeAndIngredientService recipeAndIngredientService;

	public RecipeAndIngredientsController(RecipeAndIngredientService ingredientAndRecipeService) {
		this.recipeAndIngredientService = ingredientAndRecipeService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll() {
		var result = await recipeAndIngredientService.GetAllAsync();
		return Ok(result);
	}

	[HttpGet("{id:guid}")]
	public async Task<IActionResult> GetById(Guid id) {
		var result = await recipeAndIngredientService.GetByIdAsync(id);
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

		var result = await recipeAndIngredientService.AddAsync(recipeAndIngredient);
		// no ID, só for agora(best frase) the action is created from recipe id
		return CreatedAtAction(nameof(GetById), new { id = recipeAndIngredient.Id }, result);
	}

	[HttpPut("{id:guid}")]
	public async Task<IActionResult> Update(Guid id, [FromBody] RecipeAndIngredient recipeAndIngredient) {
		var existing = await recipeAndIngredientService.GetByIdAsync(id);
		if (existing == null) {
			return NotFound();
		}

		var result = await recipeAndIngredientService.UpdateAsync(recipeAndIngredient);
		return Ok(result);
	}
}
