using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actions.Core
{
    abstract public class GameAction
    {
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

        public abstract bool Upadate(float Delta);
		public virtual void Reset()
		{

		}

    }
}
