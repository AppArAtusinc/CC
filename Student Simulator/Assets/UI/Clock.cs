using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Clock : MonoBehaviour 
{
	DateTime time;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		time = DateTime.Now;
		Text str = GetComponent<Text>();
		string hour = time.Hour.ToString ();
		string minute = time.Minute.ToString();
		if(int.Parse (hour)<10)
		{
			hour="0"+hour;
		}
		if(int.Parse (minute)<10)
		{
			minute="0"+minute;
		}
		str.text = hour+":"+minute;

	}
}
