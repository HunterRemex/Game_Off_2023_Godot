namespace CoinDashGaming.Scripts
{
	using Godot;

	public partial class Player : Area2D
	{
		#region CONSTANTS
		private const string CHARACTER_ANIM_IDLE = "idle";
		private const string CHARACTER_ANIM_RUN = "run";
		private const string CHARACTER_ANIM_HURT = "hurt";
		#endregion

		#region Signal Delegates
		[Signal]
		public delegate void PickupEventHandler();

		[Signal]
		public delegate void HurtEventHandler();
		#endregion

		#region Inspector-Set Fields
		[Export]
		private float moveSpeed = 350.0f;
		[Export]
		private AnimatedSprite2D characterSprite;
		[Export]
		private CollisionShape2D characterCollider;
		#endregion

		#region Variables
		private Vector2 _characterVelocity;
		private Vector2 _screenSize;

		private float _characterColliderHalfXSize;
		private float _characterColliderHalfYSize;
		#endregion

		#region Internal Methods
		internal void Start()
		{
			SetProcess(true);
			Position = _screenSize / 2.0f;
			characterSprite.Animation = CHARACTER_ANIM_IDLE;
		}
		#endregion

		#region Private Methods
		private void UpdatePosition(Vector2 velocity, float deltaTime)
		{
			Vector2 newPos = Position + velocity * moveSpeed * deltaTime;
			// Clamp the position to the screen
			newPos.X = Mathf.Clamp(newPos.X, _characterColliderHalfXSize, _screenSize.X - _characterColliderHalfXSize);
			newPos.Y = Mathf.Clamp(newPos.Y, _characterColliderHalfYSize, _screenSize.Y - _characterColliderHalfYSize);

			Position = newPos;
		}

		private void UpdateSprite(Vector2 velocity)
		{
			if ( velocity.Length() > 0 )
			{
				characterSprite.Animation = CHARACTER_ANIM_RUN;
			}
			else
			{
				characterSprite.Animation = CHARACTER_ANIM_IDLE;
			}

			if ( velocity.X != 0 )
			{
				characterSprite.FlipH = Mathf.Sign(velocity.X) < 0;
			}
		}

		private void Die()
		{
			characterSprite.Animation = CHARACTER_ANIM_HURT;
			SetProcess(false);
		}
		#endregion

		#region Signal Receivers
		private void OnAreaEntered(Area2D otherArea)
		{
			if ( otherArea.IsInGroup(StringConstants.GROUP_OBSTACLES) == true )
			{
				EmitSignal(SignalName.Hurt);
				Die();
			}
		}

		private void OnPickup()
		{
			GD.Print("Pickup on Player");
		}
		#endregion

		#region Godot Methods
		public override void _Ready()
		{
			_screenSize = GetViewport().GetVisibleRect().Size;
			_characterColliderHalfXSize = characterCollider.Shape.GetRect().Size.X / 2.0f;
			_characterColliderHalfYSize = characterCollider.Shape.GetRect().Size.Y / 2.0f;
			Connect(SignalName.Pickup, new Callable(this, nameof(OnPickup)));
		}

		public override void _Process(double delta)
		{
			_characterVelocity = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
			UpdatePosition(_characterVelocity, (float)delta);
			UpdateSprite(_characterVelocity);
		}
		#endregion
	}
}
