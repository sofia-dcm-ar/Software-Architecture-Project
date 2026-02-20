using System;
using Week1;
using Week2.Strategy_Pattern;
using Week3.Observer_Pattern;
using Week4.People;
//Week 4 Exercise: Add calification attribute 
//NOTE: "Alumno" stays in spanish for future Adapter pattern exercise.

namespace Week1.People
{
    /// <summary>
    /// Represents a Student entity that extends <see cref="Person"/> with academic attributes.
    /// </summary>
    /// <remarks>
    /// Inherits basic attributes from <see cref="Person"/>, implements specific student behaviors, and delegates comparison logic to concrete classes that change in runtime.
    /// </remarks>
    public class Alumno : Person, IAlumno
    {
        private int _fileNumber;
        private double _average;
        private IComparisonStrategy _strategy;
        private int _calification;

        public Alumno(string name, int id, int fileNumber, double average) : base(name, id)
        {
            _fileNumber=fileNumber;
            _average=average;
            _strategy= new IDComparison();
            _calification=0;
        }

        public int FileNumber { get => _fileNumber; }
        public double Average { get => _average; }
        public int Calification { get => _calification; set => _calification = value; } // Week 4

        // ---------------------------------------------------------
        // IMyComparable Implementation
        // ---------------------------------------------------------
        // Week 2: now delegate to Strategy Pattern Comparison
        public override bool IsEqual(IMyComparable other)
        {
            return _strategy.IsEqual(this, (IAlumno)other);
        }

        public override bool IsLessThan(IMyComparable other)
        {
            return _strategy.IsLessThan(this, (IAlumno)other);
        }

        public override bool IsGreaterThan(IMyComparable other)
        {
            return _strategy.IsGreaterThan(this, (IAlumno)other);
        }

        // ---------------------------------------------------------
        // Observer Pattern Implementation (IObserver)
        // ---------------------------------------------------------
        public void Update(IObservable observable)
        {
            if (((Professor)observable).Speaking)
                PayAttention();
            else
                LoseFocus();
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

        public void PayAttention()
        {
            Console.WriteLine("Paying Attention");
        }

        public void LoseFocus()
        {
            Random r = new Random();
            string[] actions = { "Looking out the window", "Checking the phone", "Drawing in the margin of the folder", "Throwing paper airplanes" };
            Console.WriteLine(actions[r.Next(2)]);
        }

        /// <summary>
        /// Generates a random <see cref="int"/> representing an answer to a question for exam simulation.
        /// </summary>
        /// <param name="question">The question number being answered.</param>
        /// <returns>A random <see cref="int"/> between 1 (lowest score) and 2 (medium score).</returns>
        public virtual int AnswerQuestion(int question) // Week 4
        {
            Random r = new Random();
            return r.Next(1, 3);
        }

        public string ShowCalification()
        {
            return string.Format("{0}     {1}", _name, _calification);
        }
    }
}
