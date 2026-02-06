using System;
using Week1;

namespace Week2.Strategy_Pattern
{
    //Week 2 STRATEGY -> Implement four comparison strategies for Alumnos

    /// <summary>
    /// Defines the contract for object comparison logic following the Strategy Pattern.
    /// </summary>
    /// <remarks>
    /// This interface allows <see cref="Alumno"/> to delegate its comparison logic to specialized classes, enabling dynamic behavior changes at runtime.
    /// </remarks>
    public interface IComparisonStrategy
    {
        /// <summary>
        /// Compares two <see cref="Alumno"/> instances to determine their equality.
        /// </summary>
        /// <param name="alumno1">The primary student instance acting as the reference for the comparison.</param>
        /// <param name="alumno2">The student instance to compare against the reference.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="alumno1"/> is equal to <paramref name="alumno2"/>; otherwise, <see langword="false"/>.
        /// </returns>
        bool IsEqual(Alumno alumno1, Alumno alumno2);

        /// <summary>
        /// Compares two <see cref="Alumno"/> instances to determine their relative order.
        /// </summary>
        /// <param name="alumno1">The primary student instance acting as the reference for the comparison.</param>
        /// <param name="alumno2">The student instance to compare against the reference.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="alumno1"/> is smaller than <paramref name="alumno2"/>; otherwise, <see langword="false"/>.
        /// </returns>
        bool IsLessThan(Alumno alumno1, Alumno alumno2);

        /// <summary>
        /// Compares two <see cref="Alumno"/> instances to determine their relative order.
        /// </summary>
        /// <param name="alumno1">The primary student instance acting as the reference for the comparison.</param>
        /// <param name="alumno2">The student instance to compare against the reference.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="alumno1"/> is larger than <paramref name="alumno2"/>; otherwise, <see langword="false"/>.
        /// </returns>
        bool IsGreaterThan(Alumno alumno1, Alumno alumno2);
    }
}
