using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour
{
	public GameObject uiPrefab;
	uiManager uiMng;

	void Start () 
	{
		uiMng = Instantiate<GameObject>(uiPrefab).GetComponent<uiManager>();
		uiMng.HideAllMenus ();
		uiMng.ShowGameUI ();
	}

}
