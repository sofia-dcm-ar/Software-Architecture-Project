using System;
using Week1.People;
using Week4.People;

namespace Week2.Strategy_Pattern
{
    //Week 2 STRATEGY -> Concrete Strategy: AverageComparison

    /// <summary>
    /// Implements a concrete comparison strategy for <see cref="IAlumno"/> objects based on their Average attribute.
    /// </summary>
    /// <remarks>
    /// Inherits the comparison contract from <see cref="IComparisonStrategy"/>.
    /// </remarks>

    public class AverageComparison : IComparisonStrategy
    {
        public AverageComparison() { }

        public bool IsEqual(IAlumno alumno1, IAlumno alumno2)
        {
            return (alumno1.Average == alumno2.Average);
        }
        public bool IsLessThan(IAlumno alumno1, IAlumno alumno2)
        {
            return (alumno1.Average < alumno2.Average);
        }
        public bool IsGreaterThan(IAlumno alumno1, IAlumno alumno2)
        {
            return (alumno1.Average > alumno2.Average);
        }
    }
}
