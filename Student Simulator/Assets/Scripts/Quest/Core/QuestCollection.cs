using StudentSimulator.SaveSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Quest.Core
{
    public class QuestCollection
    {
        [Save]
        List<QuestStory> questStories;

        public QuestCollection()
        {
            questStories = new List<QuestStory>();
        }

        public void Init()
        {
            foreach (var questStory in questStories)
                questStory.Init();
        }
    }
}
