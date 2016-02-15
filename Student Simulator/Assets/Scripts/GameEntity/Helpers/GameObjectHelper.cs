using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

static public class GameObjectHelper
{
    static public Guid GetEntityId(this GameObject Target)
    {
        var temp = Target.GetComponent<EntityInformation>();
        if (temp == null)
            throw new InvalidOperationException("Object " + Target.name + " does not have GameInformation component.");
        return temp.Id;
    }

    static public GameEntity ToGameEntity(this GameObject Target)
    {
        var temp = Target.GetComponent<EntityInformation>();
        if (temp == null)
            throw new InvalidOperationException("Object " + Target.name + " does not have GameInformation component.");
        return Game.GetInstance().EntityCollection.Actors.Single(o => o.Id == temp.Id);
    }
}
