using SimpleGameTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Entity.Interaction.Core
{
    public abstract class GameButton : GameEntityWithTransform
    {
        public GameButton(GameObject gameObject)
            :base(gameObject)
        {
        }

        public GameButton():
            base("TestButton", "Objects/PushButton", new SimpleTransform())
        {
        }

        public GameButton(SimpleTransform Transform) 
            : base("GameButton","Objects/PushButton", Transform)
        {

        }

        public abstract void Push(GameEntity entity);
    }
}
