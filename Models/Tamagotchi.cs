using TamagotchiApp.Interfaces;

namespace TamagotchiApp.Models
{
	public class Tamagotchi(string name) : ILive
	{
        public int Health { get; set; } = 100;
        public int Age { get; set; } = 1;
        public int Fullness { get; set; } = 100;
        public string Name { get; init; } = name;
    }
}
