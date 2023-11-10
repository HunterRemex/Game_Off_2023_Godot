namespace DebugViewGame.Scripts.FlawedBuilder
{
	using System.Threading.Tasks;
	using Godot;

	public interface IUnbalancedObject
	{
		public RigidBody3D Obj { get; }
		public int TotalFlaws { get; }
		public int FlawsSolved { get; }
		public bool isObjectFrozen { get; }
		public bool isObjectBeingInspected { get; }


		public void SolveFlaw(int index);

		public Signal TestExamination();

		public Task FreezeForInspection(bool isFrozen);
	}
}