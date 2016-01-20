using Actions.Core;
using Entity;
using SimpleGameTypes;
using StudentSimulator.SaveSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class MoveTo : GameAction
{
    [Save]
    LinkToGameEntity<Actor> Target;

    [Save]
    SimpleVector3 Position;

    [Save]
    float Duration;

    [Save]
    float SpeedPerSecond;

    public MoveTo()
    {
    }

    public MoveTo(GameObject Target, Vector3 Position)
    {
        this.Target = new LinkToGameEntity<Actor>(Target.GetEntityId());
        this.Position = new SimpleVector3(Position);
    }

    public override void Reset()
    {
        base.Reset();
        SetDuration(Duration);
    }

    public GameAction SetDuration(float Value)
    {
        Duration = Value;
        SpeedPerSecond = Vector3.Distance(Target.Entity.GameObject.transform.position, Position) / Duration;

        return this;
    }

    protected override bool Tick(float Delta)
    {
        var transform = Target.Entity.GameObject.transform;
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
