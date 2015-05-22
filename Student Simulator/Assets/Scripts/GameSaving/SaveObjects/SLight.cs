using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Xml.Serialization; 

namespace GameSaving.SaveObjects{
	
	[XmlType("Light")] 
	public class SLight : SaveObject{
		public SLight(){}

		[XmlElement("IsLightOn")]
		public bool isLightOn;
		[XmlElement("Intensity")]
		public float intensity;
		
		public SLight(string name, string sceneName, float x, float y, float z, float angleX, float angleY, float angleZ, float angleW, string actionType, bool actionState, bool isLightOn, float intensity)
			: base(name, sceneName, x, y, z, angleX, angleY, angleZ, angleW, actionType, actionState)
		{
			this.isLightOn = isLightOn;
			this.intensity = intensity;
		}
		
		public override void State(){

		}
		
		public override void Update(){
			base.Update ();
		}
	}
}