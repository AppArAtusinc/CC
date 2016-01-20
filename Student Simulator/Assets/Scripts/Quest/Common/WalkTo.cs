using Entity;
using Quest.Core;
using SimpleGameTypes;
using StudentSimulator.SaveSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Quest.Common
{
    public class WalkTo : QuestPoint
    {

        [Save]
        public LinkToGameEntity<Actor> First;

        [Save]
        public LinkToGameEntity<Actor> Second;

        [Save]
        public float Radius;
       
        GameObject collider;

        public WalkTo() { }

        public WalkTo(GameObject firstGameObject, GameObject secondGameObject, float radius)
        {
            this.First = new LinkToGameEntity<Actor>(firstGameObject.ToGameEntity().Id);
            this.Second = new LinkToGameEntity<Actor>(secondGameObject.ToGameEntity().Id);
            this.Radius = radius;
        }

        public override void Init()
        {
            if (Active)
            {
                var gameObject = First.Entity.GameObject;
                collider = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("QuestObjects/Collider"));
                collider.transform.SetParent(gameObject.transform);
                collider.transform.localPosition = Vector3.zero;

                var questCollider = collider.GetComponent<QuestCollider>();
                questCollider.OnActive += QuestCollider_OnActive;
                questCollider.Radius = this.Radius;
            }
        }

        public override void Reset()
        {
            base.Reset();
            Init();
        }

        private void QuestCollider_OnActive(GameObject sender, GameObject activator)
        {
            if (Second.Entity.GameObject.GetInstanceID() != activator.GetInstanceID())
                return;

            Done();
            GameObject.Destroy(collider);
        }
    }
}
