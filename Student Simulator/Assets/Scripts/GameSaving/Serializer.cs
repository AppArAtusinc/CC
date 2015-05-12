using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;

static class Serializer{
	private static BinaryFormatter formatter;

	static Serializer(){
		formatter = new BinaryFormatter();
	}

	public static void Serialize(object obj){
		using (FileStream fs = new FileStream("save_file.dat", FileMode.OpenOrCreate)){
			formatter.Serialize(fs, obj);
		}
	}

	public static SaveObject Deserialize(){
		using (FileStream fs = new FileStream("save_file.dat", FileMode.Open)){
			var savedObject = (SaveObject)formatter.Deserialize(fs);		
			return savedObject;
		}
	}
}
