using Actions.Core;
using Entites.Interaction.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Entites.Entites.Interaction
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
