using System;
//Week 1 Exercise: Create an interface for objects that can compare themselves with others

namespace Week1
{
    /// <summary>
    /// Defines the contract for objects that can be compared for equality and ordering.
    /// </summary>
    /// <remarks>
    /// <para><strong>WARNING:</strong> Implementations of this interface should ensure that the object being compared 
    /// is of a compatible type. Attempting to compare incompatible types (e.g., a <c>MyNumber</c> with a <c>Person</c>) 
    /// may result in an <see cref="InvalidCastException"/>.</para>
    /// <para>It is highly recommended to perform a type check or use the <c>as</c> operator before accessing specific properties.</para>
    /// </remarks>
    public interface IMyComparable
    {
        /// <summary>
        /// Determines whether the current instance is equal to another <see cref="IMyComparable"/> object.
        /// </summary>
        /// <param name="other">The object to compare with the current instance.</param>
        /// <returns>True if the objects are considered equal; otherwise, false.</returns>
        bool IsEqual(IMyComparable other);

        /// <summary>
        /// Determines whether the current instance is less than another <see cref="IMyComparable"/> object.
        /// </summary>
        /// <param name="other">The object to compare with the current instance.</param>
        /// <returns>True if the current object is less; otherwise, false.</returns>

        bool IsLessThan(IMyComparable other);

        /// <summary>
        /// Determines whether the current instance is greater than another <see cref="IMyComparable"/> object.
        /// </summary>
        /// <param name="other">The object to compare with the current instance.</param>
        /// <returns>True if the current object is greater; otherwise, false.</returns>
        bool IsGreaterThan(IMyComparable other);

    }
}
