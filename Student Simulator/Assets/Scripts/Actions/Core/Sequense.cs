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
			index = 0;

			foreach (var action in actions)
				action.OnEnd += onInnerActionEnd;
		}

		public override void Upadate (float Delta)
		{
			actions[index].Upadate(Delta);
		}

		void onInnerActionEnd(GameAction Action)
		{
			index++;
			if( index == actions.Length )
				OnEnd(this);
		}

	}
}

