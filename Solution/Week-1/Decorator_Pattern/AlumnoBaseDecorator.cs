using System;
using Week1;
using Week1.People;
using Week4.People;
using Week2.Strategy_Pattern;
using Week3.Observer_Pattern;

//Week 4 Exercise:  Implement the decorator pattern to show califications
//Base decorator class that implements IAlumno and contains a reference to an IAlumno object

namespace Week4.Decorator_Pattern
{
    /// <summary>
    /// A wrapper class for an <see cref="IAlumno"/> with specific decoration logic following the Decorator Pattern.
    /// </summary>
    /// <remarks> 
    /// This class allows an <see cref="IAlumno"/> object to delegate the calification display logic to concrete decorators.
    /// </remarks>
    public abstract class AlumnoBaseDecorator : IAlumno
    {
        private IAlumno _wrappee;
        public AlumnoBaseDecorator(IAlumno alumno)
        {
            this._wrappee = alumno;
        }

        public string Name { get => _wrappee.Name; set => _wrappee.Name = value; }
        public int Id { get => _wrappee.Id; }
        public int FileNumber { get => _wrappee.FileNumber; }
        public double Average { get => _wrappee.Average; }
        public int Calification { get => _wrappee.Calification; set => _wrappee.Calification = value; }

        // ---------------------------------------------------------
        // IMyComparable Implementation
        // ---------------------------------------------------------
        public bool IsEqual(IMyComparable comparable)
        {
            return this._wrappee.IsEqual(comparable);
        }

        public bool IsLessThan(IMyComparable comparable)
        {
            return this._wrappee.IsLessThan(comparable);
        }

        public bool IsGreaterThan(IMyComparable comparable)
        {
            return this._wrappee.IsGreaterThan(comparable);
        }

        // ---------------------------------------------------------
        // Observer Pattern Implementation (IObserver)
        // ---------------------------------------------------------
        public void Update(IObservable observable)
        {
            this._wrappee.Update(observable);
        }

        // ---------------------------------------------------------
        // Strategy Pattern Implementation
        // ---------------------------------------------------------
        public void SetStrategy(IComparisonStrategy strategy)
        {
            this._wrappee.SetStrategy(strategy);
        }

        //----------------------------------------------------------
        // Decorator Pattern Implementation
        //----------------------------------------------------------
        public virtual string ShowCalification() //Decorator method to be override
        { 
            return this._wrappee.ShowCalification();
        }

        // ---------------------------------------------------------
        // Alumno methods
        // ---------------------------------------------------------
        public void PayAttention()
        {
            this._wrappee.PayAttention();
        }

        public void LoseFocus()
        {
            this._wrappee.LoseFocus();
        }

        public int AnswerQuestion(int question)
        {
            return this._wrappee.AnswerQuestion(question);
        }
    }
}
