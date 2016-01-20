using SimpleGameTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Entity.Interaction.Core
{
    public abstract class GameButton : Actor
    {
        public GameButton(GameObject gameObject)
            :base(gameObject)
        {
        }

        public abstract void Push(GameEntity entity);
    }
}
