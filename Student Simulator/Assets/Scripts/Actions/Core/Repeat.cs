using System;

namespace Actions.Core
{
	class Repeat : GameAction
	{
		GameAction[] actions;
		int index;
		int repeatCount;
		int currentRepeatCount;

		public Repeat (params GameAction[] Actions)
		{
			actions = Actions;
			Reset();
		}
		
		public override void Reset ()
		{
			base.Reset();
			index = 0;
			currentRepeatCount = 0;
			actions[index].Reset();
		}

		public Repeat SetRepeatCount(int Count)
		{
			repeatCount = Count;
			return this;
		}

		public override bool Upadate (float Delta)
		{
			if(!actions[index].Upadate(Delta))
			{
				index++;
				if(index == actions.Length)
				{
					index = 0;
					currentRepeatCount++;
					if(currentRepeatCount == repeatCount)
						return false;
				}
				actions[index].Reset();
			}
			
			return true;
		}
	}
}

