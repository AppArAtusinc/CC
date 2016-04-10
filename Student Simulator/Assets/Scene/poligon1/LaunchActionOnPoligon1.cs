using UnityEngine;
using System.Collections;
using Quest.Common;

public class LaunchActionOnPoligon1 : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(launchAction());
    }


    IEnumerator launchAction()
    {
        yield return new WaitUntil(() => Game.Instance.IsLoaded);
        new BeginStory().Start();
    }
}
