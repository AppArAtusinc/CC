using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters;
using StudentSimulator.SaveSystem;
using Assets.Scripts.Quest.Common;

namespace Actions.Core
{
	/// <summary>
	/// Manager for action. Using for adding and removing action in runtime.
	/// </summary>
    public class ActionCollection
    {
        /// <summary>
        /// List of all action.
        /// </summary>
        [Save]
        public List<GameAction> Actions;
         
        public ActionCollection()
        {
            Actions = new List<GameAction>();
        }

		/// <summary>
		/// Using for adding new action to action pool.
		/// </summary>
		/// <param name="NewAction"> New action for action pool.</param>
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
		/// <returns> Action which finded. If not find any action return null.</returns>
        public GameAction GetActionsByName(string Name)
        {
            var query = Actions.FindAll(o => o.Name == Name);
            return query.FirstOrDefault();
        }

        public void Bind()
        {

           //new WalkTest().Start();
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
		/// <param name="delta"> Time from last call. </param>
		/// <returns> </returns>
		public bool Update(float delta)
        {
            //@todo: think about optimization
            for (int index = 0; index < Actions.Count; index++)
                Actions[index].Update(delta);

            return true;
        }

        public void Clear()
        {
            this.Actions.Clear();
        }
    }
}
