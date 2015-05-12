using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour
{
	public GameObject gameUI;
	public GameObject PauseMenu;
	public GameObject MainMenu;
	public GameObject PlayerMenu;
	public int TimeSpeed=1;
	private bool pauseMenuIsShowing, mainMenuIsShowing, playerMenuIsShowing;

	public void QuitGame()
	{
		Application.Quit();
		return;
	}

	// Use this for initialization
	void Start () 
	{
		pauseMenuIsShowing = false;
		mainMenuIsShowing = false;
		playerMenuIsShowing = false;
		PauseMenu.SetActive(pauseMenuIsShowing);
		MainMenu.SetActive(mainMenuIsShowing);
		PlayerMenu.SetActive(playerMenuIsShowing);
	}
	public void ShowPlayerMenu()
	{
		if(!pauseMenuIsShowing&&!mainMenuIsShowing)
		{
			playerMenuIsShowing=!playerMenuIsShowing;
			PlayerMenu.SetActive(playerMenuIsShowing);
		}
		return;
	}

	public void ShowPauseMenu()
	{
		pauseMenuIsShowing=!pauseMenuIsShowing;
		PauseMenu.SetActive(pauseMenuIsShowing);
		return;
	}
	public void ShowGameUI()
	{
		mainMenuIsShowing=!mainMenuIsShowing;
		MainMenu.SetActive(mainMenuIsShowing);
		gameUI.SetActive(!mainMenuIsShowing);
	}

	public void ShowMainMenu()
	{
		ShowPauseMenu();
		ShowGameUI ();

		return;
	}

	// Update is called once per frame
	void Update () 
	{
		if(pauseMenuIsShowing||mainMenuIsShowing||playerMenuIsShowing)
		{
			Time.timeScale=0;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;

		}
		else //Normal gameplay 
		{
			Time.timeScale=TimeSpeed;

			Cursor.lockState = CursorLockMode.Locked; //устанавливает курсор в центре и запрещает перемещиние
			Cursor.visible = false;
		}
		if(Input.GetKeyDown(KeyCode.Escape)&&!mainMenuIsShowing)
		{
			ShowPauseMenu ();
		}
		if(Input.GetKeyDown(KeyCode.Tab)&&!mainMenuIsShowing)
		{
			ShowPlayerMenu ();
		}
	}
}
