using System.Collections.Generic;
using System.Linq;

namespace Quest.Common.Core
{
    public static class QuestHelper
    {
//		public static IEnumerable<string> Completed
//        {
//			get;
//			set;
//        }

		public static List<string> Active
        {
			get;
			set;
        }

		public static List<string> Stopped
        {
			get;
			set;
        }

        public static bool IsActive(string questName)
        {
			return Active.Any( o => o == questName);
        }

        public static bool IsStoped(string questName)
        {
			return Stopped.Any( o => o == questName);
        }

		public static void Activate(string questName)
		{
			Active.Add(questName);
		}

		public static void Stop(string questName)
		{
			Active.Remove(questName);
			Stopped.Add(questName);
		}

		static QuestHelper()
		{
			Active = new List<string>();
			Stopped = new List<string>();
		}
//        public static bool IsCompleted(string questName)
//        {
//            return Game.Instance.QuestCollection.IsCompleted(questName);
//        }
    }
}
