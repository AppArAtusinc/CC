using UnityEngine;
using Actions.Core;
using Actions;
using System.Collections;

public class TestScript : MonoBehaviour {

    GameObject cube1, cube2;
	// Use this for initialization
	void Start () {
        cube1 = GameObject.Find("Cube 3");
		cube2 = GameObject.Find("Cube 2");
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Escape))
			Application.Quit();

		if(Input.GetKeyUp(KeyCode.R))
			ActionManager.Add(new MoveTo(GameObject.Find("RigidBodyFPSController"), new Vector3(0,10,0)));

        if(Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit);
            ActionManager.Add(
				new Sequense(
					new Delay(2),
					new MoveTo(cube2, hit.point)));
        }

		/*
		if(Input.GetMouseButtonUp(1))
		{
			RaycastHit hit;
			Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit);
			if(hit.collider != null && hit.collider.gameObject != GameObject.Find("Cube"))
				cube = hit.collider.gameObject;
		}
		*/
	}
}
