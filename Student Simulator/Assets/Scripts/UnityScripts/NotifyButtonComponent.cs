using UnityEngine;
using System.Collections;
using Entites;
using Entites.Interaction.Core;
using System;

public class NotifyButtonComponent : Button
{
    Link<GameButton> entity;

    void Start () {
        var info = GetComponent<EntityInformation>();
        entity = new Link<GameButton>(info.Id);
	}

    public override void Clicked(GameObject Sender)
    {
        entity.Entity.Push(Sender.ToGameEntity());
    }
}
