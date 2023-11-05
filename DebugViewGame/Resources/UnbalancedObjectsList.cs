namespace CoinDashGaming.DebugViewGame.Resources
{
	using System.Collections;
	using System.Collections.Generic;
	using Godot;

	public enum UnbalancedObjectID
	{
		None = 0,
		SpinningTop = 1,
	}

	public sealed partial class UnbalancedObjectsList : Resource
	{

		[Export]
		private UnbalancedObjectPrefab[] unbalancedObjectPrefabs;

		internal PackedScene GetUnbalancedObject(UnbalancedObjectID uObjID)
		{
			PackedScene result = null;

			result = unbalancedObjectsPrefabs[uObjID] as PackedScene;

			return result;
		}
	}
}