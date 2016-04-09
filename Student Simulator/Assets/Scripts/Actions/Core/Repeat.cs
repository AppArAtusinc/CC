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
        public List<GameAction> Actions;
        
        [Save]
        int index;

        /// <summary>
        /// Index of current running action.
        /// </summary>
        public int Index
        {
            get
            {
                return this.index;
            }
            set
            {
                UnBind();
                index = value;
                Bind();                
            }
        }

		/// <summary>
		/// Total count for repeating action sequence.
		/// </summary>
        [Save]
        public int RepeatCount;

		/// <summary>
		/// Current repeat count.
		/// </summary>
        [Save]
        public int CurrentRepeatCount;

        public Repeat() { }

		/// <summary>
		/// Create action sequence which repeat only one time.
		/// </summary>
		/// <param name="Actions"> Action sequence. </param>
		public Repeat (params GameAction[] Actions)
		{
			this.Actions = Actions.ToList();
            this.Actions.ForEach(o => o.IsNeedDestory = false);

            Index = CurrentRepeatCount = 0;
            RepeatCount = 1;
            Bind();
        }

        private void Bind()
        {
            if(Index < Actions.Count)
                Actions[Index].OnFinish += nextAction;
        }
        
        private void UnBind()
        {
            if(Index < Actions.Count)
                Actions[Index].OnFinish -= nextAction;
        }

        private void nextAction(GameAction action)
        {
            Index++;
            if (Index >= Actions.Count)
            {
                CurrentRepeatCount++;
                if (CurrentRepeatCount >= RepeatCount)
                {
                    Finish();
                    return;
                }
                Index = 0;
            }
            Actions[Index].Start();
        }

        /// <summary>
        /// Reset all action to start state.
        /// </summary>
        public override void Start ()
		{
			base.Start();
            Actions[Index].Stop();
			Index = CurrentRepeatCount = 0;
			Actions[Index].Start();
		}

        public override void Finish()
        {
            if(Index < Actions.Count)
                Actions[Index].Finish();
                
            base.Finish();
        }

        public override void Load()
        {
            base.Load();
            Bind();
        }

        public override bool Stop()
        {
            return base.Stop() && Actions[Index].Stop();
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

        public override void Destroy()
        {
            foreach (var action in this.Actions)
                action.Destroy();

            base.Destroy();
        }
    }
}

