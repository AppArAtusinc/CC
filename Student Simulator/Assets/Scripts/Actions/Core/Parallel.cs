using System;
using System.Collections.Generic;

namespace Actions.Core
{
	class Parallel : GameAction
	{
		int actionsRunning;
		List<GameAction> actions;
		List<GameAction> endActions;

		public Parallel (params GameAction[] Actions)
		{
			actions = new List<GameAction>();
			for(int i=0; i<Actions.Length; i++)
				actions.Add(Actions[i]);
			actionsRunning = actions.Count;

			foreach(var action in actions)
				action.OnEnd += onInnerActionEnd;

			endActions = new List<GameAction>();
		}

		public override void Reset ()
		{

		}
		public override void Upadate (float Delta)
		{
			foreach(var action in actions)
				action.Upadate(Delta);

			if(endActions.Count > 0)
			{
				foreach(var action in endActions)
					actions.Remove(action);

				endActions.Clear();
			}
		}

		
		public GameAction SetBreakAction(GameAction BreakAction)
		{
			BreakAction.OnEnd += breakActionEnd;
			actions.Add(BreakAction);
			return this;
		}

		void onInnerActionEnd(GameAction EndedAction)
		{
			actionsRunning--;
			endActions.Add(EndedAction);

			if(actionsRunning == 0)
				OnEnd(this);
		}

		void breakActionEnd(GameAction BreakAction)
		{
			OnEnd(this);
		}

	}
}

