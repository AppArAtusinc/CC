using System;

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
		public GameAction[] actions;
		/// <summary>
		/// Index of current running action.
		/// </summary>
		public int Index;
		/// <summary>
		/// Total count for repeating action sequence.
		/// </summary>
		public int RepeatCount;
		/// <summary>
		/// Current repeat count.
		/// </summary>
		public int CurrentRepeatCount;

		/// <summary>
		/// Create action sequence wich repeat only one time.
		/// </summary>
		/// <param name="Actions"> Action sequence. </param>
		public Repeat (params GameAction[] Actions)
		{
			actions = Actions;
		}
		
		/// <summary>
		/// Reset all action to start state.
		/// </summary>
		public override void Reset ()
		{
			base.Reset();
			Index = 0;
			CurrentRepeatCount = 0;
			actions[Index].Reset();
		}

		/// <summary>
		/// Set total repeat count.
		/// </summary>
		/// <param name="Count"> Value for repeat count. </param>
		/// <returns> Return this action. </returns>
		public Repeat SetRepeatCount(int Count)
		{
			RepeatCount = Count;
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
		public override bool Upadate (float Delta)
		{
			if(!actions[Index].Upadate(Delta))
			{
				Index++;
				if(Index == actions.Length)
				{
					Index = 0;
					CurrentRepeatCount++;
					if(CurrentRepeatCount == RepeatCount)
						return false;
				}
				actions[Index].Reset();
			}
			
			return true;
		}
	}
}

