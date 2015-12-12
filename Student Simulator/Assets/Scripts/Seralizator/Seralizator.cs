using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters;
using System.Text;

namespace StudentSimulator.SaveSystem
{
    public class SaveAttribute : Attribute
    {

    }

    public static class SaveSystem
    {
        class CustomContractResolver : DefaultContractResolver
        {
            public static readonly DefaultContractResolver Instance = new CustomContractResolver();

            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
            {
                var props = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.).
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
                   // p.Required = Required.Always;
                    p.SetIsSpecified = (a,b) => 
                    {
                        var s = "";
                    };
                });
                return props;
            }
        }

        static JsonSerializerSettings setting = new JsonSerializerSettings()
        {
            ContractResolver = CustomContractResolver.Instance,
            TypeNameHandling = TypeNameHandling.All,
            TypeNameAssemblyFormat = FormatterAssemblyStyle.Full
        };

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
            using (StreamReader fs = new StreamReader(slotName.GetFileName()))
            {
                var data = fs.ReadToEnd();

                var game = JsonConvert.DeserializeObject<Game>(data, setting);
                Game.InitInstance(game);
            }
        }

        static string GetFileName(this string SlotName)
        {
            return SlotName + ".txt";
        }
    }
}
