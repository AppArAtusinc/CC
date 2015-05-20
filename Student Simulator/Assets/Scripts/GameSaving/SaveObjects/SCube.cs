using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Xml.Serialization; 

namespace GameSaving.SaveObjects{

	[XmlType("Cube")] 
	public class SCube : SaveObject{
		public SCube(){}

		public SCube(string name, float x, float y, float z, float angleX, float angleY, float angleZ, float angleW)
		: base(name, x, y, z, angleX, angleY, angleZ, angleW){}

		public override void State(){
			//update own cube action
		}

		public override void Update(){
			base.Update();
			//+update actions
		}
	}
}