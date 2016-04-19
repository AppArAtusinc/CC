using Actions.Core;
using Entites;
using Entites.Common;
using SimpleGameTypes;
using StudentSimulator.SaveSystem;
using UnityEngine;

public class Walk : GameAction
{
    [Save]
	Link<NPC> NPC;

    [Save]
	SimpleVector3 Position;

    NavMeshAgent navAgent;

	public Walk()
	{
		
	}

	public Walk(NPC gameObject, Actor marker)
    {
        this.NPC = new Link<NPC>(gameObject.Id);
		this.Position = marker.Transform.Position;
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
        if (Vector3.Distance(this.navAgent.destination, this.NPC.Entity.Transform.Position) <= navAgent.stoppingDistance)
        {
            this.Finish();
        }
    }

    private void InternalStart()
    {
        this.navAgent = this.NPC.Entity.GameObject.GetComponent<NavMeshAgent>();

        if (this.navAgent)
        {
			this.navAgent.destination = this.Position;
        }
        else
        {
            this.Finish();
        }
    }
}
