using System;
using Week1.People;
using Week4.People;

namespace Week2.Strategy_Pattern
{
    //Week 2 STRATEGY -> Concrete Strategy: FileNumberComparison

    /// <summary>
    /// Implements a concrete comparison strategy for <see cref="IAlumno"/> objects based on their File Number attribute.
    /// </summary>
    /// <remarks>
    /// Inherits the comparison contract from <see cref="IComparisonStrategy"/>.
    /// </remarks>
    internal class FileNumberComparison : IComparisonStrategy
    {
        public FileNumberComparison() { }

        public bool IsEqual(IAlumno alumno1, IAlumno alumno2)
        {
            return (alumno1.FileNumber == alumno2.FileNumber);
        }

        public bool IsLessThan(IAlumno alumno1, IAlumno alumno2)
        {
            return (alumno1.FileNumber < alumno2.FileNumber);
        }

        public bool IsGreaterThan(IAlumno alumno1, IAlumno alumno2)
        {
            return (alumno1.FileNumber > alumno2.FileNumber);
        }
    }
}
