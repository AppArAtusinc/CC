using UnityEngine;
using Actions.Core;
using StudentSimulator.SaveSystem;
using Entites;
using System.Collections;

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
    }

    protected override void Tick(float delta)
    {
        if (Vector3.Angle(this.npc.Entity.GameObject.transform.forward, -this.playerTransform.forward) > 5.0f)
        {
            Transform npcT = this.npc.Entity.GameObject.transform, playerT = this.playerTransform;
            npcT.forward = Vector3.Lerp(npcT.forward, -playerT.forward, .15f);
        }
        else
        {
            this.Finish();
        }
    }
}
