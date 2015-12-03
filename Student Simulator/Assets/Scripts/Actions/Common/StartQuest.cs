using Actions.Core;
using Quest.Core;
using StudentSimulator.SaveSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actions.Common
{
    public class StartQuest : GameAction
    {
        [Save]
        public QuestStory Story; 

        public StartQuest(QuestStory story)
        {
            this.Story = story;
        }

        protected override bool Tick(float Delta)
        {
            if (Game.GetInstance().ActionCollection.Actions.Any(o => o.Name != Story.Name))
                Story.Run();

            return false;
        }
    }
}
