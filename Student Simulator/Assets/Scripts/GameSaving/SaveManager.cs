using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameSaving{

	class SaveManager{
		private List<SaveObject> savedObjects;
		//private SaveObject savingObject;

		public SaveManager(){
			this.savedObjects = new List<SaveObject>();
			//this.savingObject = new SaveObject();
		}

		public void AddInSaveList(SaveObject saveObject){
			if(saveObject != null){
				this.savedObjects.Add(saveObject);
			}
		}

		public void SaveAll(){
			foreach(var saveObj in this.savedObjects){
				Serializer.Serialize(saveObj);
			}
		}

		public void LoadAll(){
			var loadObject = Serializer.Deserialize();
		}
	}
}