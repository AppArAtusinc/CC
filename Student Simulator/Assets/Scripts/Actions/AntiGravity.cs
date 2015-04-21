using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using Actions.Core;


namespace Actions
{
	class AntiGravity : GameAction
	{
		GameObject target;
		float impulse;
		
		public AntiGravity(GameObject Target, float Impulse)
		{
			target = Target;
			impulse = Impulse;
		}
		
		
		public override void Upadate(float Delta)
		{
			var rigidBody = target.GetComponent<Rigidbody>();
			if(rigidBody != null)
				rigidBody.AddForce(Physics.gravity * -impulse, ForceMode.Acceleration);
			
			OnEnd(this);
		}
	}
}
