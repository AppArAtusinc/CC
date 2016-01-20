using SimpleGameTypes;
using StudentSimulator.SaveSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Reflection;

namespace Entity
{
    /// <summary>
    /// Implements entity with transform
    /// </summary>
    [Entity]
    public class Actor : GameEntity
    {
        /// <summary>
        /// The transform entity in the scene.
        /// </summary>
        /// <owner>Stanislav Silin</owner>
        [Save]
        public SimpleTransform Transform;

        /// <summary>
        /// Holds name for game object prefab.
        /// </summary>
        /// <owner>Stanislav Silin</owner>
        [Save]
        public string PrefabName;

        /// <summary>
        /// Holds game object linked to the actor.
        /// </summary>
        public GameObject GameObject
        {
            get;
            private set;
        }

        protected Actor() 
            : base()
        {

        }

        protected Actor(GameObject gameObject)
            : base()
        {
            var info = gameObject.GetComponent<EntityInformation>();
            info.Id = this.Id;

            this.GameObject = gameObject;
            this.PrefabName = info.PrefabName;
            this.Transform = new SimpleTransform(gameObject.transform);
        }

        public override void Load()
        {
            this.GameObject = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>(PrefabName));

            var transform = new SimpleTransform(this.GameObject.transform);
            transform.Position = this.Transform.Position;
            transform.Rotation = this.Transform.Rotation;
            transform.Scale = this.Transform.Scale;

            this.Transform = transform;

            var info = this.GameObject.GetComponent<EntityInformation>();
            info.Id = this.Id;
        }

        public override void Destroy()
        {
            GameObject.Destroy(this.GameObject);
            base.Destroy();
        }

        public static Actor Create(GameObject gameObject)
        {
            var entityInformation = gameObject.GetComponent<EntityInformation>();
            var type = typeof(Actor).Assembly.GetType(entityInformation.FullName);

            var actor = type.InvokeMember(type.Name,
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.CreateInstance | BindingFlags.FlattenHierarchy,
                null,
                null,
                new object[] { gameObject }) as Actor;

            return actor;
        } 
    }
}
