using System.Text.Json.Serialization;
using LacunaRecipes.Business;
using LacunaRecipes.Business.Repositories;
using LacunaRecipes.Entities;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IRecipeAndIngredientRepository, RecipeAndIngredientRepository>();
builder.Services.AddScoped<IPersistenceRepository, PersistenceRepository>();
builder.Services.AddScoped<RecipeAndIngredientService>();
builder.Services.AddScoped<IngredientService>();
builder.Services.AddScoped<RecipeService>();

builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseSqlServer(
		builder.Configuration.GetConnectionString("DefaultConnection")
	)
);

builder.Services.AddControllers()
	.AddJsonOptions(options => {
		options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
	});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
