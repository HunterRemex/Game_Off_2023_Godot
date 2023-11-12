namespace DebugViewGame.Scripts.FlawedBuilder
{
	using System.Threading.Tasks;
	using Godot;
	using Meta;

	[GlobalClass]
	public partial class UnbalancedObject : Node3D, IUnbalancedObject
	{
		#region CONSTANTS
		private const float INSPECT_PANNING_SPEED = 500.0f;
		private const float INSPECT_SCROLL_DISTANCE = 0.125f;
		#endregion

		#region Inspector-Set Fields
		[Export]
		private Node3D inspectionTransformNode;
		#endregion

		#region Variables
		private Transform3D _preInspectTransform;
		private Transform3D inspectionTransform;
		private Task _moveToInspectTask;
		private bool _isInspectRotating;
		private bool _isInspectPanning;
		#endregion

		#region IUnbalancedObject Properties
		[Export] public RigidBody3D Obj { get; set; }
		public int TotalFlaws { get; protected set; }
		public int FlawsSolved { get; protected set; } = 0;
		public bool isObjectFrozen
		{
			get => Obj.Freeze;
		}

		public bool isObjectBeingInspected { get; protected set; }
		#endregion

		#region Godot Methods
		public override void _Ready()
		{
			base._Ready();
			inspectionTransform = inspectionTransformNode.Transform;
		}

		public override async void _Input(InputEvent @event)
		{
			base._Input(@event);

			if ( isObjectFrozen == true )
			{
				if ( isObjectBeingInspected == true &&
					 @event is InputEventMouseButton mouse )
				{
					_isInspectRotating = mouse.IsActionPressed(InputConstants.INPUT_UI_SELECT);
					_isInspectPanning = mouse.IsActionPressed(InputConstants.INPUT_UI_PAN);
				}
				else if ( isObjectBeingInspected == true &&
						  _isInspectRotating == true &&
						  @event is InputEventMouseMotion motionRotate )
				{
					Obj.GlobalRotate(Vector3.Up, motionRotate.Relative.X / INSPECT_PANNING_SPEED);
					Obj.GlobalRotate(Vector3.Right, -motionRotate.Relative.Y / INSPECT_PANNING_SPEED);
				}
				else if ( isObjectBeingInspected == true &&
						  _isInspectPanning == true &&
						  @event is InputEventMouseMotion motionPan )
				{
					Vector3 offset = new Vector3(-motionPan.Relative.X / INSPECT_PANNING_SPEED, -motionPan.Relative.Y / INSPECT_PANNING_SPEED, 0.0f);
					offset = offset.Rotated(Vector3.Right, inspectionTransformNode.Rotation.X);
					Obj.GlobalTranslate(offset);
				}

				if ( isObjectBeingInspected == true &&
					 @event is InputEventMouseButton { ButtonIndex: MouseButton.WheelDown or MouseButton.WheelUp } mouseScroll)
				{
					float sign = mouseScroll.ButtonIndex == MouseButton.WheelDown ? 1.0f : -1.0f;
					Vector3 offset = new Vector3(0.0f, 0.0f, mouseScroll.Factor * sign * INSPECT_SCROLL_DISTANCE);
					offset = offset.Rotated(Vector3.Right, inspectionTransformNode.Rotation.X);
					Obj.GlobalTranslate(offset);
				}
			}
			else if ( isObjectFrozen == false &&
					  isObjectBeingInspected == false &&
					  @event.IsActionPressed(InputConstants.INPUT_UI_SELECT) == true )
			{
				await FreezeForInspection(true);
			}
		}
		#endregion

		#region IUnbalancedObject Methods
		public void SolveFlaw(int index)
		{
			throw new System.NotImplementedException();
		}

		private async Task MoveToInspectionPosition()
		{
			_preInspectTransform = Obj.Transform;

			await MoveObjToInspectionPosition();
		}

		public Signal TestExamination()
		{
			throw new System.NotImplementedException();
		}

		public virtual async Task FreezeForInspection(bool isFrozen)
		{
			if ( Obj is RigidBody3D rb )
			{
				rb.Freeze = isFrozen;
				await MoveToInspectionPosition();
			}
		}
		#endregion

		#region Coroutines
		private async Task MoveObjToInspectionPosition()
		{
			float alpha = 0.05f;
			while ( Obj.Transform.Basis.IsEqualApprox(inspectionTransform.Basis) == false )
			{
				Obj.Transform = Obj.Transform.InterpolateWith(inspectionTransform, alpha);
				alpha *= 1.01f;
				await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
			}

			isObjectBeingInspected = true;
		}
		#endregion
	}
}