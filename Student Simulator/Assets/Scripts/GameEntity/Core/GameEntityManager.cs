using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleGameTypes;
using UnityEngine;
using StudentSimulator.SaveSystem;

namespace Entity
{
	/// <summary>
	/// Using for controlling PoolEntites.
	/// </summary>
	public class GameEntityManager
	{
		/// <summary>
		/// All GameEntites.
		/// </summary>
        [Save]
		public List<GameEntity> Actors;

        public GameEntityManager()
		{
			Actors = new List<GameEntity>();
		}

		/// <summary>
		/// Bind all GameObject in scene, while launching from Unity Editor. Calling automaticly.
		/// </summary>
		public void Bind()
		{
			var objs = GameObject.FindGameObjectsWithTag("TestSaving");

			foreach (var obj in objs) {
				EntityInformation info = obj.GetComponent<EntityInformation>();

                var entity = GameEntity.CreateInstance(info.FullName, obj);

                Actors.Add(entity);

				GameObject.Destroy(obj);
			}

            Game.GetInstance().Entites.Actors.ForEach(o => o.Init());
		}
	}
}
