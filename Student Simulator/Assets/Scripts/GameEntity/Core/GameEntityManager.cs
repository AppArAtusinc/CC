using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleGameTypes;
using UnityEngine;
using StudentSimulator.SaveSystem;
using Entites.Common;

namespace Entites
{
	/// <summary>
	/// Using for controlling PoolEntites.
	/// </summary>
	public class GameEntityCollection
	{
		/// <summary>
		/// All GameEntites.
		/// </summary>
        [Save]
		public List<GameEntity> Actors;

        public GameEntityCollection()
		{
			Actors = new List<GameEntity>();
		}

		/// <summary>
		/// Bind all GameObject in scene, while launching from Unity Editor. Calling automatically.
		/// </summary>
		public void Bind()
		{
			var objs = GameObject.FindGameObjectsWithTag("TestSaving");

			foreach (var obj in objs) {
                Actors.Add(Actor.Create(obj));
			}
           // Game.GetInstance().EntityCollection.Actors.ForEach(o => o.Load());
		}
	}
}
