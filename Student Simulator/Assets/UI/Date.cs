using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Date : MonoBehaviour 
{
	DateTime date;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		date = DateTime.Now;
		Text str = GetComponent<Text>();
		string day = date.Day.ToString ();
		string month = date.Month.ToString();
		string year = date.Year.ToString();
		if(int.Parse (day)<10)
		{
			day="0"+day;
		}
		if(int.Parse (month)<10)
		{
			month="0"+month;
		}
		
		str.text = day+"."+month+"."+year;
	}
}
