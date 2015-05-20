using UnityEngine;
using System.Collections;
using Actions;
using Actions.Core;


public class TestRepeatForeverButton : Button {

	bool run = false;
	public override void Clicked (GameObject Sender)
	{
		ActionManager.Instanse.RemoveByName("Test Action");
		var cube1 = GameObject.Find("Test Cube 1");

		if(run)
		{
			run = false;
			ActionManager.Instanse.RemoveByName("Test Action");
			ActionManager.Instanse.Add(new MoveTo(cube1, new Vector3(-20,0.5f,20)).SetDuration(2));
		}
		else
		{
			run = true;
			ActionManager.Instanse.Add(
				new Sequence(
				new MoveTo(cube1, new Vector3(-5,0.5f,-5)).SetDuration(2),
				new RepeatForever(
				new MoveTo(cube1, new Vector3(-10,0.5f,-5)).SetDuration(1),
				new MoveTo(cube1, new Vector3(-10,0.5f,5)).SetDuration(1),
				new MoveTo(cube1, new Vector3(-5,0.5f,5)).SetDuration(1),
				new MoveTo(cube1, new Vector3(-5,0.5f,-5)).SetDuration(1)
				)).SetName("Test Action"));

		}
	}
}
