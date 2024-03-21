using TamagotchiApp.Models;

namespace TamagotchiApp.Services
{
	public class FoodService
	{
		private Dictionary<int, Food> _food = new() {
			{1, new("Apple", 2, 2m) },
			{2, new("Bagel", 4, 3m) },
			{3, new("Pizza", 10, 8m) },
		};

		public Food? GetFoodById(int id)
		{
			_food.TryGetValue(id, out Food? food);
			return food;
		}
		public Dictionary<int, Food> GetFoodList()
		{
			return _food;
		}
	}
}
