
using StudentSimulator.SaveSystem;
using System;
using System.Collections.Generic;

namespace Actions.Core
{
	class ActionContainer : GameAction
	{
        [Save]
		protected List<GameAction> actions;

		public ActionContainer()
		{
			actions = new List<GameAction>();
		}

		public ActionContainer(params GameAction[] Actions)
		{
			actions = new List<GameAction>(Actions);
		}

		public void Add(GameAction Action)
		{
			actions.Add(Action);
		}

		public void Remove(GameAction Action)
		{
			actions.Remove(Action);
		}

		public void Remove(String Name)
		{
			var action = actions.Find(o => o.Name == Name);
			if(action != null)
				actions.Remove(action);
		}

		public GameAction Get(String Name)
		{
			return actions.Find(o => o.Name == Name);
		}

		public override void Reset ()
		{
			foreach(GameAction action in actions)
				action.Reset();
		}

		public override bool Upadate (float Delta)
		{
			foreach(GameAction action in actions)
				action.Upadate(Delta);

			return true;
		}
	}
}

