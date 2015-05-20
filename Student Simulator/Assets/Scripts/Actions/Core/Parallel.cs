using System;
using System.Collections.Generic;

namespace Actions.Core
{
	class Parallel : GameAction
	{
		GameAction[] actions;
		bool[] ended;

		public Parallel (params GameAction[] Actions)
		{
			actions = Actions;
			ended = new bool[actions.Length];
		}

		public override void Reset ()
		{
			for(int i = 0; i<actions.Length; i++)
			{
				actions[i].Reset();
				ended[i] = false;
			}
		}

		public override bool Upadate (float Delta)
		{
			bool ok = false;
			for(int i=0;i<ended.Length; i++)
				if(!ended[i])
				{
					ended[i] = !actions[i].Upadate(Delta);
					ok = true;
					continue;
				}
			return ok;
		}
	}
}

