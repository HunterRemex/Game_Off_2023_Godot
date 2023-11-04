namespace CoinDashGaming.Scripts
{
	using Godot;

	public partial class Coin : Area2D
	{
		#region CONSTANTS
		private const string COIN_ANIM_IDLE = "idle";
		#endregion

		#region Signal Delegates
		[Signal]
		public delegate void PickupEventHandler();
		#endregion

		#region Inspector-Set Fields
		[Export]
		private CollisionShape2D colliderShape;
		[Export]
		private AnimatedSprite2D coinSprite;
		#endregion

		#region Variables
		private float _colliderRadius;
		#endregion

		#region Internal Methods
		internal void SetRandomPosition(Vector2 screenSize)
		{
			Position = new Vector2((float)GD.RandRange(0.0f + _colliderRadius, screenSize.X - _colliderRadius),
								   (float)GD.RandRange(0.0f + _colliderRadius, screenSize.Y - _colliderRadius));
		}
		#endregion

		#region Private Methods
		private void OnPickup()
		{
			GD.Print("Coin picked up!");
			QueueFree();
		}
		#endregion

		#region Signal Receivers
		private void OnAreaEntered(Area2D otherArea)
		{
			GD.Print("Coin Entered");
			if ( otherArea.IsInGroup(StringConstants.GROUP_PLAYER) == true )
			{
				GD.Print("Player picked up a coin");
				// otherArea.Connect(SignalName.Pickup, new Godot.Callable(otherArea, SignalName.Pickup));
				otherArea.EmitSignal(SignalName.Pickup);
				EmitSignal(SignalName.Pickup);
			}
		}
		#endregion

		#region Godot Methods
		public override void _Ready()
		{
			_colliderRadius = colliderShape.Shape.GetRect().Size.X / 2.0f;
			coinSprite.Frame = GD.RandRange(0, coinSprite.SpriteFrames.GetFrameCount(COIN_ANIM_IDLE));
		}
		#endregion
	}
}
