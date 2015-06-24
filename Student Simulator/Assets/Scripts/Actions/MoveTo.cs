using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using Actions.Core;
using SimpleGameTypes;
using Entity;


namespace Actions
{
	public class MoveTo : GameAction
	{
		public LinkToGameEntity Entity;
		
		public float Duration;		
		public float Speed;

		public SimpleVector3 FinishPosition
		{
			get { return new SimpleVector3(endPosition);}
			set 
			{ 
				endPosition = value.ToVector3();
			}
		}
		Vector3 direction, endPosition;

		Transform transform;
		Transform Transform
		{
			get
			{
				if (Entity.IsValid())
					return transform;

				if(Entity.Link())
					transform = Entity.GetValue().GetGameObject().transform;
				return transform;
			}
		}

		public MoveTo()
		{

		}
		
		public MoveTo(GameObject Target, Vector3 EndPosition)
		{
			Entity = new LinkToGameEntity();
			Entity.Id = GameInformation.GetId(Target);
			FinishPosition = new SimpleVector3 (EndPosition);

			Speed = 0;
			Reset();
		}

		public override void Reset ()
		{
			SetDuration(Duration);
		}

		public MoveTo SetDuration(float Duration)
		{
			this.Duration = Duration;
			var d = Vector3.Distance(Transform.position, endPosition);
			Speed =  d / Duration;
			return this;
		}

		public override bool Upadate(float Delta)
		{
			direction = (endPosition - Transform.position).normalized;
			float step = (Speed * Delta);
			if (Vector3.Distance(Transform.position, endPosition) > step)
				Transform.position = (Transform.position + (direction * step));
			else
			{
				Transform.position = endPosition;
				return false;
			}
			return true;
		}
	}
}

