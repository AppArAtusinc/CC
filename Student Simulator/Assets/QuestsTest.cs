using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class QuestsTest : MonoBehaviour {

	public class Quest
	{
		public string questName;
		int state;

		public int State
		{
			get 
			{
				return this.state;
			}
			set
			{
				this.state=value;
				if(this.state==1)
				{
					Debug.Log(string.Format("Quest {0} is started", this.questName));
				}
			}
		}

		public Quest(string name, int state = 0)
		{
			this.questName=name;
			this.state=state;
		}



	}

	public static List<Quest> quests;
	public static Text questsList;

	void Start()
	{
		quests = new List<Quest>();

		questsList=this.GetComponent<Text>();
		UpdateQuestsUI();
		Debug.Log(questsList.text.ToString());

		quests.Add(new Quest("Попросить у коменданта 303 комнату"));
		quests.Add(new Quest("Найти коменданта в 103 комнате и получить пропуск"));
		quests.Add(new Quest("Подойти к вахтеру"));
		quests.Add(new Quest("Пойти в свою 303 комнату и лечь спать"));
		quests.Add(new Quest("Пойти в свою 209 комнату и лечь спать"));
	}

	public static void UpdateQuestsUI()
	{
		questsList.text="";
		foreach(Quest a in quests)
		{
			if(a.State==1)
			{
				questsList.text+="\n - "+a.questName;
			}
		}
	}


}
