using Actions.Core;
using StudentSimulator.SaveSystem;
using System;

namespace Quest.Common.Core
{
    public class Quest : GameAction
    {
        [Save]
        public GameAction Entry { get; set; }

        public override void Start()
        {
            if (Entry != null)
            {
                this.Entry.OnFinish += finish;
                this.Entry.Start();
                base.Start();
                Game.Instance.QuestCollection.Start(this);
            }
            else
            {
                this.Finish();
                throw new InvalidOperationException("All quest should have a entry game action.");
            }

        }

        private void finish(GameAction action)
        {
            this.Finish();
        }

        public override void Load()
        {
            this.Entry.OnFinish += finish;
        }

        protected Quest()
        {

        }

        public Quest(string name)
        {
            this.Name = name;
        }
    }
}
