using UnityEngine;
using StudentSimulator.SaveSystem;
using System;

public class GameCore : MonoBehaviour {

	// Use this for initialization
	void Start () {
#if UNITY_EDITOR
		Game.GetInstance().Bind();
#else
        try
        {
            SaveSystem.Load("The_Origin");
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
            Application.Quit();
        }
#endif
    }

    // Update is called once per frame
    void FixedUpdate () {
		Game.GetInstance().Update(Time.fixedDeltaTime);
	}
}
