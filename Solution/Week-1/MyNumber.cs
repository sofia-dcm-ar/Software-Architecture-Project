using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

//Week 1 Exercise: Create an integer that can compare itself.

namespace Week1
{
    /// <summary>
    /// A wrapper class for an <see cref="int"/> with comparison capabilities.
    /// </summary>
    /// <remarks>
    /// This class allows integer values to be used in systems requiring the <see cref="IMyComparable"/> interface.
    /// </remarks>
    public class MyNumber : IMyComparable
    {
        private readonly int _value;

        public MyNumber(int value)
        {
            _value= value;
        }

        public int Value { get => _value; }

        // ---------------------------------------------------------
        // IMyComparable Implementation
        // ---------------------------------------------------------
        public bool IsEqual(IMyComparable other)
        {
            return (_value==((MyNumber)other)._value);
        }

        public bool IsLessThan(IMyComparable other)
        {
            return (_value<((MyNumber)other)._value);
        }

        public bool IsGreaterThan(IMyComparable other)
        {
            return (_value>((MyNumber)other)._value);
        }

        // ---------------------------------------------------------
        // MyNumber methods
        // ---------------------------------------------------------
        public override string ToString()
        {
            return (Value.ToString());
        }
    }
}
