using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Bar : MonoBehaviour {

	public float BarLevel;
	private Image img;

	// Use this for initialization
	void Start () 
	{
		img = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		img.fillAmount = BarLevel;
	}
}
