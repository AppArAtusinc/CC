using System.Collections.Generic;

namespace Quest.Common.Core
{
    public static class QuestHelper
    {
        public static IEnumerable<Quest> Completed
        {
            get
            {
                return Game.Instance.QuestCollection.CompletedQuests;
            }
        }

        public static IEnumerable<Quest> Active
        {
            get
            {
                return Game.Instance.QuestCollection.ActiveQuests;
            }
        }

        public static IEnumerable<Quest> Stoped
        {
            get
            {
                return Game.Instance.QuestCollection.StopedQuests;
            }
        }

        public static bool IsActive(string questName)
        {
            return Game.Instance.QuestCollection.IsActive(questName);
        }

        public static bool IsStoped(string questName)
        {
            return Game.Instance.QuestCollection.IsStoped(questName);
        }

        public static bool IsCompleted(string questName)
        {
            return Game.Instance.QuestCollection.IsCompleted(questName);
        }
    }
}
