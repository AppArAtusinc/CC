using System;

namespace Actions.Core
{
	/// <summary>
	/// Stop sequence for some time.
	/// </summary>
	class Delay : GameAction
	{
		/// <summary>
		/// Total time for wating.
		/// </summary>
		public float TotalDelay;
		/// <summary>
		/// Current waiting time.
		/// </summary>
		public float CurrentDelay;

		public Delay(){}

		/// <summary>
		/// Creating action which stop action sequence for somr time. 
		/// </summary>
		/// <param name="Delay"> Time for waiting. One second == 1.0 </param>
		public Delay (float Delay)
		{
			TotalDelay = Delay;
			CurrentDelay = 0;
		}

		/// <summary>
		/// Reset current time to zero.
		/// </summary>
		public override void Reset ()
		{
			CurrentDelay = 0;
		}

		/// <summary>
		/// Calling each frame.
		/// </summary>
		/// <param name="Delta"> Time from last call.</param>
		/// <returns>
		/// true: current waiting time less that total waiting time
		/// false: current waiting time greate that total waiting time
		/// </returns>
		public override bool Upadate (float Delta)
		{
			if(CurrentDelay > TotalDelay)
				return false;

			CurrentDelay += Delta;
			return true;
		}
	}
}

