using StudentSimulator.SaveSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Actions.Core
{

	/// <summary>
	/// Use for repeating sequence forever.
	/// </summary>
	class RepeatForever : GameAction
	{
		/// <summary>
		/// Sequence for repeating
		/// </summary>
        [Save]
        List<GameAction> actions;

		/// <summary>
		/// Index of active action.
		/// </summary>
        [Save]
        int index;

        public RepeatForever() { }

		/// <summary>
		/// Creating sequence which repeating forever.
		/// </summary>
		/// <param name="Actions"> Sequence for repeating. </param>
		public RepeatForever (params GameAction[] Actions)
		{
			this.actions = Actions.ToList();
		}
		
		/// <summary>
		/// Repeeating sequence to start state.
		/// </summary>
		public override void Reset ()
		{
			base.Reset();
			index = 0;
			actions[index].Reset();
		}

		/// <summary>
		/// Calling each frame for updating action in sequence.
		/// </summary>
		/// <param name="Delta"> Time bettwen two calls. </param>
		/// <returns></returns>
		public override bool Upadate (float Delta)
		{
			if(!actions[index].Upadate(Delta))
			{
				index++;
				if(index == actions.Count)
					index = 0;
				actions[index].Reset();
			}
			
			return true;
		}
	}
}

