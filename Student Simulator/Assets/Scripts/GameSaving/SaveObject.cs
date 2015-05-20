using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Xml.Serialization; 

namespace GameSaving{

//	public struct Coordinates{
//		public float xCoord;
//		public float yCoord;
//		public float zCoord;
//		public float angle;
//	}
//
//	public struct Size{
//		public float width;
//		public float height;
//		public float depth;
//	}

	[XmlType("SaveObject")]
	[XmlInclude(typeof(GameSaving.SaveObjects.SCube))]
	//[XmlInclude(typeof(SButton))]
	//[XmlInclude(typeof(SBar))]
	//[XmlInclude(typeof(SMenu))]
	public class SaveObject{
		protected GameObject _inst;
		public GameObject inst { set { _inst = value; } }

		[XmlElement("Type")]
		public string objectName;	//prefab name
		[XmlElement("Id")]
		public int objectId;
		[XmlElement("Position")]
		public Vector3 objectPosition;
		 
		public SaveObject(){}

		public SaveObject(string name, int id, Vector3 position){
			this.objectName=name;
			this.objectId=id;
			this.objectPosition=position;
		}

		public virtual void State(){
			//object action there
		}

		public virtual void Update(){
			this.objectPosition = this._inst.transform.position;
		}

		//public Coordinates ObjectPosition;
		//public Size ObjectSize;
		//public abstract void CreateObject();
	}
}