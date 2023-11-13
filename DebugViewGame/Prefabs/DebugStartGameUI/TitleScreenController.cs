namespace DebugViewGame.Meta
{
	using Godot;

	public partial class TitleScreenController : Control
	{
		#region Inspector-Set Fields
		[Export]
		private Button startGameButton;
		#endregion

		private async void StartGameButton_ButtonUp()
		{
			await GameController.Instance.TryTransitionToGameplayMode();
			
		}

		#region Godot Methods
		public override void _Ready()
		{
			base._Ready();
			startGameButton.ButtonUp += StartGameButton_ButtonUp;
		}

		public override void _ExitTree()
		{
			base._ExitTree();
		}
		#endregion
	}
}