using System;
using Week1;
using Week3.Observer_Pattern;

// Week 3 Exercise: Create the Professor class, subclass of Person
// OBSERVER -> Make the Proffesor an observed Person

namespace Week3
{
    /// <summary>
    /// Represents a Professor entity that extends <see cref="Person"/> with academic job attributes.
    /// </summary>
    /// <remarks>
    /// Inherits comparison logic from <see cref="Person"/> and implements specific Professor behaviors.
    /// </remarks>
    public class Professor : Person , IObservable
    {
        private int _tenure;
        private List<IObserver> _alumnos;
        private bool _speaking; //The professor speaks or writes?

        public Professor(int tenure, string name, int id) : base(name, id)
        {
            this._tenure=tenure;
            this._alumnos = new List<IObserver>();
            this._speaking=false;
        }

        public int Tenure { get =>  _tenure; }
        public bool Speaking { get => _speaking; } //so that the student updates the professor's action

        // ---------------------------------------------------------
        // IMyComparable Implementation
        // ---------------------------------------------------------
        public override bool IsEqual(IMyComparable other)
        {
            return (_tenure==((Professor)other)._tenure);
        }

        public override bool IsLessThan(IMyComparable other)
        {
            return (_tenure<((Professor)other)._tenure);
        }

        public override bool IsGreaterThan(IMyComparable other)
        {
            return (_tenure>((Professor)other)._tenure);
        }

        // ---------------------------------------------------------
        // Observer Pattern Implementation (IObservable)
        // ---------------------------------------------------------

        public void Attach(IObserver o)
        {
            this._alumnos.Add(o);
        }

        public void Detach(IObserver o)
        {
            this._alumnos.Remove(o);
        }

        public void Notify()
        {
            foreach (IObserver o in _alumnos)
                o.Update(this);
        }

        // ---------------------------------------------------------
        // Professor methods
        // ---------------------------------------------------------
        public override string ToString()
        {
            return base.ToString()+string.Format("\nTenure : {0} year/s", _tenure);
        }

        /// <summary>
        /// Display a speaking message and notifies class listeners of the change in action state.
        /// </summary>
        /// <remarks>
        /// Change the speaking state and notify <see cref="IObserver"/> objects in the list.
        /// </remarks>
        public void SpeakToTheClass()
        {
            this.PrintTitle("Professor Action");
            Console.WriteLine("\nTalking to the class\n");
            this._speaking=true;
            this.PrintTitle("Alumnos Reactions");
            this.Notify();
        }

        /// <summary>
        /// Display writing on the board message and notifies class listeners of the change in action state.
        /// </summary>
        /// <remarks>
        /// Change the speaking state and notify <see cref="IObserver"/> objects in the list.
        /// </remarks>
        public void WriteInTheBoard()
        {
            this.PrintTitle("Professor Action");
            Console.WriteLine("\nWriting on the board\n");
            this._speaking=false;
            this.PrintTitle("Alumnos Reactions");
            this.Notify();
        }

        public void PrintTitle(string title)
        {
            Console.WriteLine("\n-----------------"+title+"-----------------\n");
        }
    }
}
