using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters;

namespace Actions.Core
{
	/// <summary>
	/// Manager for action. Using for adding and removing action in runtime.
	/// </summary>
    public class ActionManager
    {
		/// <summary>
		/// List of all action.
		/// </summary>
		public List<GameAction> actions;
         
        public ActionManager()
        {
            actions = new List<GameAction>();
        }

		/// <summary>
		/// Using for adding new action to action pool.
		/// </summary>
		/// <param name="NewAction"> New action for action pool. </param>
		/// <returns> Return just added action. </returns>
        public GameAction Add(GameAction NewAction)
        {
            actions.Add(NewAction);
            return NewAction;
        }

		/// <summary>
		/// Using for getting action by name.
		/// </summary>
		/// <param name="Name"> Name action for search. </param>
		/// <returns> Action which finded. If not find any action return null. </returns>
        public GameAction GetActionsByName(string Name)
        {
            var query = actions.FindAll(o => o.Name == Name);
            return query.FirstOrDefault();
        }

		/// <summary>
		/// Remove action by name.
		/// </summary>
		/// <param name="Name"> Name for search. </param>
		/// <returns> 
		/// true: action removed.
		/// false: action not found.
		/// </returns>
        public bool RemoveByName(string Name)
        {
            actions.RemoveAll(o => o.Name == Name);
            return true;
        }

		/// <summary>
		/// Call every frame for updating action.
		/// </summary>
		/// <param name="Delta"> Time from last call. </param>
		/// <returns> </returns>
		public bool Update(float Delta)
        {
			//@todo: think about optimization
			for(int index = 0; index < actions.Count; index++)
				if(!actions[index].Upadate(Delta))
					actions.Remove(actions[index--]);

			return true;
        }

    }
}
