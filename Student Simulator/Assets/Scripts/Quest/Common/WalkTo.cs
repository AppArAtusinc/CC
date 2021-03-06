﻿using Entites;
using SimpleGameTypes;
using StudentSimulator.SaveSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Actions.Core;
using Entites.Common;
using Quest.Common.Core;

namespace Quest.Common
{
    public class WalkTo : GameAction
    {

        [Save]
        public Link<Actor> First;

        [Save]
        public Link<Actor> Second;

        [Save]
        public float Radius;
       
        GameObject collider;

        public WalkTo() { }

        public WalkTo(GameObject marker, GameObject walkable, float radius)
        {
            this.First = new Link<Actor>(marker.ToGameEntity().Id);
            this.Second = new Link<Actor>(walkable.ToGameEntity().Id);
            this.Radius = radius;
        }

        public override void Load()
        {
            if (IsRunning)
            {
                Restore();
            }
        }

        private void Restore()
        {
            var gameObject = First.Entity.GameObject;
            collider = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("QuestObjects/Collider"));
            collider.transform.SetParent(gameObject.transform);
            collider.transform.localPosition = Vector3.zero;

            var questCollider = collider.GetComponent<QuestCollider>();
            questCollider.OnActive += QuestCollider_OnActive;
            questCollider.Radius = this.Radius;

            this.OnStopOrFinish += (action) => Clear();
        }

        public override void Start()
        {
            Restore();
            base.Start();
        }

        private void QuestCollider_OnActive(GameObject sender, GameObject activator)
        {
            if (Second.Entity.GameObject.GetInstanceID() != activator.GetInstanceID())
                return;

            Finish();
        }

        private void Clear()
        {
            GameObject.Destroy(collider);
        }

        public override void Destroy()
        {
            Clear();
            base.Destroy();
        }
    }
}
