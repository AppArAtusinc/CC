using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleGameTypes;
using UnityEngine;
using Newtonsoft.Json;
using StudentSimulator.SaveSystem;
using System.Reflection;
using Seralizator.Core;

namespace Entity
{
    public enum EntityTag
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
    /// Need for saving context between save/load operation.
    /// </summary>
    public abstract class GameEntity : Saveable
    {
        public override int LoadPriority
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Holds name of GameEntity
        /// </summary>
        /// <owner>Stanislav Silin</owner>
        [Save]
        public string Name;

        /// <summary>
        /// Holds full name of entity.
        /// </summary>
        /// <owner>Stanislav Silin</owner>
        public string FullName
        {
            get
            {
                return this.GetType().FullName;
            }
        }

        /// <summary>
        /// Holds all tags associated with entity.
        /// </summary>
        [Save]
        public List<EntityTag> Tags = new List<EntityTag>();
    }        

}
