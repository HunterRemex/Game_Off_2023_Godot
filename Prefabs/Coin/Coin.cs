namespace CoinDashGaming.Scripts
{
	using Godot;
	using System;

	public partial class Coin : Area2D
	{
		#region Private Methods
		private void Pickup()
		{
			QueueFree();
		}
		#endregion
	}
}
