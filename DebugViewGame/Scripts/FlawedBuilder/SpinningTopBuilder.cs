namespace CoinDashGaming.Scripts.FlawedBuilder
{
	using DebugViewGame.Prefabs.Objects.SpinningTop;
	using Godot;

	public partial class SpinningTopBuilder : IUnbalancedBuilder
	{
		#region Privatae Fields
		private SpinningTop _spinningTop;
		#endregion

		#region IUnbalancedBuilder Members
		public int TotalFlaws => _spinningTop.TotalFlaws;

		public int FlawsSolved => _spinningTop.FlawsSolved;

		public UnbalancedObject Build()
		{
			_spinningTop = new SpinningTop();
			return _spinningTop;
		}

		public Node GetConstructedObject()
		{
			SpinningTop node = _spinningTop;
			if ( _spinningTop == null )
			{
				node = Build() as SpinningTop;
			}
			return node;
		}
		#endregion
	}
}