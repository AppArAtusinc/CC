using System;

namespace Actions.Core
{
	class Sequense : GameAction
	{
		GameAction[] actions;
		int index;
		public Sequense (params GameAction[] Actions)
		{
			actions = Actions;
			Reset();
		}

		public override void Reset ()
		{
			base.Reset();
			index = 0;
			resetActions();
		}

		public override bool Upadate (float Delta)
		{
			if(index == actions.Length)
				return false;

			if(!actions[index].Upadate(Delta))
				index++;

			return true;
		}

		void resetActions()
		{
			foreach(var action in actions)
				action.Reset();
		}
	}
}

