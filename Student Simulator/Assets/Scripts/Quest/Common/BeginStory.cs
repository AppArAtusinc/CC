using System;
using UnityEngine;
using Actions.Core;
using Actions.UI;
using Quest.Common;
using System.Linq;
using System.Collections.Generic;
using Entites;
using Entites.Common;

namespace Quest.Common
{
    public class BeginStory : GameAction
    {
        List<string> npcNames = new List<string>();

        public BeginStory()
        {
            this.npcNames.Add("bad_guy");
            this.npcNames.Add("bad_guy (1)");
            this.npcNames.Add("boy1");
            this.npcNames.Add("boy1 (1)");
            this.npcNames.Add("boy2");
            this.npcNames.Add("boy3");
            this.npcNames.Add("boy3 (1)");
            this.npcNames.Add("boy3 (2)");
			this.npcNames.Add("SuperGirl");
            this.npcNames.Add("girl1 (1)");
            this.npcNames.Add("girl2");
            this.npcNames.Add("girl3");
            this.npcNames.Add("mom");
            this.npcNames.Add("old_woman");
        }

        // start NPC animations
        public override void Start()
        {
            Debug.Log("BeginStory");

            base.Start();

            List<NPC> bots = new List<NPC>();
            List<GameObject> markers = new List<GameObject>();

            Game.GetInstance().EntityCollection.Actors.ForEach(o =>
            {
                var npc = o as NPC;

                if (npc != null)
                {
                    foreach (var name in this.npcNames)
                    {
                        if (npc.Name == name)
                        {
                            bots.Add(npc);
                        }
                    }
                }
                else
                {
                    if (o.Name.Contains("Marker"))
                    {
                        markers.Add(GameObject.Find(o.Name));
                    }
                }
            });

            // =============== temporary logic ==================
            // TODO: add animation template for all npc
            var bot1 = Game.GetInstance().EntityCollection.Actors.Find(o => o.Name == "bad_guy") as NPC;

			var girl = Game.GetInstance().EntityCollection.Actors.Find(o => o.Name == "SuperGirl") as NPC;

            var boy = Game.GetInstance().EntityCollection.Actors.Find(o => o.Name == "BadGuy") as NPC;

            var bot4 = Game.GetInstance().EntityCollection.Actors.Find(o =>
            {
                return o.Name == "boy3";
            }) as NPC;

			var toalet1 = GameObject.Find("Toalet 1");
			var toalet3 = GameObject.Find("Toalet 3");
			var room108 = GameObject.Find("Room 108");
            var room207 = GameObject.Find("Room 207");

			new RepeatForever( new Walk(girl, toalet1.ToGameEntity() as Actor), new Delay(5), new Walk(girl, room108.ToGameEntity() as Actor)).Start();
			new RepeatForever( new Walk(boy, toalet3.ToGameEntity() as Actor), new Delay(2), new Walk(boy, room207.ToGameEntity() as Actor)).Start();

//            var sequenceForBot1 = new Sequence(
//                new Delay(3),
//				new Walk(bot1, marker1.ToGameEntity() as Actor), 
//                new Delay(3),
//				new Walk(bot1, marker2.ToGameEntity() as Actor),
//                new Delay(3),
//				new Walk(bot1, marker3.ToGameEntity() as Actor),
//                new Delay(3),
//				new Walk(bot1, marker4.ToGameEntity() as Actor),
//                new Delay(3),
//				new Walk(bot1, marker8.ToGameEntity() as Actor),
//                new Delay(3),
//				new Walk(bot1, marker3.ToGameEntity() as Actor),
//                new Delay(3),
//				new Walk(bot1, marker1.ToGameEntity() as Actor)
//            );
//
//            var sequenceForBot2 = new Sequence(
//                new Delay(3),
//				new Walk(bot2, marker2.ToGameEntity() as Actor),
//                new Delay(3),
//				new Walk(bot2, marker1.ToGameEntity() as Actor),
//                new Delay(3),
//				new Walk(bot2, marker6.ToGameEntity() as Actor),
//                new Delay(3),
//                new Walk(bot2, marker8.ToGameEntity() as Actor),
//                new Delay(3),
//                new Walk(bot2, marker2.ToGameEntity() as Actor),
//                new Delay(3),
//                new Walk(bot2, marker7.ToGameEntity() as Actor),
//                new Delay(3),
//                new Walk(bot2, marker1.ToGameEntity() as Actor)
//            );
//
//            var sequenceForBot3 = new Sequence(
//                new Delay(3),
//                new Walk(bot3, marker4.ToGameEntity() as Actor),
//                new Delay(3),
//                new Walk(bot3, marker3.ToGameEntity() as Actor),
//                new Delay(3),
//                new Walk(bot3, marker2.ToGameEntity() as Actor),
//                new Delay(3),
//                new Walk(bot3, marker1.ToGameEntity() as Actor),
//                new Delay(3),
//                new Walk(bot3, marker4.ToGameEntity() as Actor),
//                new Delay(3),
//                new Walk(bot3, marker9.ToGameEntity() as Actor),
//                new Delay(3),
//                new Walk(bot3, marker2.ToGameEntity() as Actor),
//                new Delay(3),
//                new Walk(bot3, marker3.ToGameEntity() as Actor)
//            );
//
//            var sequenceForBot4 = new Sequence(
//                new Delay(3),
//                new Walk(bot4, marker6.ToGameEntity() as Actor),
//                new Delay(3),
//                new Walk(bot4, marker10.ToGameEntity() as Actor),
//                new Delay(3),
//                new Walk(bot4, marker5.ToGameEntity() as Actor),
//                new Delay(3),
//                new Walk(bot4, marker6.ToGameEntity() as Actor),
//                new Delay(5)
//            );
//
//            Parallel parallel = new Parallel(sequenceForBot1, sequenceForBot2, sequenceForBot3, sequenceForBot4);
//
//            var repeatForever = new RepeatForever(parallel);
//
//            repeatForever.Start();
            base.Start();    
        }

        //public override void Start()
        //{
        //    base.Start();

        //    var center = GameObject.Find("Center");
        //    var startPosition = GameObject.Find("Start");
        //    var player = GameObject.Find("RigidBodyFPSController");

        //    if (center == null || startPosition == null || player == null)
        //        return;

        //    var quest = new Sequence(
        //        new Delay(2),
        //        new Notify("Hello <username>!"),
        //        new Notify("Move to center of the cube!"),
        //        new WalkTo(center, player, 2),
        //        new Notify("Nice work <username>!"),
        //        /// have some rest
        //        new Delay(5),
        //        new Notify("Move back please!"),
        //        new WalkTo(startPosition, player, 2),
        //        new Notify("Nice work <username>!"),
        //        new Delay(2),
        //        new Notify("You done your first quest!"),
        //        new Delay(1),
        //        new Notify("Now fly to star!"),
        //        new Delay(1),
        //        new Notify("5!"),
        //        new Delay(1),
        //        new Notify("4!"),
        //        new Delay(1),
        //        new Notify("3!"),
        //        new Delay(1),
        //        new Notify("2!"),
        //        new Delay(1),
        //        new Notify("1!"),
        //        new Delay(2),
        //        new Notify("It is joke!")
        //    );//.SelfDestroy().Start();

        //    GameObject cube1 = GameObject.Find("Test Cube 1");
        //    GameObject cube2 = GameObject.Find("Test Cube 2");
        //    GameObject cube3 = GameObject.Find("Test Cube 3");
        //    GameObject cube4 = GameObject.Find("Test Cube 4");
        //    GameObject cube5 = GameObject.Find("Test Cube 5");

        //    float speed = 10;

        //    var repeatForever = new RepeatForever(
        //        new MoveTo(cube5, new Vector3(-15, 1, 0), speed),
        //        new MoveTo(cube5, new Vector3(15, 1, 0), speed));

        //    repeatForever.Start();

        //    var parallel = new Parallel(
        //        new Sequence(
        //            new MoveTo(cube1, new Vector3(20, 1, -20), speed),
        //            new MoveTo(cube1, new Vector3(-20, 1, -20), speed)),
        //        new Sequence(
        //            new MoveTo(cube2, new Vector3(20, 1, 20), speed),
        //            new MoveTo(cube2, new Vector3(-20, 1, 20), speed))
        //    );

        //    parallel.Start();

        //    var parallel2 = new Parallel(
        //        new Sequence(
        //            new MoveTo(cube3, new Vector3(20, 1, -15), speed),
        //            new MoveTo(cube3, new Vector3(-20, 1, -15), speed)),
        //        new Sequence(
        //            new MoveTo(cube4, new Vector3(20, 1, 15), speed),
        //            new MoveTo(cube4, new Vector3(-20, 1, 15), speed))
        //    );

        //    var repeat = new Repeat(parallel2).SetRepeatCount(2);

        //    repeat.Start();

        //    base.Start();
        //}
    }
}
