using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour
{
	public GameObject uiPrefab;

	void Start () 
	{
		uiManager UM = Instantiate<GameObject>(uiPrefab).GetComponent<uiManager>();
		UM.playerController=this.GetComponent<RigidbodyFirstPersonController>();
		UM.ToMainMenuBTN();

	}

}
