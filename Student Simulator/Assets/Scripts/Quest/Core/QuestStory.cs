﻿using Actions.Core;
using StudentSimulator.SaveSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quest.Core
{
    public abstract class QuestStory : Sequence
    {
        public string Name
        {
            get
            {
                return this.GetType().FullName;
            }
        }

        [Save]
        public bool Active;

        protected T Add<T>(T action) where T : GameAction
        {
            Actions.Add(action);
            return action;
        }
    }
}
