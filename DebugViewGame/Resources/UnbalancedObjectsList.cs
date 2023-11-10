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
		#region Inspector-Set Fields
		[Export]
		private UnbalancedObjectPrefab[] unbalancedObjectPrefabs;
		#endregion

		public static UnbalancedObjectsList Instance { get; private set; }

		internal PackedScene GetUnbalancedObject(UnbalancedObjectID uObjID)
		{
			PackedScene result = null;

			result = unbalancedObjectPrefabs[(int)uObjID].PackedScene;

			return result;
		}
	}
}
