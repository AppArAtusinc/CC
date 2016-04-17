using Actions.Core;
using Entites;
using Entites.Common;
using SimpleGameTypes;
using StudentSimulator.SaveSystem;
using UnityEngine;

public class Walk : GameAction
{
    [Save]
    Link<NPC> Target;

    [Save]
    SimpleVector3 Position;

    NavMeshAgent navAgent;

    public Walk(NPC gameObject, Vector3 position)
    {
        this.Target = new Link<NPC>(gameObject.Id);
        this.Position = new SimpleVector3(position);
    }

    public override void Start()
    {
        base.Start();

        this.InternalStart();
    }

    public override void Load()
    {
        if (this.IsRunning)
        {
            this.InternalStart();
        }
    }

    protected override void Tick(float delta)
    {
        if (Vector3.Distance(this.navAgent.destination, this.Target.Entity.Transform.Position) <= navAgent.stoppingDistance)
        {
            this.Finish();
        }
    }

    private void InternalStart()
    {
        this.navAgent = this.Target.Entity.GameObject.GetComponent<NavMeshAgent>();

        if (this.navAgent)
        {
            this.navAgent.destination = this.Position.ToVector3();
        }
        else
        {
            this.Finish();
        }
    }
}
