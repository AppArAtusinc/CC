using Actions.Core;
using StudentSimulator.SaveSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quest.Core
{
    public abstract class QuestPoint : GameAction
    {
        public delegate void QuestDoneDelegate(QuestPoint quest);
        public QuestDoneDelegate OnDone;

        [Save]
        public bool Active
        {
            get;
            set;
        }

        public override void Reset()
        {
            this.Active = true;
            base.Reset();
        }

        public void Done()
        {
            if(OnDone != null)
                OnDone(this);

            this.Active = false;
        }

        protected override bool Tick(float Delta)
        {
            return Active;
        }
    }
}
