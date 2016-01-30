using System;
using Seralizator.Core;
using StudentSimulator.SaveSystem;

namespace Seralizator.Core
{
    public abstract class Saveable
    {
        public virtual int LoadPriority
        {
            get
            {
                return 0;
            }
        }

        public SaveableEvent OnDestroy;

        [Save]
        public bool IsDestroed = false;

        protected Saveable()
        {
            Id = Guid.NewGuid();
            LoadManager.Instances.Add(this);
        }

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
        /// <summary>
        /// Destroy the instance.
        /// </summary>
        /// <owner>Stanislav Silin</owner>
        public virtual void Destroy()
        {
            if(!IsDestroed)
                OnDestroy.Emit(this);

            OnDestroy = null;
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
    }

}

public static class SaveableExtention
{
    public static void Emit(this Saveable.SaveableEvent func, Saveable action)
    {
        if (func != null)
            func(action);
    }
}
