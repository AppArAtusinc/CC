using StudentSimulator.SaveSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actions.Core
{
	/// <summary>
	/// Base class for all action.
	/// </summary>
    abstract public class GameAction
    {
		/// <summary>
		/// Get name of action.
		/// Many action can have equel name.
		/// </summary>
        [Save]
        public string Name
        {
            get;
            private set;
        }

		/// <summary>
		/// Using for setting name of action.
		/// </summary>
		/// <param name="Name"> New name for action. </param>
		/// <returns> Return this action. </returns>
		public GameAction SetName(string Name)
		{
			this.Name = Name;
			return this;
		}

		/// <summary>
		/// Call every frame for update action state
		/// </summary>
		/// <param name="Delta"> Time from last calling </param>
		/// <returns> 
		/// true: action still runnig
		///	false: action end his work
		/// </returns>
		public abstract bool Upadate(float Delta);

		/// <summary>
		/// Using for reset action to start state
		/// </summary>
		public virtual void Reset()
		{

		}

        public void Run()
        {
            Game.GetInstance().ActionManager.Add(this);
        }

        public static bool Stop(string ActionName)
        {
            return Game.GetInstance().ActionManager.RemoveByName(ActionName);
        }
    }
}
