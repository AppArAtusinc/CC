﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;

namespace GameSaving{

	//xml serializer
	public class Serializer{

	//binary serialization not used now
	//	private static BinaryFormatter formatter;
	//
	//	static Serializer(){
	//		formatter = new BinaryFormatter();
	//	}
	//
	//	public static void Serialize(object obj){
	//		using (FileStream fs = new FileStream("save_file.dat", FileMode.OpenOrCreate)){
	//			formatter.Serialize(fs, obj);
	//		}
	//	}
	//
	//	public static SaveObject Deserialize(){
	//		using (FileStream fs = new FileStream("save_file.dat", FileMode.Open)){
	//			var savedObject = (SaveObject)formatter.Deserialize(fs);		
	//			return savedObject;
	//		}
	//	}

		static public void Serialize(SceneState state, string datapath){		
			Type[] extraTypes= { typeof(SaveObject), typeof(GameSaving.SaveObjects.SCube)};
			XmlSerializer serializer = new XmlSerializer(typeof(SceneState), extraTypes); 
			
			FileStream fs = new FileStream(datapath, FileMode.Create); 
			serializer.Serialize(fs, state); 
			fs.Close(); 	
		}
		
		static public SceneState Deserialize(string datapath){		
			Type[] extraTypes= { typeof(SaveObject), typeof(GameSaving.SaveObjects.SCube)};
			XmlSerializer serializer = new XmlSerializer(typeof(SceneState), extraTypes); 
			
			FileStream fs = new FileStream(datapath, FileMode.Open); 
			SceneState state = (SceneState)serializer.Deserialize(fs); 
			fs.Close(); 
			
			return state;
		}
	}
}
