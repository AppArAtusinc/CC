using UnityEngine;
using Actions.Core;
using StudentSimulator.SaveSystem;
using Entites;

public class StartDialog : GameAction
{
    [Save]
    Link<NPC> npc;

    [Save]
    Transform playerTransform;

    [Save]
    Sequence npcDialogSequence;

    public Sequence DialogActions
    {
        get { return this.npcDialogSequence; }
        set { this.npcDialogSequence = value; }
    }

    public StartDialog(NPC npc, Transform playerTransform)
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

    protected override void Tick(float delta)
    {

    }

    private void InternalStart()
    {
        Debug.Log("StartDialog started");

        this.npcDialogSequence = new Sequence(
            new WalkSuspend(this.npc.Entity),
            new Delay(2),
            new RotateTo(this.npc.Entity, this.playerTransform),
            new Delay(6),
            new WalkResume(this.npc.Entity)
            );
        this.npcDialogSequence.SelfDestroy().Start();
        base.Start();

        Debug.Log("StartDialog finished");
    }
}
