using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Actions.Core;
using System.Collections;
using StudentSimulator.SaveSystem;

public class uiManager : MonoBehaviour
{
    public GameObject gameUI;
    public GameObject pauseMenu;
    public GameObject mainMenu;
    public GameObject playerMenu;
    public GameObject dialogueMenu;

	public GameObject winMenu, winMenuText;
	public Image winMenuImg;

    public Text UiQuestion;
    public Text[] UiAnswers;
	public GameObject DoorIsLockedText;

    public static bool isPlaying;

    int currentDialogue;
	public RigidbodyFirstPersonController playerController;
    NpcDialogue currentNpc;

    public AudioClip []sounds;

    private AudioSource source;

    List<string> npcNames = new List<string>();

	public delegate void QuestEvents();
	public static event QuestEvents StartQuest1;



    // Use this for initialization


    void Awake()
    {
		playerController = GameObject.Find("Player").GetComponent<RigidbodyFirstPersonController>();
        this.source = GetComponent<AudioSource>();

        if (this.source)
        {
            this.source.clip = sounds[Random.Range(0, sounds.Length)];
            this.source.Play();
            this.source.loop = true;
        }

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

		SaveGame();
    }

	public void SaveGame()
	{
		LoadManager.Save("test");
	}

	public void LoadGame()
	{
		LoadManager.Load("test");
	}

    public void ShowGameUI()
    {
        mainMenu.SetActive(false);
        gameUI.SetActive(true);
        GameMouse();
    }
		
	public void QuitGame()
	{
		Application.Quit();
	}

    void ShowHideMenu(GameObject menu, bool show)
    {
        menu.SetActive(show);

        if (show)
        {
            MenuMouse();
        }
        else
        {
            GameMouse();            
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
		playerController = GameObject.Find("Player").GetComponent<RigidbodyFirstPersonController>();

		playerController.enabled=false;
        isPlaying = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void GameMouse()
    {
		playerController = GameObject.Find("Player").GetComponent<RigidbodyFirstPersonController>();

		playerController.enabled=true;
        isPlaying = true;
        Cursor.lockState = CursorLockMode.Locked; //устанавливает курсор в центре и запрещает перемещиние
        Cursor.visible = false;
    }

	public void ToMainMenuBTN()
	{
		HideAllMenus();
		ShowHideMenu(mainMenu,true);
	}

	public void ExitPauseMenu()
	{
		ShowHideMenu(pauseMenu, !pauseMenu.activeSelf);
	}

	public void ToMainMenu()
	{
		ShowHideMenu(mainMenu, !pauseMenu.activeSelf);
	}

    NPC npc;

    void Update()
    {      
        if (isPlaying)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

		if (Input.GetKeyDown(KeyCode.Escape)&&!dialogueMenu.activeSelf)
        {
            ShowHideMenu(pauseMenu, !pauseMenu.activeSelf);
        }
//        if (Input.GetKeyDown(KeyCode.Tab))
//        {
//            ShowHideMenu(playerMenu, !playerMenu.activeSelf);
//        }
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
					if( hit.collider.gameObject.GetComponent<DoorOpen>().UseDoor())
					{
						StartCoroutine(ShowDoorClosedText());
					}
						
                }
				else if (hit.collider.gameObject.tag == "Bed")
				{
					if((hit.collider.gameObject.name=="303"&&QuestsTest.quests[0].State==2&&QuestsTest.quests[3].State==1)||(hit.collider.gameObject.name=="209"&&QuestsTest.quests[4].State==1))
					{
						Debug.Log("You win!");

						StartCoroutine(ShowWinMenu());
					}

				}
                // Do something with the object that was hit by the raycast.
            }


        }
    }

	IEnumerator ShowWinMenu()
	{
		Color clr = winMenuImg.color;
		clr.a=0;
		winMenuImg.color = clr;
		winMenuText.SetActive(false);
		winMenu.SetActive(true);
		WaitForSeconds WS = new WaitForSeconds(.01f);
		for(float i=0;i<=1;i+=.01f)
		{
			clr.a=i;
			winMenuImg.color = clr;
			yield return WS;
		}
		winMenuText.SetActive(true);
		yield return new WaitForSeconds(5);
		Application.Quit();

	}


	IEnumerator ShowDoorClosedText()
	{
		DoorIsLockedText.SetActive(true);
		yield return new WaitForSeconds(.3f);
		DoorIsLockedText.SetActive(false);
	}

    void GetDialogueToUI(int dialogueNumber = 0)
    {
		Debug.Log(dialogueNumber);
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
		int nextQuestDialogue = Dialogues.allDialogues[currentDialogue].answers[buttonNumber].nextQuestDialogue;
		int questN = Dialogues.allDialogues[currentDialogue].answers[buttonNumber].questNumber;
		if(currentDialogue==4&&buttonNumber==0) // studentQuest
		{
			QuestsTest.quests[0].State=1;
			QuestsTest.UpdateQuestsUI();
		}
		if(currentDialogue==13) // studentQuest
		{
			QuestsTest.quests[1].State=2;
			QuestsTest.quests[2].State=1;
			QuestsTest.UpdateQuestsUI();
		}
		if(currentDialogue==11&&buttonNumber==0) // studentQuest
		{
			QuestsTest.quests[0].State=2;
			QuestsTest.UpdateQuestsUI();
		}
		if(currentDialogue==15&&buttonNumber==1) // studentQuest
		{
			QuestsTest.quests[2].State=2;
			QuestsTest.UpdateQuestsUI();
		}
		if(currentDialogue==17) // studentQuest
		{
			if(QuestsTest.quests[0].State==2)
			{
				QuestsTest.quests[3].State=1;
			}
			else
			{
				QuestsTest.quests[4].State=1;
			}
			QuestsTest.UpdateQuestsUI();
		}
		if(currentDialogue==3&&buttonNumber==0) //babkaQuest
		{
			QuestsTest.quests[1].State=1;
			QuestsTest.UpdateQuestsUI();

			if(StartQuest1!=null)
			{
				StartQuest1();
			}
		}

		if (nextDialogue != -1||nextQuestDialogue!=-1)
        {
			if(nextQuestDialogue!=-1&&QuestsTest.quests[questN].State==1)
			{
				currentNpc.dialogueNum=nextQuestDialogue;
				//GetDialogueToUI(nextQuestDialogue);
				new WalkResume(this.npc).Start();

				ShowHideMenu(dialogueMenu, !dialogueMenu.activeSelf);
			}
			else
			{
            	currentNpc.dialogueNum = nextDialogue;
				GetDialogueToUI(nextDialogue);
			}
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
