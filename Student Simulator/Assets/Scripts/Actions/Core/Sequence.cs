using StudentSimulator.SaveSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Actions.Core
{

    /// <summary>
    /// Using for creating sequence from actions.
    /// </summary>
    public class Sequence : GameAction
    {
        /// <summary>
        /// Action sequence.
        /// </summary>
        [Save]
        public List<GameAction> Actions;

        [Save]
        int index;
        /// <summary>
        /// Index of action.
        /// </summary>
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

        public Sequence()
        {
        }

        /// <summary>
        /// Creating sequence from actions.
        /// </summary>
        /// <param name="Actions"> Actions for sequence. </param>
        public Sequence(params GameAction[] Actions)
        {
            this.Actions = Actions.ToList();
            Start();
            Bind();
        }

        private void Bind()
        {
            if (Index < Actions.Count)
                Actions[Index].OnFinish += nextAction;
        }

        private void UnBind()
        {
            if (Index < Actions.Count)
                Actions[Index].OnFinish -= nextAction;
        }

        private void nextAction(GameAction action)
        {
            Index++;
            if (this.Index == Actions.Count)
            {
                Finish();
                return;
            }
            Actions[Index].Start();
        }

        /// <summary>
        /// Reset action to start state.
        /// </summary>
        public override void Start()
        {
            base.Start();
            Actions[Index].Stop();
            Index = 0;
            Actions[Index].Start();
        }

        public override void Finish()
        {
            if (Index < Actions.Count)
            {
                Actions[Index].OnFinish -= nextAction;
                Actions[Index].Finish();
            }
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

        public override void Destroy()
        {
            foreach (var action in this.Actions)
                action.Destroy();

            base.Destroy();
        }

    }
}

