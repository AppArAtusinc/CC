using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actions.Core
{
    static class ActionManager
    {
        static List<GameAction> actions;
		static int index = 0;
         
        static ActionManager()
        {
            actions = new List<GameAction>();
        }

        static public GameAction Add(GameAction NewAction)
        {
            actions.Add(NewAction);
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

		static public bool Update(float Delta)
        {
			//@todo: think about optimization
			for(index = 0; index < actions.Count; index++)
				if(!actions[index].Upadate(Delta))
					actions.Remove(actions[index--]);

			return true;
        }

    }
}
