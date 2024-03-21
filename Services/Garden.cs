using TamagotchiApp.Interfaces;

namespace TamagotchiApp.Services
{
	public class Garden
	{
		readonly List<ILive> _lives = [];
		public void Add(ILive item)
		{
			_lives.Add(item);
		}
		public IEnumerable<ILive> GetAllTama()
		{
			return _lives;
		}

		public ILive? GetTamaByName(string name)
		{
			return _lives.FirstOrDefault(l => l.Name == name);
		}
	}
}
