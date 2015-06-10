using UnityEngine;
using System.Collections;
using Actions.Core;

public class GameCore : MonoBehaviour {

	// Use this for initialization
	void Start () {
#if UNITY_EDITOR
		Game.GetInstance().Entites.Bind();
#endif
	}
	
	// Update is called once per frame
	void Update () {
		Game.GetInstance().Update(Time.deltaTime);
	}
}
