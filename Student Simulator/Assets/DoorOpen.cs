using UnityEngine;
using System.Collections;

[RequireComponent (typeof (MeshCollider))]
public class DoorOpen : MonoBehaviour {


	public Vector3 rotateToOpen;


	bool isOpened=false;

	Transform TR;

	// Use this for initialization
	void Start () 
	{
		this.tag="OpenableDoor";
		TR = this.transform;
	}

	public void UseDoor()
	{
		Debug.Log(4);
		TR.Rotate(isOpened?-rotateToOpen:rotateToOpen);
		isOpened=!isOpened;
	}
}
