using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class DoorOpen : MonoBehaviour
{


    public Vector3 rotateToOpen;

    public bool isLocked, questDoor;


    bool isOpened = false, isOpening = false;

    Transform TR;

    // Use this for initialization

    void Start()
    {
		uiManager.StartQuest1+=OpenQuestDoor;
        this.tag = "OpenableDoor";
        TR = this.transform;
    }

	public bool UseDoor()
    {
        if (!isOpening && !isLocked) StartCoroutine(SmoothDoorOpen());
		return isLocked;
    }

	void OpenQuestDoor()
	{
		if(questDoor)
		{
			isLocked=false;
		}
	}

    IEnumerator SmoothDoorOpen()
    {
        isOpening = true;
        for (int i = 0; i < 20; i++)
        {
            TR.Rotate((isOpened ? -rotateToOpen : rotateToOpen) / 20f);
            yield return new WaitForSeconds(.01f);
        }
        isOpened = !isOpened;
        isOpening = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer==8)
        {
            UseDoor();
            Invoke("UseDoor", 0.0f);
        }
    }
}
