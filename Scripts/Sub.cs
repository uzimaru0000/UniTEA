using System;
using System.Collections.Generic;
using UnityEngine;

namespace UniTEA
{
    public class Sub<T>
    {
        public static Sub<T> none
        {
            get => new Sub<T>(new NoneEffect<T>());
        }

        public static Sub<T> batch(Sub<T>[] subs)
        {
            var effects = new IEffect<T>[subs.Length];
            for (var i = 0; i < subs.Length; i++)
            {
                var sub = subs[i];
                subs[i].effect.OnOccurrence -= subs[i].Invoke;
                effects[i] = subs[i].effect;
            }
            return new Sub<T>(new BatchingEffect<T>(effects));
        }

        public event Action<T> OnWatch;

        IEffect<T> effect;

        void Invoke(T val) => OnWatch?.Invoke(val);

        public Sub(IEffect<T> effect)
        {
            this.effect = effect;
            this.effect.OnOccurrence += Invoke;
        }

        public Sub<U> Map<U>(Func<T, U> func)
        {
            this.effect.OnOccurrence -= Invoke;
            return new Sub<U>(new MappedEffect<T, U>(this.effect, func));
        }
    }

    public interface IEffect<T>
    {
        event Action<T> OnOccurrence;
    }

    class NoneEffect<T> : IEffect<T>
    {
        public event Action<T> OnOccurrence;
    }

    class BatchingEffect<T> : IEffect<T>
    {
        public event Action<T> OnOccurrence;

        public BatchingEffect(IEffect<T>[] effects)
        {
            foreach (var effect in effects)
            {
                effect.OnOccurrence += v => OnOccurrence?.Invoke(v);
            }
        }
    }

    class MappedEffect<T, U> : IEffect<U>
    {
        public event Action<U> OnOccurrence;

        public MappedEffect(IEffect<T> effect, Func<T, U> func)
        {
            effect.OnOccurrence += val => OnOccurrence.Invoke(func(val));
        }
    }
}