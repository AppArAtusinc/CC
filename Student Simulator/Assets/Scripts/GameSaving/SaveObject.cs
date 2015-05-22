using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Xml.Serialization; 

namespace GameSaving{

	[XmlType("SaveObject")]
	[XmlInclude(typeof(GameSaving.SaveObjects.SCube))]
	//[XmlInclude(typeof(SButton))]
	//[XmlInclude(typeof(SBar))]
	//[XmlInclude(typeof(SMenu))]
	public class SaveObject{
		protected GameObject _inst;
		public GameObject inst { set { _inst = value; } }

		[XmlElement("PrefabName")]
		public string prefabName;
		[XmlElement("ObjectName")]
		public string objSceneName;
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
		[XmlElement("ActionType")]
		public string actionType;
		[XmlElement("ActionState")]
		public bool actionState;
		 
		public SaveObject(){}

		public SaveObject(string name, string sceneName, float x, float y, float z, float angleX, float angleY, float angleZ, float angleW, string actionType, bool actionState){
			this.prefabName=name;
			this.objSceneName=sceneName;
			this.x=x;
			this.y=y;
			this.z=z;
			this.rotationX=angleX;
			this.rotationY=angleY;
			this.rotationZ=angleZ;
			this.rotationW=angleW;
			this.actionType=actionType;
			this.actionState=actionState;		
		}

		public virtual void State(){
			//object action there
		}

		public virtual void Update(){
			this.x = this._inst.transform.position.x;
			this.y = this._inst.transform.position.y;
			this.z = this._inst.transform.position.z;
			this.rotationX = this._inst.transform.rotation.x;
			this.rotationY = this._inst.transform.rotation.y;
			this.rotationZ = this._inst.transform.rotation.z;
			this.rotationW = this._inst.transform.rotation.w;
		}
	}
}