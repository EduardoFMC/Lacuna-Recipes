using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LacunaRecipes.Migrations
{
    /// <inheritdoc />
    public partial class FixRecipeRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeAndIngredients",
                table: "RecipeAndIngredients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeAndIngredients",
                table: "RecipeAndIngredients",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeAndIngredients_RecipeId",
                table: "RecipeAndIngredients",
                column: "RecipeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeAndIngredients",
                table: "RecipeAndIngredients");

            migrationBuilder.DropIndex(
                name: "IX_RecipeAndIngredients_RecipeId",
                table: "RecipeAndIngredients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeAndIngredients",
                table: "RecipeAndIngredients",
                columns: new[] { "RecipeId", "IngredientId" });
        }
    }
}
