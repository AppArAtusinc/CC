using Entity.Interaction.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Entity.Entites.Interaction
{
    public class NotifyButton : GameButton
    {
        public override void Push(GameEntity entity)
        {
            Debug.Log("Cliked");
        }
    }
}
