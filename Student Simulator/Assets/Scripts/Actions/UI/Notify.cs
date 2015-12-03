using Actions.Core;
using StudentSimulator.SaveSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Actions.UI
{
    public class Notify : GameAction
    {
        [Save]
        string message;

        public Notify(string message)
        {
            this.message = message;
        }

        protected override bool Tick(float Delta)
        {
            Debug.Log(message);
            return false;
        }
    }
}
