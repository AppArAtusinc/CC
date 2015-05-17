using UnityEngine;
using System.Collections;

public class test1 : MonoBehaviour {

	Activable activ;
	// Use this for initialization
	void Start () {
		activ = gameObject.GetComponentInChildren<Activable>();
		activ.OnActivated += onActive;
	}

	void onActive()
	{
		Debug.Log("test");
	}

	void OnDestroy() {
		activ.OnActivated -= onActive;
	}
}
