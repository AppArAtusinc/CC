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
        /// Emit on action start
        /// </summary>
        [Save]
        List<GameAction> onStartActions = new List<GameAction>();

        /// <summary>
        /// Emit on action end
        /// </summary>
        [Save]
        List<GameAction> onFinishActions = new List<GameAction>();


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

        public bool Update(float Delta)
        {
            bool result = Tick(Delta);

            if (!result && onFinishActions != null)
                onFinishActions.ForEach(o => o.Run());

            return result;
        }


        /// <summary>
        /// Use for initialize action after loading operation;
        /// </summary>
        public virtual void Init()
        {

        }

		/// <summary>
		/// Call every frame for update action state
		/// </summary>
		/// <param name="Delta"> Time from last calling </param>
		/// <returns> 
		/// true: action still runnig
		///	false: action end his work
		/// </returns>
		protected abstract bool Tick(float Delta);

		/// <summary>
		/// Using for reset action to start state
		/// </summary>
		public virtual void Reset()
		{
            if (onStartActions != null)
                onStartActions.ForEach(o => o.Run());
		}

        public void Run()
        {
            Game.GetInstance().ActionManager.Add(this);
        }

        public GameAction AddOnStartAction(GameAction OnStartAction)
        {
            onStartActions.Add(OnStartAction);
            return this;
        }

        public GameAction AddOnFinish(GameAction OnFinishAction)
        {
            onFinishActions.Add(OnFinishAction);
            return this;
        }

        public static bool Stop(string ActionName)
        {
            return Game.GetInstance().ActionManager.RemoveByName(ActionName);
        }
    }
}
