namespace DebugViewGame.Gameplay
{
	using Godot;
	using Scripts.FlawedBuilder;

	[GlobalClass]
	public partial class SpinningTop : UnbalancedObject
	{
		private int GenerateFlaws()
		{
			return 0;
		}

		public override void _Ready()
		{
			base._Ready();
			TotalFlaws = GenerateFlaws();
			FlawsSolved = 0;
			// TODO: Top has been spawned, create flaws, mat instances, etc...
		}
	}
}