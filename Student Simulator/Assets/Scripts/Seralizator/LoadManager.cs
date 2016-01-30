using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters;
using Seralizator.Core;

namespace StudentSimulator.SaveSystem
{
    public class SaveAttribute : Attribute
    {

    }

    public static class LoadManager
    {
        class CustomContractResolver : DefaultContractResolver
        {
            public static readonly DefaultContractResolver Instance = new CustomContractResolver();

            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
            {
                var props = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy).
                    Where(o => o.GetCustomAttributes(typeof(SaveAttribute), true).Any()).
                    Select(p => base.CreateProperty(p, memberSerialization)).

                    Union(type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy).

                    Where(o => o.GetCustomAttributes(typeof(SaveAttribute), true).Any()).
                    Select(f => base.CreateProperty(f, memberSerialization))).
                    
                    ToList();

                props.ForEach(p =>
                {
                    p.Writable = true;
                    p.Readable = true;
                    //p.Required = Required.Always;
                });
                return props;
            }
        }

        static JsonSerializerSettings setting = new JsonSerializerSettings()
        {
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Full,
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                ObjectCreationHandling = ObjectCreationHandling.Replace,
                PreserveReferencesHandling = PreserveReferencesHandling.All,
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented,
                ContractResolver = CustomContractResolver.Instance
        };

        static public List<Saveable> Instances = new List<Saveable>();

        /// <summary>
        /// Save game instance to slot.
        /// </summary>
        /// <owner>Stanislav Silin</owner>
        /// <param name="slotName">The name of slot.</param>
        static public void Save(string slotName)
        {
            using (StreamWriter fs = new StreamWriter(slotName.GetFileName()))
            {
                var data = JsonConvert.SerializeObject(Game.GetInstance(), Formatting.Indented, setting);
                fs.Write(data);
                fs.Close();
            }
        }

        /// <summary>
        /// Load game instance from slot.
        /// </summary>
        /// <owner>Stanislav Silin</owner>
        /// <param name="slotName">The Name of slot.</param>
        static public void Load(string slotName)
        {
            Game game;
            Instances.Clear();
            using (StreamReader fs = new StreamReader(slotName.GetFileName()))
            {
                game = JsonConvert.DeserializeObject<Game>(fs.ReadToEnd(), setting);
            }

            if (game == null)
                throw new NullReferenceException("Game couldn't load form file " + slotName.GetFileName());

            var prioties = Instances.Select(o => o.LoadPriority).Distinct().OrderBy(o => o);
            
            Game.Load(game);

            foreach (var priority in prioties)
                foreach (var item in Instances.Where(o => o.LoadPriority == priority))
                    item.Load();
        }

        static string GetFileName(this string SlotName)
        {
            return SlotName + ".txt";
        }

    }
}
