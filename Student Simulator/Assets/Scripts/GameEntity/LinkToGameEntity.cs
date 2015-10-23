using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using StudentSimulator.SaveSystem;

namespace Entity
{
    public class LinkToGameEntity
    {
        GameEntity value;

        [Save]
        public UInt64 Id;

        public LinkToGameEntity()
        {
            notInitedLinks.Add(this);
        }

        public LinkToGameEntity(UInt64 Id)
        {
            this.Id = Id;
            value = Game.GetInstance().Entites.Actor.Find(o => o.Id == Id);
        }

        /// <remarks>
        /// DONT TRY TO CREATE PROPETY!!! IT WILL BROKE SERALIZATION
        /// </remarks>
        public GameEntity GetEntity()
        {
            return value;
        }

        static List<LinkToGameEntity> notInitedLinks = new List<LinkToGameEntity>();

        public static void Link()
        {
            foreach (var link in notInitedLinks)
                link.value = Game.GetInstance().Entites.Actor.Find(o => o.Id == link.Id);

            notInitedLinks.Clear();
        }

    }
}
