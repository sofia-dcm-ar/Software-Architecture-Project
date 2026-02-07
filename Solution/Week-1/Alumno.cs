using System;
using Week2.Strategy_Pattern;
using Week3;
using Week3.Observer_Pattern;
//Week 3 Exercise: Implements the Observer pattern to allow the student observe the Professor.
//NOTE: "Alumno" stays in spanish for future Adapter pattern exercise.

namespace Week1
{
    /// <summary>
    /// Represents a Student entity that extends <see cref="Person"/> with academic attributes.
    /// </summary>
    /// <remarks>
    /// Inherits comparison logic from <see cref="Person"/> and implements specific student behaviors.
    /// </remarks>
    public class Alumno : Person, IObserver
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
        // Observer Pattern Implementation (IObserver)
        // ---------------------------------------------------------
        public void Update(IObservable observable)
        {
            if (((Professor)observable).Speaking)
                this.PayAttention();
            else
                this.LoseFocus();
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

        /// <summary>
        /// Causes the current object to pay attention to the class.
        /// </summary>
        /// <remarks>
        /// This method simulates paying attention displaying a message.
        /// </remarks>
        public void PayAttention()
        {
            Console.WriteLine("Paying Attention");
        }

        /// <summary>
        /// Causes the current object to lose focus and perform a random distraction action.
        /// </summary>
        /// <remarks>
        /// This method simulates a loss of focus by selecting and displaying a random distraction action. 
        /// </remarks>
        public void LoseFocus()
        {
            Random r = new Random();
            string[] actions = { "Looking out the window", "Checking the phone", "Drawing in the margin of the folder", "Throwing paper airplanes" };
            Console.WriteLine(actions[r.Next(2)]);
        }

    }
}
