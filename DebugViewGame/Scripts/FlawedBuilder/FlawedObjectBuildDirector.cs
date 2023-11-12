namespace DebugViewGame.Scripts.FlawedBuilder
{
	using Meta;

	public class FlawedObjectBuildDirector
	{
		#region Builders
		private SpinningTopBuilder _spinningTopBuilder;
		#endregion

		#region Internal Methods
		internal UnbalancedObject BuildUnbalancedObject(UnbalancedObjectID id)
		{
			UnbalancedObject result = null;
			switch ( id )
			{
				case UnbalancedObjectID.None:
					break;
				case UnbalancedObjectID.SpinningTop:
					result = new SpinningTopBuilder().Build();
					break;
			}
			return result;
		}
		#endregion
	}
}
