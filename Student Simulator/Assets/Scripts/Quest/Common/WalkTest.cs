using Actions.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Quest.Common
{
    public class WalkTest : GameAction
    {
        public override void Start()
        {
            var marker1 = GameObject.Find("marker 1");
            var marker2 = GameObject.Find("marker 2");
            var marker3 = GameObject.Find("marker 3");

            var bot = Game.GetInstance().EntityCollection.Actors.Single(o => o.Name == "bot") as NPC;

            new Sequence(
                new Walk(bot, marker1.transform.position),
                new Walk(bot, marker2.transform.position),
                new Walk(bot, marker3.transform.position)
                //,
                //new Repeat(
                //    new Walk(bot, marker1.transform.position),
                //    new Walk(bot, marker2.transform.position))
                )
               .Start();

            base.Start();
        }
    }
}
