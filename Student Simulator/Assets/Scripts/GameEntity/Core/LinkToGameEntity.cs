using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using StudentSimulator.SaveSystem;

namespace Entity
{
    public class LinkToGameEntity<T> where T : GameEntity
    {
        T value;

        [Save]
        public Guid Id;

        public LinkToGameEntity()
        {
        }

        public LinkToGameEntity(Guid Id)
        {
            this.Id = Id;
            value = Game.GetInstance().EntityCollection.Actors.Single(o => o.Id == Id) as T;
        }

        public T Entity
        {
            get
            {
                if (value == null)
                    value = Game.GetInstance().EntityCollection.Actors.SingleOrDefault(o => o.Id == this.Id) as T;

                return value;
            }
        }
    }


}
