using System;
using Week1;

namespace Week2.Strategy_Pattern
{
    //Week 2 STRATEGY -> Concrete Strategy: Name Comparison

    /// <summary>
    /// Implements a concrete comparison strategy for <see cref="Alumno"/> objects based on their File Number attribute.
    /// </summary>
    /// <remarks>
    /// Inherits the comparison contract from <see cref="IComparisonStrategy"/>.
    /// </remarks>
    public class NameComparison : IComparisonStrategy
    {
        public NameComparison() { }

        public bool IsEqual(Alumno alumno1, Alumno alumno2)
        {
            return (alumno1.Name == alumno2.Name);
        }
        public bool IsLessThan(Alumno alumno1, Alumno alumno2)
        {
            return (String.Compare(alumno1.Name.ToUpper(), alumno2.Name.ToUpper()) <= -1);
        }
        public bool IsGreaterThan(Alumno alumno1, Alumno alumno2)
        {
            return (String.Compare(alumno1.Name.ToUpper(), alumno2.Name.ToUpper()) > 0);
        }
    }
}
