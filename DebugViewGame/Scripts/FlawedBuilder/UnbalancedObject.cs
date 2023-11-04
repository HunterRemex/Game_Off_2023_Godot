namespace CoinDashGaming.Scripts.FlawedBuilder
{
	using Godot;

	public partial class UnbalancedObject : Node3D, IUnbalancedObject
	{
		public override void _Process(double delta)
		{
			base._Process(delta);

			// camera.
		}

		#region IUnbalancedObject members
		public int TotalFlaws { get; protected set; }

		public int FlawsSolved { get; protected set; }

		public void SolveFlaw(int index)
		{
			throw new System.NotImplementedException();
		}

		public Signal TestExamination()
		{
			throw new System.NotImplementedException();
		}
		#endregion
	}
}