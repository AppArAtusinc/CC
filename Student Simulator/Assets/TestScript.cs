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

public class TestScript : MonoBehaviour {

	JsonSerializerSettings set;
    GameObject cube1, cube2, controller;
	// Use this for initialization
	void Start () {
        cube1 = GameObject.Find("Test Cube 1");
		cube2 = GameObject.Find("Test Cube 2");
		controller = GameObject.Find("RigidBodyFPSController");
		set = new JsonSerializerSettings();
		set.Formatting = Formatting.Indented;
		set.TypeNameHandling = TypeNameHandling.All;
		set.TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Full;


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
		
		//save
		if(Input.GetKeyDown(KeyCode.C))
		{			
			SaveScene ();	
		}

		//load
		if(Input.GetKeyDown(KeyCode.L))
		{
			LoadScene ();
		}

	}

	public void LateUpdate()
	{
		//saving
		if (Input.GetKeyDown(KeyCode.F5))
		{
			StreamWriter fs = new StreamWriter("test.txt");
			var data = JsonConvert.SerializeObject(Game.GetInstance(), Formatting.Indented, set);
			fs.Write(data);
			fs.Close();
		}
		if (Input.GetKeyDown(KeyCode.F9))
		{
            using (StreamReader fs = new StreamReader("test.txt"))
            {
                var data = fs.ReadToEnd();
				Debug.Log (data);

				var game = (Game)JsonConvert.DeserializeObject(data, set);;
		    	Game.InitInstance(game);
            }
        }
	}


	public void LoadScene()
	{
		SaveManager saveManager = new SaveManager("test_save_data.xml");
		var listOfSavedObjects = saveManager.LoadAll();
		
		for(int j = 0; j<listOfSavedObjects.Count; j++){
			var prefName = listOfSavedObjects[j].prefabName;
			var objName = listOfSavedObjects[j].objSceneName;

			var objects = GameObject.FindObjectsOfType(typeof(GameObject));

			for(int i = 0; i<objects.Length; i++){
				var sceneObj = GameObject.Find(objName);

				if(sceneObj){
					Destroy(sceneObj);
				}
			}
			var objects1 = GameObject.FindObjectsOfType(typeof(GameObject));

			Vector3 objPos = new Vector3(listOfSavedObjects[j].x, listOfSavedObjects[j].y, listOfSavedObjects[j].z);
			Quaternion objRotation = new Quaternion(listOfSavedObjects[j].rotationX, listOfSavedObjects[j].rotationY, listOfSavedObjects[j].rotationZ, listOfSavedObjects[j].rotationW);
			
			var resourceObj = Resources.Load("Objects/" + prefName);
			
			var newObj = GameObject.Instantiate(resourceObj, objPos, objRotation);
			newObj.name = objName;
		}
	}



	public void SaveScene()
	{
		var saveableObjects = GameObject.FindGameObjectsWithTag("Saveable");
		SaveManager saveManager = new SaveManager("test_save_data.xml");
		SceneState saveScene = new SceneState();
		for(int i = 0; i<saveableObjects.Length; i++){
			var name = saveableObjects[i].name;

			var cube1PosX = saveableObjects[i].transform.position.x;
			var cube1PosY = saveableObjects[i].transform.position.y;
			var cube1PosZ = saveableObjects[i].transform.position.z;
			
			var cube1AngleX = saveableObjects[i].transform.rotation.x;
			var cube1AngleY = saveableObjects[i].transform.rotation.y;
			var cube1AngleZ = saveableObjects[i].transform.rotation.z;
			var cube1AngleW = saveableObjects[i].transform.rotation.w;
			
			SaveObject sObjCube = new SCube("Test Cube", name, cube1PosX, cube1PosY, cube1PosZ, cube1AngleX, cube1AngleY, cube1AngleZ, cube1AngleW, "None", false);
			
			saveScene.AddItem(sObjCube);
		}
		
		saveManager.AddInSaveList(saveScene);
		
		saveManager.SaveAll();
	}


}
