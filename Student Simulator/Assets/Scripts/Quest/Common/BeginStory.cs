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

            var bot1 = Game.GetInstance().EntityCollection.Actors.Find(o => o.Name == "bad_guy") as NPC;
			var girl = Game.GetInstance().EntityCollection.Actors.Find(o => o.Name == "SuperGirl") as NPC;
            var boy = Game.GetInstance().EntityCollection.Actors.Find(o => o.Name == "BadGuy") as NPC;
            var boy3 = Game.GetInstance().EntityCollection.Actors.Find(o => o.Name == "boy3") as NPC;
            var boyInEndOfHall = Game.GetInstance().EntityCollection.Actors.Find(o => o.Name == "boy1") as NPC;

            var toalet1 = GameObject.Find("Toalet 1");
            var toalet2 = GameObject.Find("Tualet 2");
            var toalet3 = GameObject.Find("Toalet 3");
            var wcGirl = GameObject.Find("ToiletForWomen");
            var room108 = GameObject.Find("Room 108");
            var room207 = GameObject.Find("Room 207");
            var hall1 = GameObject.Find("Hall 1");
            var hall2 = GameObject.Find("Hall 2");
            var endOfHall = GameObject.Find("Marker (21)");
            var centerOfHall = GameObject.Find("Marker (20)");
            var beginOfHall = GameObject.Find("Marker (3)");

            new RepeatForever(new Walk(girl, toalet1.ToGameEntity() as Actor), new Delay(5), new Walk(girl, room108.ToGameEntity() as Actor)).Start();
			new RepeatForever(new Walk(boy, toalet3.ToGameEntity() as Actor), new Delay(2), new Walk(boy, room207.ToGameEntity() as Actor)).Start();
            new RepeatForever(new Delay(4), new Walk(boy3, hall2.ToGameEntity() as Actor), new Delay(7), new Walk(boy3, hall1.ToGameEntity() as Actor)).Start();
            new RepeatForever(new Delay(5), new Walk(boyInEndOfHall, centerOfHall.ToGameEntity() as Actor),
                              new Delay(1), new Walk(boyInEndOfHall, beginOfHall.ToGameEntity() as Actor),
                              new Delay(3), new Walk(boyInEndOfHall, toalet2.ToGameEntity() as Actor),
                              new Delay(5), new Walk(boyInEndOfHall, beginOfHall.ToGameEntity() as Actor),
                              new Delay(1), new Walk(boyInEndOfHall, centerOfHall.ToGameEntity() as Actor),
                              new Delay(1), new Walk(boyInEndOfHall, endOfHall.ToGameEntity() as Actor)).Start();

            base.Start();    
        }
    }
}
