using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentProcessor.CompoundAssignment
{
    public sealed class CounterDontNet9(int value)
    {
        
        public int Value { get; private set; } = value;
        /// .net 9: With a compound assignment operator
        public static CounterDontNet9 operator +(CounterDontNet9 counter, CounterDontNet9 counter1)
        {
            var currentValue = counter.Value;

            currentValue += counter1.Value;

            return new(currentValue);
        }
    }

    public sealed class CounterDotnet10(int value)
    {
        public int Value { get; private set; } = value;

        /// .net 10: With a compound assignment operator
        public void operator +=(int value)
        {
            Value += value;
        }
    }
}
