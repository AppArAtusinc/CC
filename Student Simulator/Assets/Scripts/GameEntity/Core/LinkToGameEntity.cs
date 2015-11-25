using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using StudentSimulator.SaveSystem;

namespace Entity
{
    public class LinkToGameEntity<T> where T : GameEntity
    {
        T value;

        [Save]
        public UInt64 Id;

        public LinkToGameEntity()
        {
            LinkResolver.NewLinks.Add(this as LinkToGameEntity<GameEntity>);
        }

        public LinkToGameEntity(UInt64 Id)
        {
            this.Id = Id;
            value = Game.GetInstance().Entites.Actor.Find(o => o.Id == Id) as T;
        }

        public T Entity
        {
            get
            {
                return value ?? (value = Game.GetInstance().Entites.Actor.Find(o => o.Id == Id) as T);
            }
        }

        public static class LinkResolver
        {
            static public List<LinkToGameEntity<GameEntity>> NewLinks = new List<LinkToGameEntity<GameEntity>>();

            public static void Link()
            {
                foreach (var link in NewLinks)
                    link.value = Game.GetInstance().Entites.Actor.Find(o => o.Id == link.Id);

                NewLinks.Clear();
            }

        }
    }


}
