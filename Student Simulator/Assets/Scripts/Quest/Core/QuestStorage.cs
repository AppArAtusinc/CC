using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Quest.Core
{
    static public class QuestStorage
    {
        static readonly List<Type> questStores;

        static public void LoadQuests()
        {
           
        }

        static public void Activate<T>() where T : QuestStory
        {
            var type = typeof(T);

            if(questStores.Any(o => o != type))
            throw new InvalidOperationException("Quest, which you try to create, does not exist.");

            //(QuestStory)type.Assembly.CreateInstance(type.FullName);

        }
    }
}
