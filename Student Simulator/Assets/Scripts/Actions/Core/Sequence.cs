using StudentSimulator.SaveSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Actions.Core
{

	/// <summary>
	/// Using for creating sequence from actions.
	/// </summary>
	public class Sequence : GameAction
	{
        /// <summary>
        /// Action sequence.
        /// </summary>
        [Save]
        public List<GameAction> Actions = new List<GameAction>();

		/// <summary>
		/// Index of action action.
		/// </summary>
        [Save]
        public int Index;

        public Sequence() { }

		/// <summary>
		/// Creating sequence from actions.
		/// </summary>
		/// <param name="Actions"> Actions for sequence. </param>
		public Sequence (params GameAction[] Actions)
		{
			this.Actions = Actions.ToList();
			Reset();
		}

		/// <summary>
		/// Reset action to start state.
		/// </summary>
		public override void Reset ()
		{
			base.Reset();
			Index = 0;
			if(Actions.Count != 0)
				Actions[Index].Reset();
		}

        /// <summary>
        /// Calling each frame for updating sequence.
        /// </summary>
        /// <param name="Delta"> Time bettwen two calls. </param>
        /// <returns>
        /// true: action active
        /// false: action finish work. 
        /// </returns>
        protected override bool Tick (float Delta)
		{
			if(Index == Actions.Count)
				return false;

			if(!Actions[Index].Update(Delta))
			{
				Index++;
				if(Index == Actions.Count)
					return false;
				Actions[Index].Reset();
			}

			return true;
		}
	}
}

