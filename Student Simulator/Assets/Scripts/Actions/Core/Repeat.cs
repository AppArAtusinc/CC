using StudentSimulator.SaveSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Actions.Core
{
	/// <summary>
	/// Using for creating action sequence which can repeat some times.
	/// </summary>
	class Repeat : GameAction
	{
		/// <summary>
		/// Action sequence.
		/// </summary>
        [Save]
        List<GameAction> actions;

		/// <summary>
		/// Index of current running action.
		/// </summary>
        [Save]
        int index;

		/// <summary>
		/// Total count for repeating action sequence.
		/// </summary>
        [Save]
        int repeatCount;

		/// <summary>
		/// Current repeat count.
		/// </summary>
        [Save]
        int currentRepeatCount;

        public Repeat() { }

		/// <summary>
		/// Create action sequence wich repeat only one time.
		/// </summary>
		/// <param name="Actions"> Action sequence. </param>
		public Repeat (params GameAction[] Actions)
		{
			actions = Actions.ToList();
		}
		
		/// <summary>
		/// Reset all action to start state.
		/// </summary>
		public override void Reset ()
		{
			base.Reset();
			index = 0;
			currentRepeatCount = 0;
			actions[index].Reset();
		}

		/// <summary>
		/// Set total repeat count.
		/// </summary>
		/// <param name="Count"> Value for repeat count. </param>
		/// <returns> Return this action. </returns>
		public Repeat SetRepeatCount(int Count)
		{
			repeatCount = Count;
			return this;
		}

        /// <summary>
        /// Calling each frame, update action sequence.
        /// </summary>
        /// <param name="Delta"> Time bettwen two calls. </param>
        /// <returns>
        /// true: still running
        /// false: finish running
        /// </returns>
        protected override bool Tick (float Delta)
		{
			if(!actions[index].Update(Delta))
			{
				index++;
				if(index == actions.Count)
				{
					index = 0;
					currentRepeatCount++;
					if(currentRepeatCount == repeatCount)
						return false;
				}
				actions[index].Reset();
			}
			
			return true;
		}
	}
}

