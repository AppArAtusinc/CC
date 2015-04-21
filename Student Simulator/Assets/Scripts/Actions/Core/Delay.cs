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

		public override void Upadate (float Delta)
		{
			currentDelay += Delta;
			if(currentDelay > totalDelay)
				OnEnd(this);
		}
	}
}

