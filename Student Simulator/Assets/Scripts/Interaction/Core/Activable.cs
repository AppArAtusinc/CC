﻿using UnityEngine;
using System;
using System.Collections;

public class Activable : MonoBehaviour {

	public Action OnActivated;
	
	public virtual void Active(GameObject Activator)
	{
		Debug.Log("Object " + gameObject.name + " is activated!");
	}
}
