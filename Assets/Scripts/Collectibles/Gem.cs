using System;
using UnityEngine;

namespace Collectibles
{
    public class Gem
    {
        private const int Min = 0;

        private int _value;

        public Gem(int defaultValue = Min, int max = int.MaxValue)
        {
            Max = max;
            Value = defaultValue;
        }

        public event Action Changed;

        public int Max { get; }

        public int Value
        {
            get => _value;

            private set
            {
                if (value != _value)
                {
                    _value = Mathf.Clamp(value, Min, Max);
                    Changed?.Invoke();
                }
            }
        }

        public void Earn(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Can not be negative");
            }

            Value += amount;
        }
    }
}