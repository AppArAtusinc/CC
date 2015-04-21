using System;

namespace Actions.Core
{
	class Sequense : GameAction
	{
		GameAction[] actions;
		int repeatCount;
		int index;
	
		public Sequense (params GameAction[] Actions)
		{
			actions = Actions;
			index = 0;
			repeatCount = 1;


			foreach (var action in actions)
				action.OnEnd += onInnerActionEnd;
		}

		public override void Upadate (float Delta)
		{
			actions[index].Upadate(Delta);
		}

		public Sequense Repeat(int Count)
		{
			if(Count < 1)
				return this;

			repeatCount = Count;

			return this;
		}

		public Sequense RepeatForever()
		{
			repeatCount = -1;
			return this;
		}

		void onInnerActionEnd(GameAction Action)
		{
			index++;
			if( index == actions.Length )
			{
				if(repeatCount == -1)
				{
					index = 0;
					return;
				}

				repeatCount--;
				if(repeatCount > 0)
					index = 0;
				else
					OnEnd(this);
					
			}
		}



	}
}

