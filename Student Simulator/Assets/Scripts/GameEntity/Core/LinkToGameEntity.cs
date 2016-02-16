using System;
using System.Linq;
using Seralizator.Core;
using StudentSimulator.SaveSystem;

namespace Entites
{
    public class Link<T> where T : Saveable
    {
        T value;

        [Save]
        public Guid Id;

        public Link()
        {
        }

        public Link(Guid Id)
        {
            this.Id = Id;
            value = Game.GetInstance().EntityCollection.Actors.Single(o => o.Id == Id) as T;
        }

        public T Entity
        {
            get
            {
                if (value == null)
                    value = Game.GetInstance().EntityCollection.Actors.FirstOrDefault(o => o.Id == this.Id) as T;

                return value;
            }
        }
    }


}
