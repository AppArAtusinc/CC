using Actions.Common;
using Assets.Scripts.Quest.Common;
using StudentSimulator.SaveSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quest.Core
{
    public class QuestCollection
    {
        public QuestCollection()
        {

        }

        public void Bind()
        {
            new StartQuest(new BeginStory()).Run();
        }
    }
}
