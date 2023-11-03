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
		private float _moveSpeed = 350.0f;
		[Export]
		private AnimatedSprite2D _characterSprite;
		[Export]
		private CollisionShape2D _characterCollider;
		#endregion

		#region Private Fields
		private Vector2 _characterVelocity;
		private Vector2 _screenSize;

		private float _characterColliderHalfXSize;
		private float _characterColliderHalfYSize;
		#endregion

		#region Private Methods
		private void UpdatePosition(Vector2 velocity, float deltaTime)
		{
			Vector2 newPos = Position + velocity * _moveSpeed * deltaTime;
			// Clamp the position to the screen
			newPos.X = Mathf.Clamp(newPos.X, _characterColliderHalfXSize, _screenSize.X - _characterColliderHalfXSize);
			newPos.Y = Mathf.Clamp(newPos.Y, _characterColliderHalfYSize, _screenSize.Y - _characterColliderHalfYSize);

			Position = newPos;
		}

		private void UpdateSprite(Vector2 velocity)
		{
			if ( velocity.Length() > 0 )
			{
				_characterSprite.Animation = CHARACTER_ANIM_RUN;
			}
			else
			{
				_characterSprite.Animation = CHARACTER_ANIM_IDLE;
			}

			if ( velocity.X != 0 )
			{
				_characterSprite.FlipH = Mathf.Sign(velocity.X) < 0;
			}
		}

		private void Start()
		{
			SetProcess(true);
			Position = _screenSize / 2.0f;
			_characterSprite.Animation = CHARACTER_ANIM_IDLE;
		}

		private void Die()
		{
			_characterSprite.Animation = CHARACTER_ANIM_HURT;
			SetProcess(false);
		}
		#endregion

		#region Signal Receivers
		private void _on_area_entered(Area2D otherArea)
		{
			if ( otherArea.IsInGroup(StringConstants.GROUP_COINS) == true )
			{
				// otherArea.Connect(SignalName.Pickup, this.call, nameof(_on_area_entered));
				EmitSignal(nameof(SignalName.Pickup));
			}
			else if ( otherArea.IsInGroup(StringConstants.GROUP_OBSTACLES) == true )
			{
				EmitSignal(nameof(SignalName.Hurt));
				Die();
			}
		}
		#endregion

		#region Godot Methods
		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			_screenSize = GetViewport().GetVisibleRect().Size;
			_characterColliderHalfXSize = _characterCollider.Shape.GetRect().Size.X / 2.0f;
			_characterColliderHalfYSize = _characterCollider.Shape.GetRect().Size.Y / 2.0f;
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
			_characterVelocity = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
			UpdatePosition(_characterVelocity, (float)delta);
			UpdateSprite(_characterVelocity);
		}
		#endregion
	}
}