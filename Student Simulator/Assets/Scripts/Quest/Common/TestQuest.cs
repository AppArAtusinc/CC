using Actions.Core;
using Actions.UI;
using Quest.Common.Core;
using UnityEngine;

namespace Quest.Common
{
    public class TestQuest : Core.Quest
    {
        protected TestQuest() { }

        public TestQuest(string name) : base(name)  { }

        public override void Start()
        {
            var marker1 = GameObject.Find("marker 1");
            var marker2 = GameObject.Find("marker 2");
            var marker3 = GameObject.Find("marker 3");
            var player = GameObject.Find("player");

            this.Entry = new Sequence(
                new Notify("move"),
                new Delay(3),
                new WalkTo(marker1, player, 1),
                new Notify("ok"),
                new WalkTo(marker2, player, 1),
                new Notify("ok"),
                new Notify("Quest" + this.Name + "is active? " + QuestHelper.IsActive(this.Name)),
                new WalkTo(marker3, player, 1),
                new Notify("ok"));
            base.Start();
        }
    }
}
