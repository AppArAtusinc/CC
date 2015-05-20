using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actions.Core
{
    class ActionManager
    {
<<<<<<< HEAD
		static public ActionManager Instanse;
        static List<GameAction> actions;
		static int index = 0;
         
        static ActionManager()
=======
        List<GameAction> actions;
		int index = 0;

		static Func<ActionManager> getter = () => 
		{ 
			instanse = new ActionManager(); 
			getter = null;
			getter = () => { return instanse; };
			return instanse;
		};	
		static ActionManager instanse;
		static public ActionManager Instanse 
		{
			get
			{
				return getter();
			}
		}

        ActionManager()
>>>>>>> origin/master
        {
            actions = new List<GameAction>();
			Instanse = this;
			
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
