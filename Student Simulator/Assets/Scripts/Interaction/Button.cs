using UnityEngine;
using System;
using System.Collections;
using Actions.Core;
using Actions;

public abstract class Button : Activable 
{	
	public float Shift = 0.03f;
	bool activated = false;

	public abstract void Clicked(GameObject Sender);

	public override void Active (GameObject Activator)
	{
		if(activated)
			return;

		activated = true;
		Clicked(Activator);
		Vector3 startPos = gameObject.transform.position;
		ActionManager.Instanse.Add(
			new Parallel(
				new Sequence(
					new MoveTo(gameObject, (gameObject.transform.position - (gameObject.transform.up*Shift))).SetDuration(0.1f),
					new Delay(0.15f),
					new MoveTo(gameObject, startPos).SetDuration(0.1f),
					new CallFunction( () => { activated = false; })
			)));
	}
}
