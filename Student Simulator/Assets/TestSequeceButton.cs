using UnityEngine;
using System.Collections;
using Actions;
using Actions.Core;


public class TestSequeceButton : Button {

	public override void Clicked (GameObject Sender)
	{
		Game.GetInstance().Actions.RemoveByName("Test Action");
		var cube1 = GameObject.Find("Test Cube 1");

		Game.GetInstance().Actions.Add(
			new Sequence(
				new MoveTo(cube1, new Vector3(-5,0.5f,-5)).SetDuration(2),
				new MoveTo(cube1, new Vector3(-10,0.5f,-5)).SetDuration(1),
				new MoveTo(cube1, new Vector3(-10,0.5f,5)).SetDuration(1),
				new MoveTo(cube1, new Vector3(-5,0.5f,5)).SetDuration(1),
				new MoveTo(cube1, new Vector3(-5,0.5f,-5)).SetDuration(1),
				new Delay(2),
				new MoveTo(cube1, new Vector3(-20,0.5f,20)).SetDuration(2)
			).SetName("Test Action"));
	}
}
