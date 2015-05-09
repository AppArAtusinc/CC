using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using Actions.Core;


namespace Actions
{
	class FlyTo : GameAction
	{
		Transform target;
		float speed;
		Vector3 endPosition, direction;
		
		
		public FlyTo(GameObject Target, Vector3 EndPosition, float Speed)
		{
			target = Target.transform;
			speed = Speed;
			endPosition = EndPosition;
		}
		
		public override void Upadate(float Delta)
		{
			if(Vector3.Distance(target.position, endPosition) > 0.5)
			{
				direction = endPosition - target.position;
				target.position =  target.position + (direction.normalized * speed) * Delta;
			}
			else
				OnEnd(this);
		}
	}
}

