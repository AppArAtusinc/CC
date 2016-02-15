using Assets.Scripts.Common;
using Entites.Common;
using StudentSimulator.SaveSystem;
using UnityEngine;

namespace Entites
{
    [Entity]
    public class Player : Actor
    {
        [Save]
        public Observer<float> Addiction = new Observer<float>();

        [Save]
        public Observer<float> Agility = new Observer<float>();

        [Save]
        public Observer<float> Carisma = new Observer<float>();

        [Save]
        public Observer<float> Fortune = new Observer<float>();

        [Save]
        public Observer<float> Happiness = new Observer<float>();

        [Save]
        public Observer<float> Health = new Observer<float>();

        [Save]
        public Observer<float> Diligent = new Observer<float>();

        [Save]
        public Observer<float> Hungry = new Observer<float>();

        [Save]
        public Observer<float> Intelligence = new Observer<float>();

        [Save]
        public Observer<float> Knowledge = new Observer<float>();

        [Save]
        public Observer<float> Strong = new Observer<float>();

        [Save]
        public Observer<float> Tiredness = new Observer<float>();

        [Save]
        public Observer<float> Wealth = new Observer<float>();

        private Player()
        {

        }

        protected Player(GameObject gameObject)
            : base(gameObject)
        {
            this.Strong.Value = 3.1415f;
            this.Health.Value = 1;
        }
    }
}
