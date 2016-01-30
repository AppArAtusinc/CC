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
            Bind();
		}

        private void Bind()
        {
            actions[index].OnStopOrFinish += nextAction;
        }

        private void nextAction(GameAction action)
        {
            index++;
            if (index == actions.Count)
                index = 0;

            actions[index].Start();
        }

        /// <summary>
        /// Repeating sequence to start state.
        /// </summary>
        public override void Start ()
		{
			base.Start();
			actions[index].Stop();
			index = 0;
            actions[index].Start();
		}

        public override void Finish()
        {
            actions[index].Finish();
            base.Finish();
        }

        public override void Load()
        {
            base.Load();
            Bind();
        }

        public override bool Stop()
        {
            return base.Stop() && actions[index].Stop();
        }

        public override void Destroy()
        {
            foreach (var action in this.actions)
                action.Destroy();

            base.Destroy();
        }
    }
}

