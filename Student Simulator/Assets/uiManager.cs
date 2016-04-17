using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Actions.Core;

public class uiManager : MonoBehaviour
{
    public GameObject gameUI;
    public GameObject pauseMenu;
    public GameObject mainMenu;
    public GameObject playerMenu;
    public GameObject dialogueMenu;

    public Text UiQuestion;
    public Text[] UiAnswers;

    public static bool isPlaying;

    int currentDialogue;

    NpcDialogue currentNpc;

    public AudioClip gameMenuSound;
    public AudioClip mainMenuSound;

    public float gameMenuSoundVolume = 0.5f;
    public float mainMenuSoundVolume = 0.5f;

    private AudioSource source;

    List<string> npcNames = new List<string>();

    // Use this for initialization
    void Start()
    {

    }

    void Awake()
    {
        this.source = GetComponent<AudioSource>();

        if (!this.source)
        {
            throw new System.Exception("AudioSource not found");
        }

        this.source.loop = true;

        this.npcNames.Add("bad_guy");
        this.npcNames.Add("bad_guy (1)");
        this.npcNames.Add("boy1");
        this.npcNames.Add("boy1 (1)");
        this.npcNames.Add("boy2");
        this.npcNames.Add("boy3");
        this.npcNames.Add("boy3 (1)");
        this.npcNames.Add("boy3 (2)");
        this.npcNames.Add("girl1");
        this.npcNames.Add("girl1 (1)");
        this.npcNames.Add("girl2");
        this.npcNames.Add("girl3");
        this.npcNames.Add("mom");
        this.npcNames.Add("old_woman");
    }

    public void ShowGameUI()
    {
        mainMenu.SetActive(false);
        gameUI.SetActive(true);
        GameMouse();
    }
		
    void ShowHideMenu(GameObject menu, bool show)
    {
        menu.SetActive(show);

        if (show)
        {
            MenuMouse();

            if (menu.name == "PlayerMenu")
            {
                this.source.clip = this.gameMenuSound;
                this.source.volume = this.gameMenuSoundVolume;
            }
            else
            {
                this.source.clip = this.mainMenuSound;
                this.source.volume = this.mainMenuSoundVolume;
            }

            this.source.Play();
        }
        else
        {
            GameMouse();

            if (menu.name == "PlayerMenu")
            {
                this.source.clip = this.gameMenuSound;
                this.source.volume = this.gameMenuSoundVolume;
            }
            else
            {
                this.source.clip = this.mainMenuSound;
                this.source.volume = this.mainMenuSoundVolume;
            }

            this.source.Stop();
        }
    }

    public void HideAllMenus()
    {
        gameUI.SetActive(false);
        pauseMenu.SetActive(false);
        mainMenu.SetActive(false);
        playerMenu.SetActive(false);
    }

    void MenuMouse()
    {
        //Time.timeScale=0;
        isPlaying = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void GameMouse()
    {
        Time.timeScale = 1;
        isPlaying = true;
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

    NPC npc;

    void Update()
    {
        if (isPlaying)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))//&&!mainMenuIsShowing)
        {
            ShowHideMenu(pauseMenu, !pauseMenu.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ShowHideMenu(playerMenu, !playerMenu.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 3))
            {
                if (hit.collider.gameObject.layer == 8)
                {
                    //start StartDialog action
                    this.npc = hit.collider.gameObject.ToGameEntity() as NPC;
                    var player = GameObject.Find("Player");

                    if (this.npc != null && player != null)
                    {
                        var npcDialogSequence = new Sequence(
                            new WalkSuspend(this.npc),
                            new RotateTo(this.npc, player.transform)
                            );
                        npcDialogSequence.Start();
                    }

                    currentNpc = hit.collider.gameObject.GetComponent<NpcDialogue>();
                    GetDialogueToUI(currentNpc.dialogueNum);
                    ShowHideMenu(dialogueMenu, !dialogueMenu.activeSelf);
                }
                else if (hit.collider.gameObject.tag == "OpenableDoor")
                {
                    hit.collider.gameObject.GetComponent<DoorOpen>().UseDoor();
                }
                // Do something with the object that was hit by the raycast.
            }


        }
    }

    void GetDialogueToUI(int dialogueNumber = 0)
    {
        UiQuestion.text = Dialogues.allDialogues[dialogueNumber].question;
        for (int i = 0; i < 3; i++)
        {
            UiAnswers[i].text = Dialogues.allDialogues[dialogueNumber].answers[i].ToString();
        }
        currentDialogue = dialogueNumber;
    }

    public void AnswerBTNClick(int buttonNumber)
    {
        int nextDialogue = Dialogues.allDialogues[currentDialogue].answers[buttonNumber].nextDialogue;

        if (nextDialogue != -1)
        {
            currentNpc.dialogueNum = nextDialogue;
            GetDialogueToUI(nextDialogue);
        }
        else
        {
            // finish StartDialog action
            new WalkResume(this.npc).Start();

            ShowHideMenu(dialogueMenu, !dialogueMenu.activeSelf);
        }
    }

    //	public void QuitGame()
    //	{
    //		Application.Quit();
    //		return;
    //	}
}
