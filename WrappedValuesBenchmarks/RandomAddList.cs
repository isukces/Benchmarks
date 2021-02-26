using System;
using System.Collections.Generic;

namespace WrappedValuesBenchmarks
{
    public sealed class RandomAddList<TKey, TValue>
        where TKey : IIntegerBasedKey
    {
        public RandomAddList(int capacity = 0)
        {
            _list = new List<TValue>(Math.Max(capacity, 4));
        }

        public IReadOnlyList<TValue> AsX()
        {
            return _list;
        }

        public TValue GetOrCreate(TKey key, Func<TValue> factory)
        {
            var indexValue = key.Value;
            if (indexValue < _list.Count)
            {
                var result = _list[indexValue];
                if (result != null)
                    return result;
            }

            var value = factory();
            this[key] = value;
            return value;
        }

        public int Count => _list.Count;

        private readonly List<TValue> _list;


        public TValue this[TKey index]
        {
            get => _list[index.Value];
            set
            {
                var indexValue = index.Value;
                var delta      = _list.Count - indexValue;
                if (delta > 0)
                {
                    _list[indexValue] = value;
                    return;
                }

                while (delta < 0)
                {
                    _list.Add(default);
                    delta++;
                }

                _list.Add(value);
            }
        }
    }
}