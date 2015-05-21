using UnityEngine;
using System.Collections;

public class Mainmenu : MonoBehaviour 
{

	public GameObject MainPanel, SettingsPanel;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void ToSettings()
	{
		MainPanel.SetActive(false);
		SettingsPanel.SetActive(true);
	}
	public void FromSettingsToMainmenu()
	{
		SettingsPanel.SetActive(false);
		MainPanel.SetActive(true);
	}
}
