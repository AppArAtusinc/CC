using System;

namespace Actions.Core
{
	class Sequense : GameAction
	{
		enum SequenseType
		{
			RepeatN,
			RepeatForever
		};

		GameAction[] actions;
		SequenseType sequenseType;
		int startCount, repeatCount, index;
	
		public Sequense (params GameAction[] Actions)
		{
			actions = Actions;
			sequenseType = SequenseType.RepeatN;
			startCount = 1;
			index = 0;

			foreach (var action in actions)
				action.OnEnd += onInnerActionEnd;
		}

		public override void Reset ()
		{
			index = 0;
			repeatCount = 0;
			resetActions();
		}

		public override void Upadate (float Delta)
		{
			actions[index].Upadate(Delta);
		}

		public Sequense Repeat(int Count)
		{
			sequenseType = SequenseType.RepeatN;
			startCount = Count;
			return this;
		}

		public Sequense RepeatForever()
		{
			sequenseType = SequenseType.RepeatForever;
			return this;
		}

		void resetActions()
		{
			foreach(var action in actions)
				action.Reset();
		}

		void onInnerActionEnd(GameAction Action)
		{
			index++;

			switch (sequenseType)
			{
			case SequenseType.RepeatForever:
				if(index == actions.Length)
				{
					index = 0;
					resetActions();
				}
				break;
			case SequenseType.RepeatN:
				if(index == actions.Length)
				{
					index = 0;
					repeatCount++;
					resetActions();
				}

				if(repeatCount == startCount)
				{
					OnEnd(this);
				}
				break;
			}
		}



	}
}

