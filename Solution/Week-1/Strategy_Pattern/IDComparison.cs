using System;
using Week1;

namespace Week2.Strategy_Pattern
{
    //Week 2 STRATEGY -> Concrete Strategy: IDComparison

    /// <summary>
    /// Implements a concrete comparison strategy for <see cref="Alumno"/> objects based on their Id attribute.
    /// </summary>
    /// <remarks>
    /// Inherits the comparison contract from <see cref="IComparisonStrategy"/>.
    /// </remarks>
    public class IDComparison : IComparisonStrategy
    {
        public IDComparison() { }
        
        public bool IsEqual(Alumno alumno1, Alumno alumno2)
        {
            return (alumno1.Id== alumno2.Id);
        }

        public bool IsLessThan(Alumno alumno1, Alumno alumno2)
        {
            return (alumno1.Id< alumno2.Id);
        }

        public bool IsGreaterThan(Alumno alumno1, Alumno alumno2)
        {
            return (alumno1.Id> alumno2.Id);
        }
    }
}
