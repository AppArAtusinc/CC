using Actions.Core;
using Entites;
using Entites.Common;
using SimpleGameTypes;
using StudentSimulator.SaveSystem;
using UnityEngine;


public class Stay : GameAction
{
    public bool EndStandby
    {
        get
        {
            return this.endStandby;
        }

        set
        {
            this.endStandby = value;
        }
    }

    [Save]
    Link<NPC> Target;

    [Save]
    bool endStandby = false;

    NavMeshAgent navAgent;

    public Stay(NPC gameObject)
    {
        this.Target = new Link<NPC>(gameObject.Id);
        this.EndStandby = false;
    }

    public override void Start()
    {
        base.Start();

        this.InternalStay();
    }

    public override void Load()
    {
        if (this.IsRunning)
        {
            this.InternalStay();
        }
    }

    protected override void Tick(float delta)
    {
        base.Tick(delta);

        if (this.endStandby)
        {
            this.Finish();
        }
    }

    private void InternalStay()
    {
        this.navAgent = this.Target.Entity.GameObject.GetComponent<NavMeshAgent>();
        this.navAgent.velocity = Vector3.zero;

        if (this.navAgent)
        {
            this.navAgent.Stop();
        }
        else
        {
            this.OnFinish(this);
        }
    }
}
