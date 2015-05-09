using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actions.Core
{
    abstract class GameAction
    {
        public delegate void OnBeginActionCallback();
        public delegate void OnEndActionCallback(GameAction Sender);

        public OnBeginActionCallback OnBegin;
        public OnEndActionCallback OnEnd;

        public string Name
        {
            get;
            private set;
        }

		public GameAction SetName(string Name)
		{
			this.Name = Name;
			return this;
		}

        public abstract void Upadate(float Delta);
		public virtual void Reset()
		{

		}

    }
}
