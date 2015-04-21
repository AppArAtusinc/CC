using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using Actions.Core;


namespace Actions
{
    class MoveTo : GameAction
    {
        GameObject target;
        Vector3 newPosition;

        public MoveTo(GameObject Target, Vector3 NewPosition)
        {
            target = Target;
            newPosition = NewPosition;
        }


        public override void Upadate(float Delta)
        {
			target.transform.position = newPosition;
            OnEnd(this);
        }
    }
}
