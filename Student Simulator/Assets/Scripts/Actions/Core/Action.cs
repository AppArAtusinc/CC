using StudentSimulator.SaveSystem;
using Seralizator.Core;
using Actions.Core;

namespace Actions.Core
{
    /// <summary>
    /// Base class for all action.
    /// </summary>
    abstract public class GameAction : Saveable
    {

        public override int LoadPriority
        {
            get
            {
                return 1;
            }
        }

        [Save]
        public bool IsRunning = false;

        /// <summary>
        /// Get name of action.
        /// Many action may have same name.
        /// </summary>
        /// <owner>Stanislav Silin</owner>
        [Save]
        public string Name;

        /// <summary>
        /// Emit on action end.
        /// </summary>
        /// <owner>Stanislav Silin</owner>
        public GameActionDelegate OnFinish = (action) => action.OnStopOrFinish.Emit(action);

        /// <summary>
        /// Emit on action start.
        /// </summary>
        /// <owner>Stanislav Silin</owner>
        public GameActionDelegate OnStart;

        public GameActionDelegate OnStop = (action) => action.OnStopOrFinish.Emit(action);
        
        public GameActionDelegate OnStopOrFinish = (action) => action.SelfDestroyInternal(action);

        [Save]
        public bool IsNeedDestory = false;

        protected GameAction()
        {
            this.IsNeedDestory = true;
        }

        public delegate void GameActionDelegate(GameAction action);

        public override void Destroy()
        {
            RemoveFromCollection();

            OnFinish = null;
            OnStart = null;
            OnStop = null;
            
            base.Destroy();
        }

        public virtual void Finish()
        {
            if(IsRunning)
                OnFinish.Emit(this);
            RemoveFromCollection();
        }

        /// <summary>
        /// Using for setting name of action.
        /// </summary>
        /// <param name="Name"> New name for action. </param>
        /// <returns> Return this action. </returns>
        public GameAction SetName(string Name)
        {
            this.Name = Name;
            return this;
        }

        public virtual void Start()
        {
            if (!IsRunning)
                OnStart.Emit(this);

            RemoveFromCollection();
            this.OnStart.Emit(this);
            AddToCollection();
        }

        public static void Stop(string Name)
        {
            
        } 

        public virtual bool Stop()
        {
            if(IsRunning)
                OnStop.Emit(this);
            return RemoveFromCollection();
        }

        protected virtual void Tick(float delta)
        {

        }

        public void Update(float delta)
        {
            if (IsRunning)
                Tick(delta);
        }

        private void AddToCollection()
        {
            this.IsRunning = true;
            Game.GetInstance().ActionCollection.Add(this);
        }

        private bool RemoveFromCollection()
        {
            IsRunning = false;
            return Game.GetInstance().ActionCollection.Actions.RemoveAll(o => o.Id == this.Id) > 0;
        }

        private void SelfDestroyInternal(GameAction action)
        {
            if(action.IsNeedDestory)
                action.Destroy();
        }

        public GameAction SelfDestroy()
        {
            IsNeedDestory = true;
            return this;
        }
    }
}

public static class GameActionExtention
{
    public static void Emit(this GameAction.GameActionDelegate func, GameAction action)
    {
        if (func != null)
            func(action);
    }
}
