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

		public SCube(string name, int id,  Vector3 position) : base(name, id, position){}

		public override void State(){
			//update own cube action
		}

		public override void Update(){
			base.Update();
			//+update actions
		}
	}
}