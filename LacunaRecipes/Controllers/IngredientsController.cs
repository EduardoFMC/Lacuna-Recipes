using LacunaRecipes.Business;
using LacunaRecipes.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LacunaRecipes.Controllers;

[ApiController]
[Route("api/ingredients")]
public class IngredientsController : ControllerBase
{
    private readonly IngredientService ingredientService;

    public IngredientsController(
        IngredientService ingredientService
        )
    {
        this.ingredientService = ingredientService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllIngredients()
    {
        //<IActionResult> is good as a return withou an exception builder
        // i could maybe create one, but its just a simple CRUD
        var ingredients = await ingredientService.GetAllIngredientsAsync();
        return Ok(ingredients);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetIngredientById(Guid id)
    {
        var ingredient = await ingredientService.GetIngredientByIdAsync(id);
        if (ingredient == null)
        {
            return NotFound();
        }
        return Ok(ingredient);
    }

    [HttpPost]
    public async Task<IActionResult> AddIngredient([FromBody] Ingredient ingredient)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdIngredient = await ingredientService.AddIngredientAsync(ingredient);
        return CreatedAtAction(nameof(GetIngredientById), new { id = createdIngredient.Id }, createdIngredient);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateIngredient(Guid id, [FromBody] Ingredient ingredient)
    {
        if (!ModelState.IsValid || id != ingredient.Id)
        {
            return BadRequest(ModelState);
        }

        var updatedIngredient = await ingredientService.UpdateIngredientAsync(ingredient);
        return Ok(updatedIngredient);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteIngredient(Guid id)
    {
        var ingredient = await ingredientService.GetIngredientByIdAsync(id);
        if (ingredient == null)
        {
            return NotFound();
        }

        await ingredientService.DeleteAllRecipeAndIngredientsAsync(id);

        await ingredientService.DeleteIngredientAsync(id);
        return NoContent();
    }
}
