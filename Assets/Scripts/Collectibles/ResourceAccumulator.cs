using System;
using UnityEngine;

namespace Collectibles
{
    public class ResourceAccumulator
    {
        private const int Min = 0;

        private int _value;

        public ResourceAccumulator(int defaultValue = Min, int max = int.MaxValue)
        {
            Max = max;
            Value = defaultValue;
        }

        public event Action<int> Changed;

        public event Action Filled;

        public int Max { get; }

        public int Value
        {
            get => _value;

            private set
            {
                if (value != _value)
                {
                    _value = Mathf.Clamp(value, Min, Max);
                    Changed?.Invoke(_value);

                    if (_value == Max)
                    {
                        Filled?.Invoke();
                    }
                }
            }
        }

        public void Collect(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Can not be negative");
            }

            Value += amount;
        }
    }
}