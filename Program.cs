using TamagotchiApp.Models;

namespace TamagotchiApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			Tamagotchi tamagotchi = new("Tama");
			builder.Services.AddSingleton(tamagotchi);

			var app = builder.Build();

			app.MapGet("/", (Tamagotchi tama) => {
				return Results.Json(tama);
				});

			app.Run();
		}
	}
}
