namespace DebugViewGame.Gameplay
{
	using System.Linq;
	using Godot;
	using Godot.Collections;
	using Meta;

	[GlobalClass]
	public sealed partial class UnbalancedObjectPrefabCatalog : Node
	{
		#region Inspector-Set Fields
		[Export]
		private Array<UnbalancedObjectPrefab> unbalancedObjectPrefabs;
		#endregion

		#region Singleton
		public static UnbalancedObjectPrefabCatalog Instance { get; private set; }
		#endregion

		#region Private Methods
		private void StartSingleton()
		{
			if ( Instance == null )
			{
				Instance = this;
			}
			else
			{
				Free();
			}
		}
		#endregion

		#region Internal Methods
		internal PackedScene GetUnbalancedObjectPrefab(UnbalancedObjectID uObjID)
		{
			PackedScene result = null;

			result = unbalancedObjectPrefabs.FirstOrDefault(x => x.ID == uObjID)?.PackedScene;

			return result;
		}
		#endregion

		#region Godot Methods
		public override void _Ready()
		{
			StartSingleton();
		}
		#endregion
	}
}