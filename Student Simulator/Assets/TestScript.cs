using UnityEngine;
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
            LoadManager.Save("test");
		}

        //loading
		if (Input.GetKeyDown(KeyCode.F9))
		{
            LoadManager.Load("test");
        }
	}
}
