using System;
//Week 1 Exercise: Create a student that is a Person.
//NOTE: "Alumno" stays in spanish for future Adapter pattern exercise.

namespace Week1
{
    /// <summary>
    /// Represents a Student entity that extends <see cref="Person"/> with academic attributes.
    /// </summary>
    /// <remarks>
    /// Inherits comparison logic from <see cref="Person"/> and implements specific student behaviors.
    /// </remarks>
    public class Alumno : Person, IMyComparable
    {
        private int _fileNumber;
        private double _average;

        public Alumno(string name, int id, int fileNumber, double average) : base(name, id)
        {
            _fileNumber=fileNumber;
            _average=average;
        }

        public int FileNumber { get => _fileNumber; }
        public double Average { get => _average; }

        // ---------------------------------------------------------
        // IMyComparable Implementation
        // ---------------------------------------------------------
        public override bool IsEqual(IMyComparable other)
        {
            return _fileNumber==((Alumno)other)._fileNumber;
        }

        public override bool IsLessThan(IMyComparable other)
        {
            return _fileNumber<((Alumno)other)._fileNumber;
        }

        public override bool IsGreaterThan(IMyComparable other)
        {
            return _fileNumber>((Alumno)other)._fileNumber;
        }

        // ---------------------------------------------------------
        // Alumno methods
        // ---------------------------------------------------------
        public override string ToString()
        {
            return base.ToString()+"\nStudent File Number: "+_fileNumber.ToString()+"\nAverage: "+((float)_average).ToString("F2");
            
        }
    }
}
