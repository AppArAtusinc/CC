using SimpleGameTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity.Interaction.Core
{
    public abstract class GameButton : GameEntityWithTransform
    {

        public GameButton()
        {
            Name = "TestButton";
            PrefabName = "Objects/PushButton";
            Transform = new SimpleTransform();
        }

        public GameButton(SimpleTransform Transform) 
            : base("GameButton","Objects/PushButton", Transform)
        {

        }

        public abstract void Push(GameEntity entity);
    }
}
