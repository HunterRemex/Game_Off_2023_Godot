namespace DebugViewGame.Meta
{
	using System;
	using System.Threading.Tasks;
	using Godot;

	[GlobalClass]
	public partial class GameController : Node
	{
		#region Singleton
		public static GameController Instance { get; private set; }
		#endregion

		#region Inspector-Set Fields
		[Export]
		private PackedScene _titleScreenGUIScene;
		[Export]
		private PackedScene _gameplayScreenGUIScene;
		#endregion

		#region Private Variables
		private bool _titleScreenIsVisible = false;
		#endregion

		#region Public Methods
		public async Task<bool> TryTransitionToGameplayMode()
		{
			// Disable Title Screen

			// Enable Object Spawner

			// Enable Gameplay UI~

			return true;
		}
		#endregion

		#region Private Methods
		private void StartSingleton()
		{
			if ( Instance == null )
			{
				Instance = this;
			}
			else
			{
				Free();
			}
		}

		private void LoadTitleScreen()
		{
			if ( _titleScreenGUIScene != null )
			{
				_titleScreenGUIScene.Instantiate();
			}
			else
			{
				throw new NullReferenceException("GameController: Title Screen PackedScene is not available!");
			}
		}
		#endregion

		#region Godot Methods
		public override void _Process(double delta)
		{
			base._Process(delta);
		}

		public override void _Ready()
		{
			StartSingleton();

			LoadTitleScreen();
		}
		#endregion
	}
}
