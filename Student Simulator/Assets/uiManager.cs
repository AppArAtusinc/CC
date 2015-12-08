using UnityEngine;
using System.Collections;

public class uiManager : MonoBehaviour {


	public GameObject gameUI;
	public GameObject pauseMenu;
	public GameObject mainMenu;
	public GameObject playerMenu;

	bool isPlaying;

	// Use this for initialization
	void Start () 
	{

	}
	
	public void ShowGameUI()
	{
		mainMenu.SetActive (false);
		gameUI.SetActive (true);
		GameMouse ();
	}

	void ShowPauseMenu(bool show)
	{
		pauseMenu.SetActive (show);
		if(show)
		{
			MenuMouse ();
		}
		else GameMouse ();
	}

	void ShowPlayerMenu(bool show)
	{
		playerMenu.SetActive (show);
		if(show)
		{
			MenuMouse ();
		}
		else GameMouse ();
	}

	 public void HideAllMenus ()
	{
		gameUI.SetActive (false);
		pauseMenu.SetActive (false);
		mainMenu.SetActive (false);
		playerMenu.SetActive (false);
	}

	void MenuMouse()
	{
		Time.timeScale=0;
		isPlaying=false;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	void GameMouse()
	{
		Time.timeScale=1;
		isPlaying=true;
		Cursor.lockState = CursorLockMode.Locked; //устанавливает курсор в центре и запрещает перемещиние
		Cursor.visible = false;
	}
//	public void ShowPlayerMenu()
//	{
//		if(!pauseMenuIsShowing&&!mainMenuIsShowing)
//		{
//			playerMenuIsShowing=!playerMenuIsShowing;
//			playerMenu.SetActive(playerMenuIsShowing);
//		}
//		return;
//	}
//	
//	public void ShowPauseMenu()
//	{
//		pauseMenuIsShowing=!pauseMenuIsShowing;
//		pauseMenu.SetActive(pauseMenuIsShowing);
//		return;
//	}
//	public void ShowGameUI()
//	{
//		mainMenuIsShowing=!mainMenuIsShowing;
//		mainMenu.SetActive(mainMenuIsShowing);
//		gameUI.SetActive(!mainMenuIsShowing);
//	}
//	
//	public void ShowMainMenu()
//	{
//		ShowPauseMenu();
//		ShowGameUI ();
//		
//		return;
//	}
//	
//	// Update is called once per frame
	void Update () 
	{
		if(isPlaying)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
//		if(pauseMenuIsShowing||mainMenuIsShowing||playerMenuIsShowing)
//		{
//			Time.timeScale=0;
//			Cursor.lockState = CursorLockMode.None;
//			Cursor.visible = true;
//			
//		}
//		else //Normal gameplay 
//		{
//			Time.timeScale=TimeSpeed;
//			
//			Cursor.lockState = CursorLockMode.Locked; //устанавливает курсор в центре и запрещает перемещиние
//			
//		}
		if(Input.GetKeyDown(KeyCode.Escape))//&&!mainMenuIsShowing)
		{
			ShowPauseMenu(!pauseMenu.activeSelf);
		}
		if(Input.GetKeyDown(KeyCode.Tab))
		{
			ShowPlayerMenu (!playerMenu.activeSelf);
		}
	}
//	public void QuitGame()
//	{
//		Application.Quit();
//		return;
//	}

}
