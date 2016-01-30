using StudentSimulator.SaveSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Actions.Core
{
	/// <summary>
	/// Using for creating action pool, where action will work parallel.
    /// When first action finish work, than all other stop they work.
	/// </summary>
    /// <owner>Stanislav Silin</owner>
	class Parallel : GameAction
    {
		/// <summary>
		/// Pool action for parallel processing
		/// </summary>
        /// <owner>Stanislav Silin</owner>
        [Save]
        public GameAction[] Actions;


        public Parallel() { }

        /// <summary>
        /// Creating action with parallel action pool.
        /// </summary>
        /// <owner>Stanislav Silin</owner>
        /// <param name="Actions"> Actions for pool. </param>
        public Parallel (params GameAction[] Actions)
		{
			this.Actions = Actions;
            this.Bind();
		}

        void Bind()
        {
            foreach (var action in Actions)
                action.OnFinish += Done;
        }

        private void Done(GameAction action)
        {
            Finish();
        }

        public override void Load()
        {
            base.Load();
            Bind();
        }
        
        /// <summary>
        /// Reset all action to start state.
        /// </summary>
        /// <owner>Stanislav Silin</owner>
        public override void Start ()
        {
            base.Start();
            foreach (var action in this.Actions)
                action.Start();
		}

        public override bool Stop()
        {
            foreach (var action in this.Actions)
                action.Stop();

            return Actions.All(o => !o.IsRunning) && base.Stop();
        }

        public override void Finish()
        {
            foreach (var action in this.Actions)
            {
                action.OnFinish -= Done;
                action.Finish();
            }

            base.Finish();
        }

        public override void Destroy()
        {
            foreach (var action in this.Actions)
                action.Destroy();

            base.Destroy();
        }
    }
}

