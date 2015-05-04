using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour
{
	public GameObject gameUI;
	public GameObject PauseMenu;

	public bool pauseMenuIsShowing;

	public void QuitGame()
	{
		Application.Quit();
		return;
	}

	// Use this for initialization
	void Start () 
	{

	}

	public void ShowPauseMenu()
	{
		pauseMenuIsShowing=!pauseMenuIsShowing;
		PauseMenu.SetActive(pauseMenuIsShowing);
		gameUI.SetActive(!pauseMenuIsShowing);
		if(pauseMenuIsShowing)Time.timeScale=0;
		else Time.timeScale=1;
		return;
	}


	// Update is called once per frame
	void Update () 
	{

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			ShowPauseMenu ();
		}
	}
}
