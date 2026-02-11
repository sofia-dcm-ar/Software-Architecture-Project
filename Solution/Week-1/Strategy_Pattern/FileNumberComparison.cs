using System;
using Week1.People;

namespace Week2.Strategy_Pattern
{
    //Week 2 STRATEGY -> Concrete Strategy: FileNumberComparison

    /// <summary>
    /// Implements a concrete comparison strategy for <see cref="Alumno"/> objects based on their File Number attribute.
    /// </summary>
    /// <remarks>
    /// Inherits the comparison contract from <see cref="IComparisonStrategy"/>.
    /// </remarks>
    internal class FileNumberComparison : IComparisonStrategy
    {
        public FileNumberComparison() { }

        public bool IsEqual(Alumno alumno1, Alumno alumno2)
        {
            return (alumno1.FileNumber == alumno2.FileNumber);
        }

        public bool IsLessThan(Alumno alumno1, Alumno alumno2)
        {
            return (alumno1.FileNumber < alumno2.FileNumber);
        }

        public bool IsGreaterThan(Alumno alumno1, Alumno alumno2)
        {
            return (alumno1.FileNumber > alumno2.FileNumber);
        }
    }
}
