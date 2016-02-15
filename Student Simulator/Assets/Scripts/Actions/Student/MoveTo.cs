using Actions.Core;
using Entites;
using Entites.Common;
using SimpleGameTypes;
using StudentSimulator.SaveSystem;
using UnityEngine;

class MoveTo : GameAction
{
    [Save]
    Link<Actor> Target;

    [Save]
    SimpleVector3 Position;

    float LeftTime
    {
        get
        {
            return Vector3.Distance(Target.Entity.GameObject.transform.position, Position) / Speed;
        }

    }

    [Save]
    float Speed;

    public MoveTo()
    {
    }

    public MoveTo(GameObject Target, Vector3 Position, float speed)
    {
        this.Target = new Link<Actor>(Target.GetEntityId());
        this.Position = new SimpleVector3(Position);
        Speed = speed;
    }

    public override void Start()
    {
        base.Start();
    }

    protected override void Tick(float delta)
    {
        var transform = Target.Entity.GameObject.transform;
        var distance = Vector3.Distance(transform.position, Position);
        var entityPosition = transform.position;

        var frameSpeed = Speed * delta;

        if (distance < frameSpeed)
        {
            transform.position = Position;
            Finish();
        }
        else
        {
            transform.position = entityPosition + (Position - entityPosition).normalized * frameSpeed;
        }
    }
}
