using System;

namespace Actions.Core
{

	class CallFunction: GameAction
	{
		public Action function;
		public CallFunction(Action Function)
		{
			function = Function;
		}

		public override bool Upadate (float Delta)
		{
			function();
			return false;
		}
	}

}