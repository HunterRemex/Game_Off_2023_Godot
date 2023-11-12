namespace DebugViewGame.Gameplay
{
	using Godot;
	using Meta;

	public partial class UnbalancedObjectPrefab : Resource
	{
		[Export]
		public UnbalancedObjectID ID { get; private set; }
		[Export]
		public PackedScene PackedScene { get; private set; }
	}
}
