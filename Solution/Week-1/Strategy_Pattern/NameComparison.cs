using System;
using Week1.People;
using Week4.People;

namespace Week2.Strategy_Pattern
{
    //Week 2 STRATEGY -> Concrete Strategy: Name Comparison

    /// <summary>
    /// Implements a concrete comparison strategy for <see cref="IAlumno"/> objects based on their File Number attribute.
    /// </summary>
    /// <remarks>
    /// Inherits the comparison contract from <see cref="IComparisonStrategy"/>.
    /// </remarks>
    public class NameComparison : IComparisonStrategy
    {
        public NameComparison() { }

        public bool IsEqual(IAlumno alumno1, IAlumno alumno2)
        {
            return (alumno1.Name == alumno2.Name);
        }
        public bool IsLessThan(IAlumno alumno1, IAlumno alumno2)
        {
            return (String.Compare(alumno1.Name.ToUpper(), alumno2.Name.ToUpper()) <= -1);
        }
        public bool IsGreaterThan(IAlumno alumno1, IAlumno alumno2)
        {
            return (String.Compare(alumno1.Name.ToUpper(), alumno2.Name.ToUpper()) > 0);
        }
    }
}
