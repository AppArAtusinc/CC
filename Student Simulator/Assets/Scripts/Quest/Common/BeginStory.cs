using System;
using Quest.Core;
using UnityEngine;
using Actions.Core;
using Actions.UI;
using Quest.Common;

namespace Assets.Scripts.Quest.Common
{
    public class BeginStory : QuestStory
    {
        public BeginStory()
        {
            Add(new Delay(2));
            Add(new Notify("Hello <username>!"));

            var center = GameObject.Find("Center");
            var startPosition = GameObject.Find("Start");
            var player = GameObject.Find("RigidBodyFPSController");

            var goToCenterOfCube = new WalkTo(center, player, 2);
            goToCenterOfCube.AddOnStartAction(new Notify("Move to center of the cube!"));
            goToCenterOfCube.AddOnFinish(new Notify("Nice work <username>!"));

            Add(goToCenterOfCube);

            /// have some rest
            Add(new Delay(5));

            var moveToStartPosition = new WalkTo(startPosition, player, 2);
            moveToStartPosition.AddOnStartAction(new Notify("Move back please!"));
            moveToStartPosition.AddOnFinish(new Notify("Nice work <username>!"));

            Add(moveToStartPosition);

            Add(new Delay(2));
            Add(new Notify("You done your first quest!"));

            Add(new Delay(1)
                .AddOnStartAction(new Notify("Now fly to star!")));
            Add(new Delay(2)
                .AddOnStartAction(new Notify("5!")));
            Add(new Delay(1)
                .AddOnStartAction(new Notify("4!")));
            Add(new Delay(1)
                .AddOnStartAction(new Notify("3!")));
            Add(new Delay(1)
                .AddOnStartAction(new Notify("2!")));
            Add(new Delay(1)
                .AddOnStartAction(new Notify("1!")));
            Add(new Delay(5)
                .AddOnStartAction(new Notify("It is a joke!")));
        }

        class Greeting : QuestPoint
        {

            protected override bool Tick(float Delta)
            {
                new Sequence(
                    ).Run();
                return base.Tick(Delta);
            }
        }
    }
}
