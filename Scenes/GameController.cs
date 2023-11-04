namespace CoinDashGaming.Scripts
{
	using Godot;

	public partial class GameController : Node
	{
		#region CONSTANTS
		private const int INITIAL_COINS = 4;
		#endregion

		#region Inspector-Set Fields
		[Export]
		private PackedScene coinScene;
		[Export]
		private Player player;
		[Export]
		private Timer gameTimer;
		[Export]
		private float roundPlaytime = 30.0f;
		#endregion

		#region Variables
		private int _level = 0;
		private int _score = 0;
		private float _timeLeft = 0.0f;

		private Vector2 _screenSize = Vector2.Zero;
		private bool _isPlaying = false;
		#endregion

		#region Private Methods
		private void NewGame()
		{
			_isPlaying = true;
			_level = 1;
			_score = 0;
			_timeLeft = roundPlaytime;

			player.Start();
			player.Show();

			gameTimer.Start();
			SpawnCoins();
		}

		private void SpawnCoins()
		{
			for ( int i = 0; i < _level + INITIAL_COINS; i++ )
			{
				Coin coin = (Coin)coinScene.Instantiate();
				coin.SetRandomPosition(_screenSize);
				AddChild(coin);
			}
		}
		#endregion

		#region Godot Methods
		public override void _Ready()
		{
			_screenSize = GetViewport().GetVisibleRect().Size;
			// player.Hide();
			SpawnCoins();
		}

		public override void _Process(double delta) { }
		#endregion
	}
}
