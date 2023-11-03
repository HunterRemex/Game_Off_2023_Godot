using Godot;

namespace CoinDashGaming.Scripts
{
	public partial class Player : Area2D
	{
		#region CONSTANTS
		private const string CHARACTER_ANIM_IDLE = "idle";
		private const string CHARACTER_ANIM_RUN = "run";
		private const string CHARACTER_ANIM_HURT = "hurt";
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