using UnityEngine;
using Actions.Core;
using StudentSimulator.SaveSystem;
using Entites;

public class StayAndLookAt : GameAction
{
    [Save]
    Link<NPC> npc;

    [Save]
    Transform playerTransform;

    NavMeshAgent navAgent;

    public StayAndLookAt(NPC npc, Transform playerTransform)
    {
        this.npc = new Link<NPC>(npc.Id);
        this.playerTransform = playerTransform;
    }

    // Use this for initialization
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
        //var playerPosition = this.playerTransform.forward;
        //var npcPosition = this.npc.Entity.GameObject.transform.forward;

        //if (Vector3.Dot(playerPosition, npcPosition) <= 0.0f)
        //{
        //    Vector3 tempRotation = new Vector3(0.0f, 0.0f, 10.0f);
        //    this.npc.Entity.GameObject.transform.Rotate(tempRotation);
        //}
    }

    private void InternalStart()
    {
        this.navAgent = this.npc.Entity.GameObject.GetComponent<NavMeshAgent>();

        if (this.navAgent)
        {
            this.navAgent.Stop();

            this.npc.Entity.GameObject.transform.LookAt(this.playerTransform);

            this.navAgent.Resume();
        }

        this.Finish();
    }
}
