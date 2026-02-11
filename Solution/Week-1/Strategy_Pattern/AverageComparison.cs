using System;
using Week1.People;

namespace Week2.Strategy_Pattern
{
    //Week 2 STRATEGY -> Concrete Strategy: AverageComparison

    /// <summary>
    /// Implements a concrete comparison strategy for <see cref="Alumno"/> objects based on their Average attribute.
    /// </summary>
    /// <remarks>
    /// Inherits the comparison contract from <see cref="IComparisonStrategy"/>.
    /// </remarks>

    public class AverageComparison : IComparisonStrategy
    {
        public AverageComparison() { }

        public bool IsEqual(Alumno alumno1, Alumno alumno2)
        {
            return (alumno1.Average == alumno2.Average);
        }
        public bool IsLessThan(Alumno alumno1, Alumno alumno2)
        {
            return (alumno1.Average < alumno2.Average);
        }
        public bool IsGreaterThan(Alumno alumno1, Alumno alumno2)
        {
            return (alumno1.Average > alumno2.Average);
        }
    }
}
