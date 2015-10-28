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

                GameEntity entity;
                if (String.IsNullOrEmpty(info.FullName))
                    entity = GameEntity.CreateInstance<GameEntityWithTransform>();
                else
                    entity = GameEntity.CreateInstance(info.FullName);

                var entityWithTransform = entity as GameEntityWithTransform;

                if (entityWithTransform != null)
                    entityWithTransform.Transform = new SimpleTransform(obj.transform);

                entity.Name = info.Name;
                entity.PrefabName = info.PrefabName;

                Actor.Add(entity);

				GameObject.Destroy(obj);
			}

            Game.GetInstance().Entites.Actor.ForEach(o => o.Init());
		}
	}
}
