using StudentSimulator.SaveSystem;
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
        [Save]
        float totalDelay;
		/// <summary>
		/// Current waiting time.
		/// </summary>
        [Save]
        float currentDelay;

		public Delay(){}

		/// <summary>
		/// Creating action which stop action sequence for somr time. 
		/// </summary>
		/// <param name="Delay"> Time for waiting. One second == 1.0 </param>
		public Delay (float Delay)
		{
			totalDelay = Delay;
			currentDelay = 0;
		}

		/// <summary>
		/// Reset current time to zero.
		/// </summary>
		public override void Reset ()
		{
			currentDelay = 0;
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
			if(currentDelay > totalDelay)
				return false;

			currentDelay += Delta;
			return true;
		}
	}
}

