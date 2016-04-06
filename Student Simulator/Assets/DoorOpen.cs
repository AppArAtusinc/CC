using UnityEngine;
using System.Collections;

[RequireComponent (typeof (MeshCollider))]
public class DoorOpen : MonoBehaviour {


	public Vector3 rotateToOpen;


	bool isOpened=false,isOpening=false;

	Transform TR;

	// Use this for initialization
	void Start () 
	{
		this.tag="OpenableDoor";
		TR = this.transform;
	}

	public void UseDoor()
	{
		if(!isOpening)StartCoroutine(SmoothDoorOpen());
	}

	IEnumerator SmoothDoorOpen()
	{
		isOpening=true;
		for(int i=0;i<20;i++)
		{
			TR.Rotate((isOpened?-rotateToOpen:rotateToOpen)/20f);
			yield return new WaitForSeconds(.02f);
		}
		isOpened=!isOpened;
		isOpening=false;
	}
}
