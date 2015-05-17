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
		//if(Input.GetKey(KeyCode.Escape))
		//	Application.Quit();
		
		if(Input.GetKeyUp(KeyCode.R))
		{
			ActionManager.Instanse.Add(new Replace(controller, new Vector3(-1,1,0)));
			ActionManager.Instanse.Add(new Replace(cube1, new Vector3(0,1,1)));
			ActionManager.Instanse.Add(new Replace(cube2, new Vector3(0,1,-1)));
		}

		
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
		
		
		if(Input.GetMouseButton(1))
		{
			RaycastHit hit;
			Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit);
			if(hit.collider != null && hit.collider.gameObject != GameObject.Find("Cube"))
				ActionManager.Instanse.Add(new Drag(controller, hit.collider.gameObject, 0.5f));
		}

	}
	// Update is called once per frame
	void Update () {

	}
}
