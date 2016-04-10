using UnityEngine;
using StudentSimulator.SaveSystem;
using System;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameCore : MonoBehaviour {

	void Start () {
#if UNITY_EDITOR
        Game.GetInstance().Bind();
#else
        SceneManager.LoadScene("poligon1", LoadSceneMode.Additive);
        StartCoroutine(bindEnities());
#endif
    }

    private IEnumerator bindEnities()
    {
        yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag("TestSaving").Length > 0);
        Game.GetInstance().Bind();
    }

    void FixedUpdate () {
		Game.GetInstance().Update(Time.fixedDeltaTime);
	}
}
