using StudentSimulator.SaveSystem;
using System;

namespace Assets.Scripts.Common
{

    public class ValueChangeEvenArgs<T> : EventArgs
    {
        public readonly T Old;
        public readonly T New;
        public bool Allow = true;

        public ValueChangeEvenArgs(T old, T @new)
        {
            this.Old = old;
            this.New = @new;
        }
    }

    public class Observer<T>
    {
        [Save]
        T value;

        public event EventHandler<ValueChangeEvenArgs<T>> OnChange;

        public T Value
        {
            get
            {
                return value;
            }
            set
            {
                var eventArgs = new ValueChangeEvenArgs<T>(this.value, value);
                if (OnChange != null)
                    OnChange(this, eventArgs);

                if (eventArgs.Allow)
                    this.value = value;
            }
        }
    }
}
