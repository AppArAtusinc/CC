using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleGameTypes;
using UnityEngine;
using Newtonsoft.Json;
using StudentSimulator.SaveSystem;

namespace Entity
{
    public enum EntitesTags
    {
        Player,
        Student,

        /// TODO: add more teachers
        YourTeacher,
        TeacherOfMath,
        TeacherOfUALanguage,
        TeacherOfHistory,
        TeacherOfPhilosofy,
        TeacherOfOOP,

        // ?
        Animal,

        // Only for test purpose
        TestQuestButton
    }


    public class EntityAttribute : Attribute { }


    /// <summary>
    /// Need for saving context bettwen save/load operation.
    /// </summary>
    public abstract class GameEntity
    {
        [Save]
        static UInt64 NextId = 1;

        /// <summary>
        /// Identificator for this entity. Use for work with same entity bettwen save/load operation.
        /// </summary>
        [Save]
        public UInt64 Id;

        /// <summary>
        /// Name on the scene.
        /// </summary>
        [Save]
        public string Name;

        /// <summary>
        /// Name of prefab in resource.
        /// </summary>
        [Save]
        public string PrefabName;

        public string FullName
        {
            get
            {
                return this.GetType().FullName;
            }
        }

        [Save]
        public List<EntitesTags> Tags = new List<EntitesTags>();

        protected GameObject gameObject;

        /// <summary>
        /// Use for initing GameObject in scene. Calling automaticly.
        /// </summary>
        /// <returns></returns>
        public virtual bool Init()
        {
            gameObject = GameObject.Instantiate(Resources.Load<GameObject>(PrefabName));

            var data = gameObject.GetComponent<EntityInformation>();
            data.Id = this.Id;
            data.Name = this.Name;
            data.PrefabName = this.PrefabName;
            data.FullName = this.FullName;
            gameObject.name = data.Name;

            return true;
        }

        public GameEntity()
        {
            Id = NextId++;
        }
        /// <summary>
        /// Use for creating new entity and GameObject ob scene.
        /// </summary>
        /// <param name="Name"> Name of entity and GameObject. </param>
        /// <param name="PrefabName"> Name of prefab of loading. </param>
        /// <param name="transform"> Transform for GameObject on scene. </param>
        public GameEntity(string Name, string PrefabName)
        {
            Id = NextId++;
            this.Name = Name;
            this.PrefabName = PrefabName;

            Init();
        }

        /// <summary>
        /// Use for getting inner GameoObject.
        /// </summary>
        /// <remarks>
        /// DONT TRY TO CREATE PROPETY!!! IT WILL BROKE SERALIZATION
        /// </remarks>
        /// <returns></returns>
        public GameObject GetGameObject()
        {
            return gameObject;
        }

        static public GameEntity CreateInstance(string FullName)
        {
            return typeof(GameEntity).Assembly.CreateInstance(FullName) as GameEntity;
        }

        static public T CreateInstance<T>() where T : GameEntity
        {
            var type = typeof(T);
            return type.Assembly.CreateInstance(type.FullName) as T;
        }

        /// <summary>
        /// Use for destroing entity and GameObject.
        /// </summary>
        public virtual void Destroy()
        {
            //Game.GetInstance().Entites.Actor.Remove(this);
            GameObject.Destroy(gameObject);
        }
    }
}
