namespace DebugViewGame.Scripts.FlawedBuilder
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

		/// <summary>
		/// Returns the unbalanced object if it exists, otherwise Builds a new unbalanced object
		/// </summary>
		/// <returns></returns>
		public Node GetConstructedObject();
	}
}