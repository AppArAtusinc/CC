using UnityEngine;
using System.Collections;
using Entity;
using Entity.Interaction.Core;
using System;

public class NotifyButtonComponent : Button
{
    LinkToGameEntity<GameButton> entity;

    void Start () {
        var info = GetComponent<GameInformation>();
        entity = new LinkToGameEntity<GameButton>(info.Id);
	}

    public override void Clicked(GameObject Sender)
    {
        entity.GetEntity().Push(Sender.ToGameEntity());
    }
}
