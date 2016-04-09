using UnityEngine;
using System.Collections;
using Assets.Scripts.Quest.Common;
using Quest.Common;
using Quest.Common.Core;
using Actions.UI;

public class LaunchQuest : MonoBehaviour {

	void Start ()
    {
        StartCoroutine(launchQuest());
	}

    IEnumerator launchQuest()
    {
        string questname = "Test quest";
        yield return new WaitUntil(() => Game.Instance.IsLoaded);
        new TestQuest(questname).Start();
        yield return new WaitUntil(() => QuestHelper.IsActive(questname));
        new Notify("Quest " + questname + " is active!").Start();

        yield return new WaitUntil(() => QuestHelper.IsCompleted(questname));
        new Notify("Quest " + questname + " is completed!").Start();
    }
}
