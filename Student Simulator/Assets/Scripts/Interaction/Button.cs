using UnityEngine;
using System;
using System.Collections;
using Actions.Core;
using Actions;
using Entity;

public abstract class Button : Activable
{
    public float Shift = 0.03f;
    bool activated = false;

    public abstract void Clicked(GameObject Sender);

    public override void Active(GameObject Activator)
    {
        if (activated)
            return;

        activated = true;
        Clicked(Activator);
        Vector3 startPos = gameObject.transform.position;

        new Sequence(
            new MoveTo(gameObject, (gameObject.transform.position - (gameObject.transform.up*Shift))).SetDuration(0.1f),
            new Delay(0.5f),
            new MoveTo(gameObject, startPos).SetDuration(0.1f),
            new RestoreStateInternal(gameObject)
        ).Run();
    }

    class RestoreStateInternal : GameAction
    {
        LinkToGameEntity<GameEntity> link;

        public RestoreStateInternal(GameObject parent)
        {
            link = new LinkToGameEntity<GameEntity>(parent.GetEntityId());
        }

        protected override bool Tick(float Delta)
        {
            link.Entity.GetGameObject().GetComponent<Button>().activated = false;
            return false;
        }
    }
}
