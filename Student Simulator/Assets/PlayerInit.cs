using UnityEngine;
using System.Collections;

public class PlayerInit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var camera = gameObject.GetComponent<Camera>();
		Camera.SetupCurrent(camera);	
	}
}
