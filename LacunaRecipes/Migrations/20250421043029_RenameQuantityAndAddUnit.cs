using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LacunaRecipes.Migrations
{
    /// <inheritdoc />
    public partial class RenameQuantityAndAddUnit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuantityInGrams",
                table: "RecipeAndIngredients",
                newName: "Quantity");

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Ingredients");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "RecipeAndIngredients",
                newName: "QuantityInGrams");
        }
    }
}
