using Actions.Core;
using Entity.Interaction.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Entity.Entites.Interaction
{
    [Entity]
    public class NotifyButton : GameButton
    {
        public NotifyButton(GameObject gameObject)
            :base(gameObject)
        {
        }

        public override void Push(GameEntity entity)
        {
            Debug.Log("Clicked");

        }

        class NotifyAction : GameAction
        {
            protected override void Tick(float Delta)
            {
                Debug.Log("Done");
                Finish();
            }
        }
    }
}
