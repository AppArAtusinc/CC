using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
            {
                var props = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Where(o => o.GetCustomAttributes(typeof(SaveAttribute), true).Any())
                                 .Select(p => base.CreateProperty(p, memberSerialization))
                             .Union(type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Where(o => o.GetCustomAttributes(typeof(SaveAttribute), true).Any())
                                        .Select(f => base.CreateProperty(f, memberSerialization)))
                             .ToList();

                props.ForEach(p => { p.Writable = true; p.Readable = true; });
                return props;
            }
        }

        static JsonSerializerSettings setting = new JsonSerializerSettings()
        {
            ContractResolver = new CustomContractResolver(),
            TypeNameHandling = TypeNameHandling.All
        };

        static public void Save(string fileToSave)
        {
            using (StreamWriter fs = new StreamWriter(fileToSave))
            {
                var data = JsonConvert.SerializeObject(Game.GetInstance(), Formatting.Indented, setting);
                fs.Write(data);
                fs.Close();
            }
        }
        static public void Load(string fileForLoad)
        {
            using (StreamReader fs = new StreamReader(fileForLoad))
            {
                var data = fs.ReadToEnd();

                var game = JsonConvert.DeserializeObject<Game>(data, setting);
                Game.InitInstance(game);
            }
        }
    }
}
