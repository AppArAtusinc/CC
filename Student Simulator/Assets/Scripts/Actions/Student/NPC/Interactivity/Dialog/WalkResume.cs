using UnityEngine;
using System.Collections;
using Actions.Core;
using StudentSimulator.SaveSystem;
using Entites;

public class WalkResume : GameAction
{
    [Save]
    Link<NPC> npc;

    public WalkResume(NPC npc)
    {
        this.npc = new Link<NPC>(npc.Id);
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

    private void InternalStart()
    {
        Debug.Log("WalkResume started");

        NavMeshAgent navAgent = this.npc.Entity.GameObject.GetComponent<NavMeshAgent>();

        if (navAgent)
        {
            navAgent.Resume();
        }

        this.Finish();

        Debug.Log("WalkResume finished");
    }
}
