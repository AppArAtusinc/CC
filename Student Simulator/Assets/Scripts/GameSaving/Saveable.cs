using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//not used now
namespace GameSaving{

	abstract class Saveable{
		private SaveManager saveManager;

		public Saveable(){
			this.saveManager = new SaveManager("Saves/save_data.xml");
		}

		public abstract void Save();

		public void Accept(){

		}
	}
}
