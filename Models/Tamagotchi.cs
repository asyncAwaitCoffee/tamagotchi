namespace TamagotchiApp.Models
{
	public class Tamagotchi(string name)
	{
        public int Health { get; private set; } = 100;
        public int Age { get; private set; } = 1;
        public int Fullness { get; private set; } = 100;
        public string Name { get; init; } = name;
    }
}
