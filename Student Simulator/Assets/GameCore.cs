using UnityEngine;
using System.Collections;
using Actions.Core;

public class GameCore : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        ActionManager.Update(Time.deltaTime);
	}
}
