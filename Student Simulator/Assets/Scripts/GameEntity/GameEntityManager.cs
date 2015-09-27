using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleGameTypes;
using UnityEngine;

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
		public List<GameEntity> Actor;

		public GameEntityManager()
		{
			Actor = new List<GameEntity>();
		}

		/// <summary>
		/// Bind all GameObject in scene, while launching from Unity Editor. Calling automaticly.
		/// </summary>
		public void Bind()
		{
			var objs = GameObject.FindGameObjectsWithTag("TestSaving");

			foreach (var obj in objs) {
				GameInformation info = obj.GetComponent<GameInformation>();
				Actor.Add(new GameEntity(info.name, info.PrefabName, new SimpleTransform(obj.transform)));
				GameObject.Destroy(obj);
			}

		}
	}
}
