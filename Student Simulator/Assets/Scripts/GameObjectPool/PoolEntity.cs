using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleGameTypes;
using UnityEngine;

namespace Entity
{
	/// <summary>
	/// Need for saving context bettwen save/load operation.
	/// </summary>
	public class PoolEntity
	{
		/// <summary>
		/// Identificator for this entity. Use for work with same entity bettwen save/load operation.
		/// </summary>
		public UInt64 Id;
		/// <summary>
		/// Name on the scene.
		/// </summary>
		public string Name;
		/// <summary>
		/// Name of prefab in resource.
		/// </summary>
		public string PrefabName;

		GameObject gameObject;

		/// <summary>
		/// Transform of entity on hte scene.
		/// </summary>
		public SimpleTransform transform;
		/// <summary>
		/// Use for initing GameObject in scene. Calling automaticly.
		/// </summary>
		/// <returns></returns>
		public bool Init()
		{
			gameObject = GameObject.Instantiate(Resources.Load<GameObject>(PrefabName));
			var data = gameObject.GetComponent<GameInformation>();
			data.Id = Id;
			data.Name = Name;
			data.PrefabName = PrefabName;
			gameObject.name = data.Name;

			gameObject.transform.position = transform.Position.ToVector3();
			gameObject.transform.rotation = transform.Rotation.ToQuaterion();
			gameObject.transform.localScale = transform.Scale.ToVector3();
			transform = new SimpleTransform(gameObject.transform);

			return true;
		}
		static UInt64 NextId = 1;
		public PoolEntity()
		{

		}
		/// <summary>
		/// Use for creating new entity and GameObject ob scene.s
		/// </summary>
		/// <param name="Name"> Name of entity and GameObject. </param>
		/// <param name="PrefabName"> Name of prefab of loading. </param>
		/// <param name="transform"> Transform for GameObject on scene. </param>
		public PoolEntity(string Name, string PrefabName, SimpleTransform transform)
		{
			Id = NextId++;
			this.Name = Name;
			this.PrefabName = PrefabName;
			this.transform = transform;

			Init();
		}

		/// <summary>
		/// Use for getting inner GameoObject.
		/// </summary>
		/// <returns></returns>
		public GameObject GetGameObject()
		{
			return gameObject;
		}

		/// <summary>
		/// Use for destroing entity and GameObject.
		/// </summary>
		public void Destroy()
		{
			//Game.GetInstance().Entites.Actor.Remove(this);
			GameObject.Destroy(gameObject);
		}
	}
}
