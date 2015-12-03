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
        }

        public LinkToGameEntity(UInt64 Id)
        {
            this.Id = Id;
            value = Game.GetInstance().Entites.Actors.Find(o => o.Id == Id) as T;
        }

        public T Entity
        {
            get
            {
                return value ?? (value = Game.GetInstance().Entites.Actors.Find(o => o.Id == Id) as T);
            }
        }
    }


}
