using StudentSimulator.SaveSystem;
using System;
using System.Collections.Generic;
using System.Linq;

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
        [Save]
        List<GameAction> actions;

		/// <summary>
		/// Index of current running action.
		/// </summary>
        [Save]
        int index;

		/// <summary>
		/// Total count for repeating action sequence.
		/// </summary>
        [Save]
        int repeatCount;

		/// <summary>
		/// Current repeat count.
		/// </summary>
        [Save]
        int currentRepeatCount;

        public Repeat() { }

		/// <summary>
		/// Create action sequence which repeat only one time.
		/// </summary>
		/// <param name="Actions"> Action sequence. </param>
		public Repeat (params GameAction[] Actions)
		{
			actions = Actions.ToList();
            index = currentRepeatCount = 0;
            repeatCount = 1;
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
            {
                currentRepeatCount++;
                if (currentRepeatCount == repeatCount)
                {
                    Finish();
                    return;
                }
                index = 0;
            }
            actions[index].Start();
        }

        /// <summary>
        /// Reset all action to start state.
        /// </summary>
        public override void Start ()
		{
			base.Start();
            actions[index].Stop();
			index = currentRepeatCount = 0;
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

        /// <summary>
        /// Set total repeat count.
        /// </summary>
        /// <param name="Count"> Value for repeat count. </param>
        /// <returns> Return this action. </returns>
        public Repeat SetRepeatCount(int Count)
		{
			repeatCount = Count;
			return this;
		}

        public override void Destroy()
        {
            foreach (var action in this.actions)
                action.Destroy();

            base.Destroy();
        }
    }
}

