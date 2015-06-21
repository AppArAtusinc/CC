using System;

namespace Actions.Core
{

	/// <summary>
	/// Using for creating sequence from actions.
	/// </summary>
	class Sequence : GameAction
	{
		/// <summary>
		/// Action sequence.
		/// </summary>
		public GameAction[] Actions;
		/// <summary>
		/// Index of action action.
		/// </summary>
		public int Index;
		/// <summary>
		/// Creating sequence from actions.
		/// </summary>
		/// <param name="Actions"> Actions for sequence. </param>
		public Sequence (params GameAction[] Actions)
		{
			this.Actions = Actions;
			Reset();
		}

		/// <summary>
		/// Reset action to start state.
		/// </summary>
		public override void Reset ()
		{
			base.Reset();
			Index = 0;
			if(Actions.Length != 0)
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
		public override bool Upadate (float Delta)
		{
			if(Index == Actions.Length)
				return false;

			if(!Actions[Index].Upadate(Delta))
			{
				Index++;
				if(Index == Actions.Length)
					return false;
				Actions[Index].Reset();
			}

			return true;
		}
	}
}

