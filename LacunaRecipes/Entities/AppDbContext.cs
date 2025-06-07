using Microsoft.EntityFrameworkCore;


namespace LacunaRecipes.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeAndIngredient> RecipeAndIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RecipeAndIngredient>()
                .HasKey(ri => ri.Id);

            modelBuilder.Entity<RecipeAndIngredient>()
                .HasOne(ri => ri.Recipe)
                .WithMany(r => r.RecipeAndIngredients)
                .HasForeignKey(ri => ri.RecipeId);

            modelBuilder.Entity<RecipeAndIngredient>()
                .HasOne(ri => ri.Ingredient)
                .WithMany()
                .HasForeignKey(ri => ri.IngredientId);
        }
    }
}
