using Actions.Core;
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

            var gameObject = entity.GetGameObject();

            new MoveTo(gameObject, new Vector3(10,1,0)).
                SetDuration(1).
                OnFinish(new NotifyAction()).
                Run();
        }

        class NotifyAction : GameAction
        {
            protected override bool Tick(float Delta)
            {
                Debug.Log("Done");
                return false;
            }
        }
    }
}
