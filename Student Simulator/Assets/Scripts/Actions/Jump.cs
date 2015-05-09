using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using Actions.Core;


namespace Actions
{
	class Jump : GameAction
	{
		GameObject target;
		float impulse;
		
		public Jump(GameObject Target, float Impulse)
		{
			target = Target;
			impulse = Impulse;
		}

		public override void Upadate(float Delta)
		{
			var rigidBody = target.GetComponent<Rigidbody>();
			if(rigidBody != null)
				rigidBody.AddForce(target.transform.up * impulse, ForceMode.Impulse);

			OnEnd(this);
		}
	}
}
