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
		public string objectName;
		//TODO add prefab name
		//TODO add own list implementation
		[XmlElement("PositionX")]
		public float x;
		[XmlElement("PositionY")]
		public float y;
		[XmlElement("PositionZ")]
		public float z;
		[XmlElement("RotationX")]
		public float rotationX;
		[XmlElement("RotationY")]
		public float rotationY;
		[XmlElement("RotationZ")]
		public float rotationZ;
		[XmlElement("RotationW")]
		public float rotationW;
		 
		public SaveObject(){}

		public SaveObject(string name, float x, float y, float z, float angleX, float angleY, float angleZ, float angleW){
			this.objectName=name;
			this.x=x;
			this.y=y;
			this.z=z;
			this.rotationX=angleX;
			this.rotationY=angleY;
			this.rotationZ=angleZ;
			this.rotationW=angleW;
		}

		public virtual void State(){
			//object action there
		}

		public virtual void Update(){
			this.x = this._inst.transform.position.x;
			this.y = this._inst.transform.position.y;
			this.z = this._inst.transform.position.z;
			this.rotationX = this._inst.transform.rotation.eulerAngles.x;
			this.rotationY = this._inst.transform.rotation.eulerAngles.y;
			this.rotationZ = this._inst.transform.rotation.eulerAngles.z;
		}

		//public Coordinates ObjectPosition;
		//public Size ObjectSize;
		//public abstract void CreateObject();
	}
}