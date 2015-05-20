using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Xml.Serialization; 

namespace GameSaving.SaveObjects{

	[XmlType("Button")] 
	public class SButton : SaveObject{

		[XmlAttribute("ButtonState")]
		public bool buttonPressed;

		public SButton(){}

		public SButton(string name, float x, float y, float z, float angleX, float angleY, float angleZ, float angleW)
			: base(name, x, y, z, angleX, angleY, angleZ, angleW)
		{
			//this.buttonPressed = buttonPressed;
		}

		public override void State(){
			if(!this.buttonPressed){
				//update button state
			}
		}

		public override void Update(){
			base.Update ();
			//update actions
		}
	}
}
