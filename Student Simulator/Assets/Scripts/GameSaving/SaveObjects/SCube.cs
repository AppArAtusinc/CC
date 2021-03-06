﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Xml.Serialization; 

namespace GameSaving.SaveObjects{

	[XmlType("Cube")] 
	public class SCube : SaveObject{
		public SCube(){}

		public SCube(string name, string sceneName, float x, float y, float z, float angleX, float angleY, float angleZ, float angleW, string actionType, bool actionState)
		: base(name, sceneName, x, y, z, angleX, angleY, angleZ, angleW, actionType, actionState){}

		public override void State(){
			//update own cube action
		}

		public override void Update(){
			base.Update();
			//+update actions
		}
	}
}