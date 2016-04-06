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

    [Save]
    bool isMoving = false;

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
        base.Tick(delta);

        if (this.navAgent.velocity.sqrMagnitude == 0.0f && this.isMoving)
        {            
            this.Finish();
            this.isMoving = false;
        }
        else
        {
            this.isMoving = true;
        }
    }

    private void InternalStart()
    {
        this.navAgent = this.Target.Entity.GameObject.GetComponent<NavMeshAgent>();
        this.navAgent.velocity = Vector3.zero;

        if (this.navAgent)
        {
            this.navAgent.SetDestination(this.Position.ToVector3());
        }
        else
        {
            this.OnFinish(this);
        }
    }
}
