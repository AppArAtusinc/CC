using Seralizator.Core;
using StudentSimulator.SaveSystem;
using System.Collections.Generic;
using Actions.Core;
using UnityEngine;

namespace Quest.Common.Core
{
	public class QuestCollection : Saveable
	{
		public IEnumerable<Quest> ActiveQuests
		{
			get { return activeQuests.Values; }
		}

		public IEnumerable<Quest> CompletedQuests
		{
			get { return completedQuests.Values; }
		}

		public IEnumerable<Quest> StopedQuests
		{
			get { return stopedQuests.Values; }
		}

        [Save]
        private readonly Dictionary<string, Quest> activeQuests;

        [Save]
        private readonly Dictionary<string, Quest> completedQuests;

        [Save]
        private readonly Dictionary<string, Quest> stopedQuests;

		public QuestCollection()
		{
			activeQuests = new Dictionary<string, Quest>();
			completedQuests = new Dictionary<string, Quest>();
			stopedQuests = new Dictionary<string, Quest>();
		}

		public void Clear()
		{
			this.completedQuests.Clear();
			this.activeQuests.Clear();
		}

		public override void Load()
		{
			foreach (var quest in this.activeQuests.Values)
			{
				quest.OnFinish += questFinish;
				quest.OnStop += questStop;
			}
		}

		private void questStop(GameAction action)
		{
			activeQuests.Remove(action.Name);
			stopedQuests.Add(action.Name, action as Quest);
		}

		private void questFinish(GameAction action)
		{
			activeQuests.Remove(action.Name);
			completedQuests.Add(action.Name, action as Quest);
		}

		public Quest Start(Quest quest)
		{
			activeQuests.Add(quest.Name, quest);
			quest.OnFinish += questFinish;
			quest.OnStop += questStop;

            Debug.Log(quest.Name);

			return quest;
		}

		public bool Stop(string questName)
		{
			return this.activeQuests.Remove(questName);
		}

		public bool IsActive(string questName)
		{
			return activeQuests.ContainsKey(questName);
		}

		public bool IsCompleted(string queastName)
		{
			return completedQuests.ContainsKey(queastName);
		}

		public bool IsStoped(string questName)
		{
			return stopedQuests.ContainsKey(questName);
		}
	}
}