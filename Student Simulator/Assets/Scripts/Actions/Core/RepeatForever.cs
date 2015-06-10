using System;

namespace Actions.Core
{

	/// <summary>
	/// Usse for repeating sequence forever.
	/// </summary>
	class RepeatForever : GameAction
	{
		/// <summary>
		/// Sequence for repeating
		/// </summary>
		public GameAction[] Actions;
		/// <summary>
		/// Index of active action.
		/// </summary>
		public int Index;
		
		/// <summary>
		/// Creating sequence which repeating forever.
		/// </summary>
		/// <param name="Actions"> Sequence for repeating. </param>
		public RepeatForever (params GameAction[] Actions)
		{
			Actions = Actions;
			Reset();
		}
		
		/// <summary>
		/// Repeeating sequence to start state.
		/// </summary>
		public override void Reset ()
		{
			base.Reset();
			Index = 0;
			Actions[Index].Reset();
		}

		/// <summary>
		/// Calling each frame for updating action in sequence.
		/// </summary>
		/// <param name="Delta"> Time bettwen two calls. </param>
		/// <returns></returns>
		public override bool Upadate (float Delta)
		{
			if(!Actions[Index].Upadate(Delta))
			{
				Index++;
				if(Index == Actions.Length)
					Index = 0;
				Actions[Index].Reset();
			}
			
			return true;
		}
	}
}

