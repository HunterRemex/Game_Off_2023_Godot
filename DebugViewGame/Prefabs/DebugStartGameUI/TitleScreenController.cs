namespace DebugViewGame.Meta
{
	using Godot;

	public partial class TitleScreenController : Node3D
	{
		#region Inspector-Set Fields
		[Export]
		private Button startGameButton;
		#endregion

		public override void _Ready()
		{
			base._Ready();
			startGameButton.ButtonUp += StartGameButton_ButtonUp;
		}

		private void StartGameButton_ButtonUp()
		{
			GameController.Instance.TransitionToGameplayMode();

		}
	}
}