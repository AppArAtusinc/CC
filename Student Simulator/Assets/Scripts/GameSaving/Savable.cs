using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameSaving{

	abstract class Savable{
		private SaveManager saveManager;

		public Savable(){
			this.saveManager = new SaveManager();
		}

		public abstract void Save();

		public void Accept(){

		}
	}
}
