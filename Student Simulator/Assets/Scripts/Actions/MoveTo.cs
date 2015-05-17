using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using Actions.Core;


namespace Actions
{
	public class MoveTo : GameAction
	{
		Transform target;
		float speed;
		float duration;
		Vector3 endPosition, direction;
		
		
		public MoveTo(GameObject Target, Vector3 EndPosition)
		{
			target = Target.transform;
			endPosition = EndPosition;
			speed = 0;
		}

		public override void Reset ()
		{
			SetDuration(duration);
		}

		public MoveTo SetDuration(float Duration)
		{
			duration = Duration;
			var d = Vector3.Distance(target.position, endPosition);
			speed =  d / Duration;
			return this;
		}

		public override bool Upadate(float Delta)
		{
			direction = (endPosition - target.position).normalized;
			float step = (speed * Delta);
			if(Vector3.Distance(target.position, endPosition) > step)
				target.position = (target.position + (direction * step));
			else
			{
				target.position = endPosition;
				return false;
			}
			return true;
		}
	}
}

