using Entites.Common;
using UnityEngine;

namespace Entites.Interaction.Core
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
