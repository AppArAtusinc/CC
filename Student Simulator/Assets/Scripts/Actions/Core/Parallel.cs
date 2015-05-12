using System;
using System.Collections.Generic;

namespace Actions.Core
{
	class Parallel : GameAction
	{
		GameAction[] actions;
		bool end;

		public Parallel (params GameAction[] Actions)
		{
			actions = Actions;
		}

		public override void Reset ()
		{
			end = false;
			for(int i = 0; i<actions.Length; i++)
				actions[i].Reset();
		}

		public override bool Upadate (float Delta)
		{
			if(end)
				return false;

			foreach(var action in actions)
				if(!action.Upadate(Delta))
				{
					end = true;
					return false;
				}

			return true;
		}
	}
}

