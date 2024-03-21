
using TamagotchiApp.Interfaces;

namespace TamagotchiApp.Services
{
	public class LifeTicks : IHostedService, IDisposable
	{
		private Timer _timer;
		private readonly Garden _garden;

        public LifeTicks(Garden garden)
        {
            _garden = garden;
        }
        public void Dispose()
		{
			_timer.Dispose();
		}

		public Task StartAsync(CancellationToken cancellationToken)
		{
			_timer = new Timer(Do, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
			return Task.CompletedTask;
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			_timer.Change(Timeout.Infinite, 0);
			return Task.CompletedTask;
		}

		public void Do(object? state)
		{
			foreach (var tama in _garden.GetAllTama())
			{
				tama.Age++;
				tama.Fullness--;
				Console.WriteLine((tama.Name, tama.Age, tama.Fullness));
			}
		}
	}
}
