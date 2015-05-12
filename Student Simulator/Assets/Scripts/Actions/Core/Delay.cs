using System;

namespace Actions.Core
{
	class Delay : GameAction
	{
		float totalDelay;
		float currentDelay;

		public Delay (float Delay)
		{
			totalDelay = Delay;
			currentDelay = 0;
		}

		public override void Reset ()
		{
			currentDelay = 0;
		}

		public override bool Upadate (float Delta)
		{
			if(currentDelay > totalDelay)
				return false;

			currentDelay += Delta;
			return true;
		}
	}
}

