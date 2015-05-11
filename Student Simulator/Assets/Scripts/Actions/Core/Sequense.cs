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
			foreach (var action in actions)
				action.OnEnd += onInnerActionEnd;
		}

		public override void Reset ()
		{
			base.Reset();
			index = 0;
			resetActions();
		}

		public override void Upadate (float Delta)
		{
			if(End)
				return;

			actions[index].Upadate(Delta);
		}

		void resetActions()
		{
			foreach(var action in actions)
				action.Reset();
		}

		void onInnerActionEnd(GameAction Action)
		{
			index++;

			if(index == actions.Length)
			{
				End = true;
				OnEnd(this);
			}
		}
	}
}

