using System.Collections.Generic;
using TamagotchiApp.Interfaces;

namespace TamagotchiApp.Services
{
	public class LifeTicks
	{
		readonly PeriodicTimer _timer = new(TimeSpan.FromSeconds(1));
		readonly List<ILive> _lives = [];
		public void Grow()
		{

			foreach (var item in _lives)
			{
				item.Age++;
				Console.WriteLine(item.Age);
            }
        }
		public void Add(ILive live)
		{
			_lives.Add(live);
		}

		public async void Start()
		{
			while (await _timer.WaitForNextTickAsync())
			{
				Grow();
			}
		}
}
}
