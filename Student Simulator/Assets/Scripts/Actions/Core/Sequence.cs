using System;

namespace Actions.Core
{
	class Sequence : GameAction
	{
		GameAction[] actions;
		int index;
		public Sequence (params GameAction[] Actions)
		{
			actions = Actions;
			Reset();
		}

		public override void Reset ()
		{
			base.Reset();
			index = 0;
		}

		public override bool Upadate (float Delta)
		{
			if(index == actions.Length)
				return false;

			if(!actions[index].Upadate(Delta))
			{
				index++;
				if(index == actions.Length)
					return false;
				actions[index].Reset();
			}

			return true;
		}
	}
}

