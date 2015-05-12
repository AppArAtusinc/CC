using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameSaving{

	abstract class Saveable{
		private SaveManager saveManager;

		public Saveable(){
			this.saveManager = new SaveManager();
		}

		public abstract void Save();

		public void Accept(){

		}
	}
}
