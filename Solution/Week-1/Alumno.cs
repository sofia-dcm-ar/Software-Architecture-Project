using System;
using Week2.Strategy_Pattern;
//Week 2 Exercise: Implements the Strategy pattern to allow different comparison criteria based on student attributes.
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
        private IComparisonStrategy _strategy; //Week 2: create a strategy attribute

        public Alumno(string name, int id, int fileNumber, double average) : base(name, id)
        {
            _fileNumber=fileNumber;
            _average=average;
            _strategy= new IDComparison();//Week 2: initialize with a default strategy
        }

        public int FileNumber { get => _fileNumber; }
        public double Average { get => _average; }

        // ---------------------------------------------------------
        // IMyComparable Implementation
        // ---------------------------------------------------------
        // Week 2: now delegate to Strategy Pattern Comparison
        public override bool IsEqual(IMyComparable other)
        {
            return _strategy.IsEqual(this, (Alumno)other);
        }

        public override bool IsLessThan(IMyComparable other)
        {
            return _strategy.IsLessThan(this, (Alumno)other);
        }

        public override bool IsGreaterThan(IMyComparable other)
        {
            return _strategy.IsGreaterThan(this, (Alumno)other);
        }

        // ---------------------------------------------------------
        // Strategy Pattern Implementation
        // ---------------------------------------------------------

        public void SetStrategy(IComparisonStrategy newStrategy)
        {
            _strategy=newStrategy;
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
