using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentSimulator.SaveSystem;

namespace Seralizator.Core
{

    public abstract class Saveable
    {
        public delegate void SaveableEvent(Saveable sender);

        /// <summary>
        /// Holds Id for object.
        /// </summary>
        /// <owner>Stanislav Silin</owner>
        [Save]
        public Guid Id
        {
            get;
            private set;
        }

        protected Saveable()
        {
            Id = Guid.NewGuid();
            LoadManager.Inctances.Add(this);
        }

        /// <summary>
        /// Restore state of instance after Save/Load operation.
        /// </summary>
        /// <owner>Stanislav Silin</owner>
        public virtual void Load()
        {

        }

        /// <summary>
        /// Call before saving instance.
        /// </summary>
        /// <owner>Stanislav Silin</owner>
        public virtual void Save()
        {

        }

        public SaveableEvent OnDestroy;

        /// <summary>
        /// Destroy the instance.
        /// </summary>
        /// <owner>Stanislav Silin</owner>
        public virtual void Destroy()
        {
            if (OnDestroy != null)
                OnDestroy(this);
        }
    }
}
