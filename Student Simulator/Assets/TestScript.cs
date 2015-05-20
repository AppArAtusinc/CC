using UnityEngine;
using Actions.Core;
using Actions;
using System.Collections;
using System.IO;
using Json;


public class TestScript : MonoBehaviour {

    GameObject cube1, cube2, controller;
	// Use this for initialization
	void Start () {
        cube1 = GameObject.Find("Test Cube 1");
		cube2 = GameObject.Find("Test Cube 2");
		controller = GameObject.Find("RigidBodyFPSController");

	}

	void FixedUpdate()
	{
		if(Input.GetKeyDown(KeyCode.E))
		{
			RaycastHit hit;
			Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit);
			if(hit.collider != null)
			{
				var t = hit.collider.gameObject.GetComponent<Activable>();
				if(t != null)
					t.Active(gameObject);
			}
		}
	}
	// Update is called once per frame
	void Update () {

	}
}
