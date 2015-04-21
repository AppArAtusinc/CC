using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actions.Core
{
    static class ActionManager
    {
        static List<GameAction> actions;
		static List<GameAction> endActions;
         
        static ActionManager()
        {
            actions = new List<GameAction>();
			endActions = new List<GameAction>();
        }

        static public GameAction Add(GameAction NewAction)
        {
            actions.Add(NewAction);
            NewAction.OnEnd += onActionEnd;

            return NewAction;
        }

        static public GameAction GetActionsByName(string Name)
        {
            var query = actions.FindAll(o => o.Name == Name);

            return query.FirstOrDefault();
        }

        static public bool RemoveByName(string Name)
        {
            actions.RemoveAll(o => o.Name == Name);
            return true;
        }

        static public void Update(float Delta)
        {
			foreach(var action in actions)
				action.Upadate(Delta);

			if(endActions.Count > 0)
			{
				foreach(var actionForDelete in endActions)
				actions.Remove(actionForDelete);

				endActions.Clear();
			}
        }

        static void onActionEnd(GameAction EndedAction)
        {
			endActions.Add(EndedAction);
        }
    }
}
