namespace CoinDashGaming.DebugViewGame.Resources
{
	using System.Collections;
	using System.Collections.Generic;
	using Godot;

	public sealed partial class UnbalancedObjectPrefabList : Resource
	{
		#region Inspector-Set Fields
		[Export]
		private UnbalancedObjectPrefab[] unbalancedObjectPrefabs;
		#endregion

		public static UnbalancedObjectPrefabList Instance { get; private set; }

		internal PackedScene GetUnbalancedObjectPrefab(UnbalancedObjectID uObjID)
		{
			PackedScene result = null;

			result = unbalancedObjectPrefabs[(int)uObjID].PackedScene;

			return result;
		}
	}
}
