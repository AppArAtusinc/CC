using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Actions.Core;


namespace Actions
{
    public class Replace : GameAction
    {
		public GameObject target;
		public Vector3 newPosition;

        public Replace(GameObject Target, Vector3 NewPosition)
        {
            target = Target;
            newPosition = NewPosition;
        }

		public override bool Upadate(float Delta)
        {
			target.transform.position = newPosition;
			return false;
        }
    }
}
