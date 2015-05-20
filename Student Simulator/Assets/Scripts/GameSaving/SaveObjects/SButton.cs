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

		public SButton(string name, int id, Vector3 position, bool buttonPressed) : base(name, id, position){
			this.buttonPressed = buttonPressed;
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
