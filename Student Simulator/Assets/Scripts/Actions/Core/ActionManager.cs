﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actions.Core
{
    class ActionManager
    {
        List<GameAction> actions;
		int index = 0;

		static ActionManager instanse;
		static public ActionManager Instanse 
		{
			get
			{
				return instanse;
			}
		}
         
		static public void Init()
		{
			instanse = new ActionManager();
		}

        ActionManager()
        {
            actions = new List<GameAction>();
        }

        public GameAction Add(GameAction NewAction)
        {
            actions.Add(NewAction);
            return NewAction;
        }

        public GameAction GetActionsByName(string Name)
        {
            var query = actions.FindAll(o => o.Name == Name);
            return query.FirstOrDefault();
        }

        public bool RemoveByName(string Name)
        {
            actions.RemoveAll(o => o.Name == Name);
            return true;
        }

		public bool Update(float Delta)
        {
			//@todo: think about optimization
			for(index = 0; index < actions.Count; index++)
				if(!actions[index].Upadate(Delta))
					actions.Remove(actions[index--]);

			return true;
        }

    }
}
