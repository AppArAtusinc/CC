using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]
struct ObjectProperty{
	public int id;	//unique id for each saving object property
	public string property;
}

class SaveObject{
	private List<ObjectProperty> saveObjectData;

	public SaveObject(){
		this.saveObjectData = new List<ObjectProperty>();
	}

	public void AddObjectProperty(int id, string prop){
		ObjectProperty objProp;
		objProp.id = id;
		objProp.property = prop;

		this.saveObjectData.Add(objProp);
	}

	public string GetObjectProperty(int id){
		foreach(var objProp in this.saveObjectData){
			if(objProp.id == id){
				return objProp.property;
			}
		}

		return null;
	}

	public List<ObjectProperty> GetAll(){
		return this.saveObjectData;
	}
}
