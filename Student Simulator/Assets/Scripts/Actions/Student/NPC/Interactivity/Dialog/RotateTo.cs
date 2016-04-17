using UnityEngine;
using Actions.Core;
using StudentSimulator.SaveSystem;
using Entites;

public class RotateTo : GameAction
{
    [Save]
    Link<NPC> npc;

    [Save]
    Transform playerTransform;

    public RotateTo(NPC npc, Transform playerTransform)
    {
        this.npc = new Link<NPC>(npc.Id);
        this.playerTransform = playerTransform;
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
        Debug.Log("RotateTo started");

        this.npc.Entity.GameObject.transform.LookAt(this.playerTransform);

        this.Finish();

        Debug.Log("RotateTo finished");
    }
}
