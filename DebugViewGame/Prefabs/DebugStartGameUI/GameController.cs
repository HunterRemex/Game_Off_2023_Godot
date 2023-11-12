namespace DebugViewGame.Meta
{
	using System;
	using System.Threading.Tasks;
	using Godot;
	using Scripts.FlawedBuilder;

	[GlobalClass]
	public partial class GameController : Node3D
	{
		#region Singleton
		public static GameController Instance { get; private set; }
		#endregion

		#region Inspector-Set Fields
		[Export]
		private PackedScene _titleScreenGUISceneResource { get; set; }

		[Export]
		private PackedScene _gameplayScreenGUIScene;
		#endregion

		#region Private Variables
		private bool _titleScreenIsVisible = false;

		private TitleScreenController _controllerTitleScreen;
		private FlawedObjectBuildDirector _buildDirector;
		#endregion

		#region Public Methods
		public async Task<bool> TryTransitionToGameplayMode()
		{
			// Disable Title Screen
			_controllerTitleScreen.Visible = false;

			// Enable Object Spawner
			_buildDirector = new FlawedObjectBuildDirector();

			AddChild(_buildDirector.BuildUnbalancedObject(UnbalancedObjectID.SpinningTop));
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
			if ( _titleScreenGUISceneResource != null )
			{
				_controllerTitleScreen = _titleScreenGUISceneResource.Instantiate<TitleScreenController>();
				AddChild(_controllerTitleScreen);
				_titleScreenIsVisible = true;
			}
			else
			{
				throw new NullReferenceException("GameController: Title Screen PackedScene is not available!");
			}
		}
		#endregion

		#region Godot Methods
		public override void _Ready()
		{
			StartSingleton();

			LoadTitleScreen();
		}
		#endregion
	}
}
