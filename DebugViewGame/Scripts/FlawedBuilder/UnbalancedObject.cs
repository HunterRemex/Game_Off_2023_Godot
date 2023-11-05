namespace CoinDashGaming.Scripts.FlawedBuilder
{
	using DebugViewGame.Scripts;
	using Godot;

	[GlobalClass]
	public partial class UnbalancedObject : Node3D, IUnbalancedObject
	{
		#region IUnbalancedObject Properties
		[Export]
		public RigidBody3D Obj { get; set; }
		public int TotalFlaws { get; protected set; }
		public int FlawsSolved { get; protected set; } = 0;
		public bool isObjectFrozen
		{
			get => Obj.Freeze;
		}
		#endregion

		#region Godot Methods
		public override void _Input(InputEvent @event)
		{
			base._Input(@event);

			if ( isObjectFrozen == false &&
				 @event.IsActionPressed(InputConstants.INPUT_UI_SELECT) == true)
			{
				FreezeForInspection(true);
			}
		}
		#endregion

		#region IUnbalancedObject Methods
		public void SolveFlaw(int index)
		{
			throw new System.NotImplementedException();
		}

		public Signal TestExamination()
		{
			throw new System.NotImplementedException();
		}

		public virtual void FreezeForInspection(bool isFrozen)
		{
			if ( Obj is RigidBody3D rb )
			{
				rb.Freeze = isFrozen;
			}
		}
		#endregion
	}
}