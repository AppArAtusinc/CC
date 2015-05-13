using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMenu : MonoBehaviour 
{
	//public short selectedMenu;
	public GameObject Map, Relationships;
	// Use this for initialization
	void Start () 
	{
		//selectedMenu = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void ChangeMenu(int NoMenu)
	{
		if(NoMenu==0)
		{
			ClearPanel();
		}
		else if(NoMenu==1)
		{
			ClearPanel();
			Relationships.SetActive(true);
		}
		else if(NoMenu==2)
		{
			ClearPanel();
		}
		else if(NoMenu==3)
		{
			ClearPanel();
			Map.SetActive(true);
		}
		else if(NoMenu==4)
		{
			ClearPanel();
		}
	}

	private void ClearPanel()
	{
		Map.SetActive (false);
		Relationships.SetActive (false);
	}

}
