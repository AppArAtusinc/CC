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
	public class PoolManager
	{
		public List<PoolEntity> Actor;

		public PoolManager()
		{
			Actor = new List<PoolEntity>();
		}

		public void Bind()
		{
			var objs = GameObject.FindGameObjectsWithTag("TestSaving");

			foreach (var obj in objs) {
				GameInformation info = obj.GetComponent<GameInformation>();
				Actor.Add(new PoolEntity(info.name, info.PrefabName, new SimpleTransform(obj.transform)));
				GameObject.Destroy(obj);
			}

		}
	}
}
