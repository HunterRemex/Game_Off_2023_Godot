namespace CoinDashGaming.Scripts.FlawedBuilder
{
	using Godot;

	public interface IUnbalancedObject
	{
		public int TotalFlaws { get; }
		public int FlawsSolved { get; }

		public void SolveFlaw(int index);

		public Signal TestExamination();
	}
}