namespace CoinDashGaming.Scripts.FlawedBuilder
{
	using Godot;

	public interface IUnbalancedObject
	{
		public RigidBody3D Obj { get; }
		public int TotalFlaws { get; }
		public int FlawsSolved { get; }
		public bool isObjectFrozen { get; }

		public void SolveFlaw(int index);

		public Signal TestExamination();

		public void FreezeForInspection(bool isFrozen);
	}
}