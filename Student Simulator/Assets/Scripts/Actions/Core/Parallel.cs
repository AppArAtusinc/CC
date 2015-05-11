using System;
using System.Collections.Generic;

namespace Actions.Core
{
	class Parallel : GameAction
	{
		GameAction[] actions;

		public Parallel (params GameAction[] Actions)
		{
			actions = Actions;
			foreach(var action in actions)
				action.OnEnd += onInnerActionEnd;
		}

		public override void Reset ()
		{
			for(int i = 0; i<actions.Length; i++)
				actions[i].Reset();
		}

		public override void Upadate (float Delta)
		{
			if(End)
				return;

			foreach(var action in actions)
				action.Upadate(Delta);
		}


		void onInnerActionEnd(GameAction EndedAction)
		{
			End = true;
			OnEnd(this);
		}

	}
}

