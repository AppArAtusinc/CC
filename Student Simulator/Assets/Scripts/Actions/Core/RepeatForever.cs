using System;

namespace Actions.Core
{
	class RepeatForever : GameAction
	{
		public GameAction[] actions;
		public int index;
		
		public RepeatForever (params GameAction[] Actions)
		{
			actions = Actions;
			Reset();
		}
		
		public override void Reset ()
		{
			base.Reset();
			index = 0;
			actions[index].Reset();
		}

		public override bool Upadate (float Delta)
		{
			if(!actions[index].Upadate(Delta))
			{
				index++;
				if(index == actions.Length)
					index = 0;
				actions[index].Reset();
			}
			
			return true;
		}
	}
}

