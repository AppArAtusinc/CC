using System;
using UnityEngine;
using Actions.Core;
using Actions.UI;
using Quest.Common;

namespace Assets.Scripts.Quest.Common
{
    public class BeginStory : GameAction
    {
        public override void Start()
        {
            base.Start();

            var center = GameObject.Find("Center");
            var startPosition = GameObject.Find("Start");
            var player = GameObject.Find("RigidBodyFPSController");

            var quest = new Sequence(
                new Delay(2),
                new Notify("Hello <username>!"),
                new Notify("Move to center of the cube!"),
                new WalkTo(center, player, 2),
                new Notify("Nice work <username>!"),
                /// have some rest
                new Delay(5),
                new Notify("Move back please!"),
                new WalkTo(startPosition, player, 2),
                new Notify("Nice work <username>!"),
                new Delay(2),
                new Notify("You done your first quest!"),
                new Delay(1),
                new Notify("Now fly to star!"),
                new Delay(1),
                new Notify("5!"),
                new Delay(1),
                new Notify("4!"),
                new Delay(1),
                new Notify("3!"),
                new Delay(1),
                new Notify("2!"),
                new Delay(1),
                new Notify("1!"),
                new Delay(2),
                new Notify("It is joke!")
            ).SelfDestroy();
            quest.OnDestroy += (action) => new Notify("Destroy").SelfDestroy().Start();
            quest.Start();

            base.Start();
        }
    }
}
