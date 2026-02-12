using System;
using Week1.People;
using Week4.People;

namespace Week2.Strategy_Pattern
{
    //Week 2 STRATEGY -> Concrete Strategy: IDComparison

    /// <summary>
    /// Implements a concrete comparison strategy for <see cref="IAlumno"/> objects based on their Id attribute.
    /// </summary>
    /// <remarks>
    /// Inherits the comparison contract from <see cref="IComparisonStrategy"/>.
    /// </remarks>
    public class IDComparison : IComparisonStrategy
    {
        public IDComparison() { }
        
        public bool IsEqual(IAlumno alumno1, IAlumno alumno2)
        {
            return (alumno1.Id== alumno2.Id);
        }

        public bool IsLessThan(IAlumno alumno1, IAlumno alumno2)
        {
            return (alumno1.Id< alumno2.Id);
        }

        public bool IsGreaterThan(IAlumno alumno1, IAlumno alumno2)
        {
            return (alumno1.Id> alumno2.Id);
        }
    }
}
