using UnityEngine;
using Actions.Core;
using Actions;
using System.Collections;
using System.IO;
using GameSaving;
using GameSaving.SaveObjects;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using StudentSimulator.SaveSystem;

public class TestScript : MonoBehaviour {

    GameObject cube1, cube2, controller;

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
				var t = hit.collider.gameObject.GetComponentInChildren<Button>();
				if(t != null)
					t.Active(gameObject);
			}
		}

	}

	public void LateUpdate()
	{
		//saving
		if (Input.GetKeyDown(KeyCode.F5))
		{
            SaveSystem.Save("test");
		}

        //loading
		if (Input.GetKeyDown(KeyCode.F9))
		{
            SaveSystem.Load("test");
        }
	}
}
