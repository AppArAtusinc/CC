using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

static public class GameObjectHelper
{
    static public UInt64 GetEntityId(this GameObject Target)
    {
        var temp = Target.GetComponent<GameInformation>();
        if (temp == null)
            throw new InvalidOperationException("Object " + Target.name + " does not have GameInformation component.");
        return temp.Id;
    }

    static public GameEntity ToGameEntity(this GameObject Target)
    {
        var temp = Target.GetComponent<GameInformation>();
        if (temp == null)
            throw new InvalidOperationException("Object " + Target.name + " does not have GameInformation component.");
        return Game.GetInstance().Entites.Actor.Single(o => o.Id == temp.Id);
    }
}
