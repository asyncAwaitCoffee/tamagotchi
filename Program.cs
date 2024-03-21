using Microsoft.AspNetCore.Mvc;
using TamagotchiApp.Models;
using TamagotchiApp.Services;

namespace TamagotchiApp
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddSingleton<FoodService>();
			builder.Services.AddSingleton<Garden>();
			builder.Services.AddHostedService<LifeTicks>();
			
			var app = builder.Build();

			app.MapGet("/", async (ctx) => {
				ctx.Response.ContentType = "text/html";
				await ctx.Response.WriteAsync(
					"""
						<form action="/tama-new" method="POST">
							<input type="text" name="name">
							<input type="submit" value="Ok">
						</form>
					""");
				});

			app.MapPost("/tama-new", ([FromForm] string name, Garden garden) =>
			{
				Tamagotchi tamagotchi = new(name);
				garden.Add(tamagotchi);
				return Results.Redirect("/");
            }).DisableAntiforgery();

			app.MapPut("/{id:int}", (int id, FoodService foodService, Garden garden) =>
			{
                Food? food = foodService.GetFoodById(id);
				if (food is not null)
				{
					garden.GetAllTama().First().Fullness += food.Value;
				}
				return Results.Ok();
            });

			app.Run();
		}
	}
}
