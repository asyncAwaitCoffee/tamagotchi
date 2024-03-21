using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using TamagotchiApp.Models;
using TamagotchiApp.Services;

namespace TamagotchiApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder();
			builder.Services.AddSingleton<FoodService>();
			builder.Services.AddSingleton<Garden>();
			builder.Services.AddHostedService<LifeTicks>();
			
			var app = builder.Build();

			app.UseStaticFiles();

			app.MapGet("/", () => {				
				return Results.LocalRedirect("/index.html");
			});

			app.MapPost("/tama-new", ([FromForm] string name, Garden garden) =>
			{
				Tamagotchi tamagotchi = new(name);
				garden.Add(tamagotchi);
				return Results.LocalRedirect("/");
			}).DisableAntiforgery();

			app.MapGet("api/tama-all", (Garden garden) =>
			{
				return Results.Json(garden.GetAllTama());
			});

			app.MapGet("api/food-list", (FoodService food) =>
			{
				return Results.Json(food.GetFoodList());
			});

			app.MapPut("api/feed", ([FromForm] int foodId, [FromForm] string name, FoodService foodService, Garden garden) =>
			{
				var tama = garden.GetTamaByName(name);
				var food = foodService.GetFoodById(foodId);

				if (tama is not null && food is not null)
				{
					tama.Fullness += food.Value;
				}
				return Results.Ok();
			}).DisableAntiforgery();

			app.Run();
		}
	}
}
