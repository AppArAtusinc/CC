using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using Actions.Core;


namespace Actions
{
	public class Drag : GameAction
	{
		Transform senderTransform;
		Transform targetTransform;
		Rigidbody targetRigibBody;

		Vector3 direction;

		float impulse;
		
		public Drag(GameObject Sender, GameObject Target, float Impulse)
		{
			senderTransform = Sender.transform;
			targetTransform = Target.transform;
			impulse = Impulse;

			targetRigibBody = Target.GetComponent<Rigidbody>();
		}

		public override bool Upadate(float Delta)
		{
			direction = senderTransform.position - targetRigibBody.position;
			targetRigibBody.AddForce(direction.normalized * impulse, ForceMode.Impulse);
			return false;
		}
	}
}
