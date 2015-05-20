using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameSaving{

	class SaveManager{
		private List<SceneState> savedScenes;
		private string savePath;

		public SaveManager(string savePath){
			this.savePath = savePath;
			this.savedScenes = new List<SceneState>();
		}

		public void AddInSaveList(SceneState saveScene){
			if(saveScene != null){
				this.savedScenes.Add(saveScene);
			}
		}

		public void SaveAll(){
			foreach(var saveObj in this.savedScenes){
				Serializer.Serialize(saveObj, this.savePath);
			}
		}

		public List<SaveObject> LoadAll(){
			//List<SceneState> loadScene = new List<SceneState>();
			var loadScene = Serializer.Deserialize(this.savePath);
			return loadScene.GetSavedObjectsList();

//			for(int i=0; i<this.savedScenes.Count; i++){
//
//				loadScene.Add(loadObj);
//			}
//
//			return loadScene;
		}
	}
}