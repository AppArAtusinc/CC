using UnityEngine;
using System.Collections;

public class LoginButton : Button {

	public override void Clicked (GameObject Sender)
	{
		Debug.Log(Sender.ToString());
	}
}
