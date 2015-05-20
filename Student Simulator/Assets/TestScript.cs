using UnityEngine;
using Actions.Core;
using Actions;
using System.Collections;
using System.IO;
using GameSaving;
using GameSaving.SaveObjects;

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

		//saving
		var saveableObjects = GameObject.FindGameObjectsWithTag("Saveable");
		SaveManager saveManager = new SaveManager("test_save_data.xml");
		SceneState saveScene = new SceneState();
		
		//save
		if(Input.GetKeyDown(KeyCode.C)){			
			for(int i = 0; i<saveableObjects.Length; i++){
				var cube1PosX = saveableObjects[i].transform.position.x;
				var cube1PosY = saveableObjects[i].transform.position.y;
				var cube1PosZ = saveableObjects[i].transform.position.z;
				
				var cube1AngleX = saveableObjects[i].transform.rotation.x;
				var cube1AngleY = saveableObjects[i].transform.rotation.y;
				var cube1AngleZ = saveableObjects[i].transform.rotation.z;
				var cube1AngleW = saveableObjects[i].transform.rotation.w;
				
				SaveObject sObjCube = new SCube("Test Cube", cube1PosX, cube1PosY, cube1PosZ, cube1AngleX, cube1AngleY, cube1AngleZ, cube1AngleW);
				
				saveScene.AddItem(sObjCube);
			}

			saveManager.AddInSaveList(saveScene);

			saveManager.SaveAll();		
		}

		//load
		if(Input.GetKeyDown(KeyCode.L)){
			var listOfSavedObjects = saveManager.LoadAll();

			for(int j = 0; j<listOfSavedObjects.Count; j++){
				var objName = listOfSavedObjects[j].objectName;
				Vector3 objPos = new Vector3(listOfSavedObjects[j].x, listOfSavedObjects[j].y, listOfSavedObjects[j].z);
				Quaternion objRotation = new Quaternion(listOfSavedObjects[j].rotationX, listOfSavedObjects[j].rotationY, listOfSavedObjects[j].rotationZ, listOfSavedObjects[j].rotationW);

				var resourceObj = Resources.Load("Objects/" + objName);

				GameObject.Instantiate(resourceObj, objPos, objRotation);
			}
		}

	}
	// Update is called once per frame
	void Update () {

	}
}
