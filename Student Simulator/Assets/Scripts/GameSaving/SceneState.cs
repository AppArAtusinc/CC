using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace GameSaving{

	[XmlRoot("SceneState")]
	[XmlInclude(typeof(SaveObject))] 
	public class SceneState{

		[XmlArray("SceneObjects")]
		[XmlArrayItem("SceneObject")]
		public List<SaveObject> sceneObjects = new List<SaveObject>();

		public SceneState(){}

		public void AddItem(SaveObject item){
			this.sceneObjects.Add (item);
		}

		public void RemoveItem(SaveObject item){
			this.sceneObjects.Remove(item);
		}

		public void Update(){
			foreach(SaveObject item in this.sceneObjects){
				item.Update();
			}
		}
	}
}

