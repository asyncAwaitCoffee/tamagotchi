using TamagotchiApp.Models;
using TamagotchiApp.Services;

namespace TamagotchiApp
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			Tamagotchi tamagotchi = new("Tama");
			builder.Services.AddSingleton(tamagotchi);
			var app = builder.Build();

			LifeTicks lifeTicks = new LifeTicks();
			lifeTicks.Start();

			app.MapGet("/", (Tamagotchi tama) => {
				lifeTicks.Add(tama);
				return Results.Json(tama);
				});

			app.Run();
		}
	}
}
