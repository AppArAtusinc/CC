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
            notInitedLinks.Add(this as LinkToGameEntity<GameEntity>);
        }

        public LinkToGameEntity(UInt64 Id)
        {
            this.Id = Id;
            value = Game.GetInstance().Entites.Actor.Find(o => o.Id == Id) as T;
        }

        /// <remarks>
        /// DONT TRY TO REWRITE AS PROPETY!!! IT WILL BROKE SERALIZATION
        /// </remarks>
        public T GetEntity()
        {
            return value;
        }


        static List<LinkToGameEntity<GameEntity>> notInitedLinks = new List<LinkToGameEntity<GameEntity>>();

        public static void Link()
        {
            foreach (var link in notInitedLinks)
                link.value = Game.GetInstance().Entites.Actor.Find(o => o.Id == link.Id);

            notInitedLinks.Clear();
        }

    }
}
