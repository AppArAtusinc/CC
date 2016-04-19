using UnityEngine;
using Actions.Core;
using StudentSimulator.SaveSystem;
using Entites;

public class WalkSuspend : GameAction
{
    [Save]
    Link<NPC> npc;

    public WalkSuspend(NPC npc)
    {
        this.npc = new Link<NPC>(npc.Id);
    }


    public override void Start()
    {
        base.Start();
        this.InternalStart();
    }

    private void InternalStart()
    {
        Debug.Log("WalkSuspend started");

        NavMeshAgent navAgent = this.npc.Entity.GameObject.GetComponent<NavMeshAgent>();

        if (navAgent)
        {
            navAgent.Stop();
            Debug.Log("WalkSuspend STOP");
        }

        this.Finish();

        Debug.Log("WalkSuspend finished");
    }
}
