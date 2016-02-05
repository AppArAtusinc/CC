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

        public int Index
        {
            get
            {
                return index;
            }
            set
            {
                UnBind();
                index = value;
                Bind();
            }
        }

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
            if(index < actions.Count)
                actions[index].OnStopOrFinish += nextAction;
        }

        private void UnBind()
        {
            if(index < actions.Count)
                actions[index].OnStopOrFinish -= nextAction;
        }

        private void nextAction(GameAction action)
        {
            Index++;
            if (Index >= actions.Count)
                Index = 0;

            actions[Index].Start();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Start ()
		{
			base.Start();
			actions[Index].Stop();
            Index = 0;
            actions[Index].Start();
		}

        public override void Finish()
        {
            actions[Index].Finish();
            base.Finish();
        }

        public override void Load()
        {
            base.Load();
            Bind();
        }

        public override bool Stop()
        {
            return base.Stop() && actions[Index].Stop();
        }

        public override void Destroy()
        {
            foreach (var action in this.actions)
                action.Destroy();

            base.Destroy();
        }
    }
}

