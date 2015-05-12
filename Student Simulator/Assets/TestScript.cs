using UnityEngine;
using Actions.Core;
using Actions;
using System.Collections;

public class TestScript : MonoBehaviour {

    GameObject cube1, cube2, controller;
	// Use this for initialization
	void Start () {
        cube1 = GameObject.Find("Cube 3");
		cube2 = GameObject.Find("Cube 2");
		controller = GameObject.Find("RigidBodyFPSController");
	
	}

	void FixedUpdate()
	{
		if(Input.GetKey(KeyCode.Escape))
			Application.Quit();
		
		if(Input.GetKeyUp(KeyCode.R))
		{
			ActionManager.Add(new Replace(controller, new Vector3(-1,1,0)));
			ActionManager.Add(new Replace(cube1, new Vector3(0,1,1)));
			ActionManager.Add(new Replace(cube2, new Vector3(0,1,-1)));
		}
		
		if(Input.GetMouseButtonUp(0))
		{
			RaycastHit hit;
			Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit);
			if(hit.collider != null && hit.collider.gameObject != GameObject.Find("Cube"))
				//ActionManager.Add(new Drag(controller, hit.collider.gameObject, -0.5f));
				ActionManager.Add(new Sequense(
					new Delay(2.5f),
					new Jump(hit.collider.gameObject, 10f),
					new Delay(2.5f),
					new Jump(hit.collider.gameObject, 10f),
					new Delay(2.5f),
					new Jump(hit.collider.gameObject, 10f),
					new Delay(2.5f),
					new Jump(hit.collider.gameObject, 10f)
					));
		}
		
		
		if(Input.GetMouseButton(1))
		{
			RaycastHit hit;
			Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit);
			if(hit.collider != null && hit.collider.gameObject != GameObject.Find("Cube"))
				ActionManager.Add(new Drag(controller, hit.collider.gameObject, 0.5f));
		}

	}
	// Update is called once per frame
	void Update () {

	}
}
