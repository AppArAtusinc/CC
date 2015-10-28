using SimpleGameTypes;
using StudentSimulator.SaveSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    /// <summary>
    /// Implements enity with transform
    /// </summary>
    public class GameEntityWithTransform : GameEntity
    {
        /// <summary>
        /// Entity transform of scene
        /// </summary>
        [Save]
        public SimpleTransform Transform;

        public GameEntityWithTransform()
        {
            Transform = new SimpleTransform();
        }

        public GameEntityWithTransform(string Name, string PrefabName, SimpleTransform transform)
            : base(Name, PrefabName)
        {
            this.Transform = transform;

            Init();
        }

        public override bool Init()
        {
            base.Init();
            
            gameObject.transform.position = Transform.Position.ToVector3();
            gameObject.transform.rotation = Transform.Rotation.ToQuaterion();
            gameObject.transform.localScale = Transform.Scale.ToVector3();
            Transform = new SimpleTransform(gameObject.transform);

            return true;
        }
    }
}
