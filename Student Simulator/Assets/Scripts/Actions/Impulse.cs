using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using Actions.Core;


namespace Actions
{
	public class Impulse : GameAction
	{
		Rigidbody target;
		float impulse;
		Vector3 direction;


		public Impulse(GameObject Target, Vector3 Direction, float Impulse)
		{
			target = Target.GetComponent<Rigidbody>();
			direction = Direction;
			impulse = Impulse;
		}
		
		public override bool Upadate(float Delta)
		{
			target.AddForce(direction * impulse, ForceMode.Impulse);
			return false;
		}
	}
}

