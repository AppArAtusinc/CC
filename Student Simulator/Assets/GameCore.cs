using UnityEngine;
using System.Collections;
using Actions.Core;

public class GameCore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ActionManager.Init();
	}
	
	// Update is called once per frame
	void Update () {
        ActionManager.Instanse.Update(Time.deltaTime);
	}
}
