using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Xml.Serialization; 

namespace GameSaving.SaveObjects{
	
	[XmlType("Camera")] 
	public class SCamera : SaveObject{
		public SCamera(){}
		
		public SCamera(string name, string sceneName, float x, float y, float z, float angleX, float angleY, float angleZ, float angleW, string actionType, bool actionState)
		: base(name, sceneName, x, y, z, angleX, angleY, angleZ, angleW, actionType, actionState){}
		
		public override void State(){
			
		}
		
		public override void Update(){
			base.Update ();
		}
	}
}