using System;
using System.Collections.Generic;

namespace Actions.Core
{
	/// <summary>
	/// Using for creating action pool, where action will work parallel
	/// </summary>
	class Parallel : GameAction
	{
		/// <summary>
		/// Pool action for parallel processing
		/// </summary>
		public GameAction[] actions;
		/// <summary>
		/// Flags for each action. If true action is end it's work.
		/// </summary>
		public bool[] ended;

		/// <summary>
		/// Creating action with parallel action pool.
		/// </summary>
		/// <param name="Actions"> Actions for pool. </param>
		public Parallel (params GameAction[] Actions)
		{
			actions = Actions;
			ended = new bool[actions.Length];
		}

		/// <summary>
		/// Reset all action to start state.
		/// </summary>
		public override void Reset ()
		{
			for(int i = 0; i<actions.Length; i++)
			{
				actions[i].Reset();
				ended[i] = false;
			}
		}

		/// <summary>
		/// Calling each frame for updating action pool.
		/// </summary>
		/// <param name="Delta"> Time from last call. </param>
		/// <returns>
		/// true: not all action end it work.
		/// false: all action end it work.
		/// </returns>
		public override bool Upadate (float Delta)
		{
			bool ok = false;
			for(int i=0;i<ended.Length; i++)
				if(!ended[i])
				{
					ended[i] = !actions[i].Upadate(Delta);
					ok = true;
					continue;
				}
			return ok;
		}
	}
}

