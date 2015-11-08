using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters;
using StudentSimulator.SaveSystem;

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
        [Save]
		public List<GameAction> Actions;
         
        public ActionManager()
        {
            Actions = new List<GameAction>();
        }

		/// <summary>
		/// Using for adding new action to action pool.
		/// </summary>
		/// <param name="NewAction"> New action for action pool. </param>
		/// <returns> Return just added action. </returns>
        public GameAction Add(GameAction NewAction)
        {
            Actions.Add(NewAction);
            return NewAction;
        }

		/// <summary>
		/// Using for getting action by name.
		/// </summary>
		/// <param name="Name"> Name action for search. </param>
		/// <returns> Action which finded. If not find any action return null. </returns>
        public GameAction GetActionsByName(string Name)
        {
            var query = Actions.FindAll(o => o.Name == Name);
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
            return Actions.RemoveAll(o => o.Name == Name) > 0;
        }

		/// <summary>
		/// Call every frame for updating action.
		/// </summary>
		/// <param name="Delta"> Time from last call. </param>
		/// <returns> </returns>
		public bool Update(float Delta)
        {
			//@todo: think about optimization
			for(int index = 0; index < Actions.Count; index++)
				if(!Actions[index].Update(Delta))
					Actions.Remove(Actions[index--]);

			return true;
        }

    }
}
