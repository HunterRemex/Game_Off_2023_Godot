namespace DebugViewGame.Meta
{
	using Godot;

	public partial class GameController : Node
	{
		#region Singleton
		public static GameController Instance { get; private set; }
		#endregion

		#region Public Methods
		public void TransitionToGameplayMode()
		{
			// Disable Title Screen

			// Enable Object Spawner

			// Enable Gameplay UI~
		}
		#endregion

		#region Godot Methods
		public override void _Process(double delta)
		{
			base._Process(delta);

			Viewport port = GetViewport();
			if (port!= null &&
				Time.GetTicksMsec() >> 3 == 0)
			{
				port.DebugDraw = (Viewport.DebugDrawEnum)(((int)port.DebugDraw + 1) % 26);
				GD.Print(port.DebugDraw.ToString());
			}
		}

		public override void _EnterTree()
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
		#endregion
	}
}