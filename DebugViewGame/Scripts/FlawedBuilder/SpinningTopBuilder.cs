namespace CoinDashGaming.Scripts.FlawedBuilder
{
	using DebugViewGame.Prefabs.Objects.SpinningTop;
	using DebugViewGame.Resources;
	using Godot;

	public partial class SpinningTopBuilder : IUnbalancedBuilder
	{
		#region CONSTANTS
		private const string PREFAB_METADATA_NAME = "prefabToInstantiate";
		#endregion
		#region Private Fields
		private PackedScene _spinningTopPrefab;
		private SpinningTop _spinningTop;
		#endregion

		#region IUnbalancedBuilder Members
		public int TotalFlaws => _spinningTop.TotalFlaws;

		public int FlawsSolved => _spinningTop.FlawsSolved;

		public UnbalancedObject Build()
		{
			if (_spinningTop == null)
			{
				_spinningTopPrefab ??= UnbalancedObjectsList.Instance.GetUnbalancedObject(UnbalancedObjectID.SpinningTop);

				_spinningTop = _spinningTopPrefab.Instantiate() as SpinningTop;
			}
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