using Actions.Core;
using Entity;
using SimpleGameTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class MoveTo : GameAction
{
    public LinkToGameEntity Target;
    public SimpleVector3 Position;

    public float Duration;
    public float SpeedPerSecond;

    public MoveTo() { 
		Debug.Log ("from MoveTo");
	}
    public MoveTo(GameObject Target, Vector3 Position)
    {
        this.Target = new LinkToGameEntity(Target.GetEntityId());
        this.Position = new SimpleVector3(Position);
    }

    public override void Reset()
    {
        SetDuration(Duration);
    }

    public GameAction SetDuration(float Value)
    {
        Duration = Value;
        SpeedPerSecond = Vector3.Distance(Target.GetEntity().GetGameObject().transform.position, Position) / Duration;

        return this;
    }

    public override bool Upadate(float Delta)
    {
        var transform = Target.GetEntity().GetGameObject().transform;
        var distance = Vector3.Distance(transform.position, Position);
        var entityPosition = transform.position;

        var frameSpeed = SpeedPerSecond * Delta;

        if (distance < frameSpeed)
        {
            transform.position = Position;
            return false;
        }
        else
        {
            transform.position = entityPosition + (Position - entityPosition).normalized * frameSpeed;
            return true;
        }

    }
}
