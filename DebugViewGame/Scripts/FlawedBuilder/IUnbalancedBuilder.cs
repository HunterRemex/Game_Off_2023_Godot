namespace CoinDashGaming.Scripts.FlawedBuilder
{
	using Godot;

	internal enum PlayerDebugViewMode
	{
		None = 0,
		Normal = 1,
		Depth = 2,
	}

	public interface IUnbalancedBuilder
	{
		public int TotalFlaws { get; }

		public int FlawsSolved { get; }

		public UnbalancedObject Build();

		public void SolveFlaw(int index);

		public Signal TestExamination();
	}
}