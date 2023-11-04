namespace CoinDashGaming.Scripts.FlawedBuilder
{
	using Godot;

	public partial class SpinningTopBuilder : IUnbalancedBuilder
	{
		#region IUnbalancedBuilder Members
		public UnbalancedObject Build()
		{
			throw new System.NotImplementedException();
		}

		public int TotalFlaws { get; } = 3;

		public int FlawsSolved { get; }

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
