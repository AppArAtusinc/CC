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

		public void RemoveFromSaveList(SceneState saveScene){
			if(this.savedScenes.Count != 0){
				this.savedScenes.Remove(saveScene);
			}
		}

		public void ClearSaveList(){
			this.savedScenes.Clear();
		}

		public void SaveAll(){
			foreach(var saveObj in this.savedScenes){
				Serializer.Serialize(saveObj, this.savePath);
			}
		}

		public List<SaveObject> LoadAll(){
			var loadScene = Serializer.Deserialize(this.savePath);
			return loadScene.GetSavedObjectsList();
		}
	}
}