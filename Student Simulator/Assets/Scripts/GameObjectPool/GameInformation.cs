using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GameInformation : MonoBehaviour
{
	public UInt64 Id;
	public string Name;
	public string PrefabName;

	static public UInt64 GetId(GameObject obj)
	{
		var temp = obj.GetComponent<GameInformation>();
		if(temp == null)
			throw new InvalidOperationException("Object " + obj.name + " does not have GameInformation component.");
		return temp.Id;
	}
}
