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

            if (center == null || startPosition == null || player == null)
                return;

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
            );//.SelfDestroy().Start();
            
            GameObject cube1 = GameObject.Find("Test Cube 1");
            GameObject cube2 = GameObject.Find("Test Cube 2");
            GameObject cube3 = GameObject.Find("Test Cube 3");
            GameObject cube4 = GameObject.Find("Test Cube 4");
            GameObject cube5 = GameObject.Find("Test Cube 5");

            float speed = 10;

            var repeatForever = new RepeatForever(
                new MoveTo(cube5, new Vector3(-15,1,0), speed),
                new MoveTo(cube5, new Vector3(15,1,0), speed));

            repeatForever.Start();

            var parallel = new Parallel(
                new Sequence(
                    new MoveTo(cube1, new Vector3(20, 1, -20), speed),
                    new MoveTo(cube1, new Vector3(-20, 1, -20), speed)),
                new Sequence(
                    new MoveTo(cube2, new Vector3(20, 1, 20), speed),
                    new MoveTo(cube2, new Vector3(-20, 1, 20), speed))
            );

            parallel.Start();

            var parallel2 = new Parallel(
                new Sequence(
                    new MoveTo(cube3, new Vector3(20, 1, -15), speed),
                    new MoveTo(cube3, new Vector3(-20, 1, -15), speed)),                                            
                new Sequence(
                    new MoveTo(cube4, new Vector3(20, 1, 15), speed),
                    new MoveTo(cube4, new Vector3(-20, 1, 15), speed))                                            
            );

            var repeat = new Repeat(parallel2).SetRepeatCount(2);
            
            repeat.Start();

            base.Start();
        }
    }
}
