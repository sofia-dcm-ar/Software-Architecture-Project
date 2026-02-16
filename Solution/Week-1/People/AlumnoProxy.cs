using System;
using System.Security.Cryptography;
using Week1;
using Week2.Strategy_Pattern;
using Week3.FactoryMethod_Pattern;
using Week3.Observer_Pattern;
using Week4.People;

//Week 5 Exercise: Create a Alumno following the Proxy pattern
// The Proxy should have name.
// Only be created when needs to answer a question using AnswerQuestion method.

namespace Week5.People
{
    /// <summary>
    /// Acts as a surrogate or placeholder for a <see cref="IAlumno"/> object to control access to its data.
    /// </summary>
    /// <remarks>
    /// This Proxy maintains the student's <see cref="Name"/> as its only locally stored attribute. 
    /// All other behaviors require the real <see cref="IAlumno"/> instance, which is instantiated 
    /// only when <see cref="AnswerQuestion"/> is called; otherwise, any interaction 
    /// with uninitialized members will result in a <see cref="NullReferenceException"/>.
    /// </remarks>
    public class AlumnoProxy : IAlumno
    {
        private IAlumno _realAlumno; 
        private string _name;
        private int _option; //for create the IAlumno selected ( 2 Alumno )( 4 DiligentAlumno )( 5 AlumnoBaseDecorator )( 6 DiligentAlumnoBaseDecorator )

        public AlumnoProxy(string name, int option)
        {
            _name=name;
            _option=option;
        }

        public int Id 
        {
            get 
            {
                if (_realAlumno == null)
                    throw new NullReferenceException("The real alumno doesn't exist yet.");

                return _realAlumno.Id;
            }
        }

        /// <summary>
        /// Gets or sets the student's name.
        /// </summary>
        /// <remarks>
        /// This is the only attribute maintained locally by the proxy before the 
        /// real subject is instantiated.
        /// </remarks>
        public string Name
        {
            get => _name;
            set
            {
                if (_realAlumno != null)
                    _realAlumno.Name = value;

                _name = value;
            }
        } 

        public int FileNumber 
        {
            get
            {
                if (_realAlumno == null)
                    throw new NullReferenceException("The real alumno doesn't exist yet.");

                return _realAlumno.FileNumber;
            }
        }

        public double Average
        {
            get
            {
                if (_realAlumno == null)
                    throw new NullReferenceException("The real alumno doesn't exist yet.");

                return _realAlumno.Average;
            }
        }

        public int Calification
        {
            get
            {
                if (_realAlumno == null)
                    throw new NullReferenceException("The real alumno doesn't exist yet.");

                return _realAlumno.Calification;
            }
            set
            {
                if (_realAlumno == null)
                    throw new NullReferenceException("The real alumno doesn't exist yet.");

                _realAlumno.Calification = value;
            }
        }

        // ---------------------------------------------------------
        // IMyComparable Implementation
        // ---------------------------------------------------------

        public bool IsEqual(IMyComparable comparable)
        {
            if (_realAlumno==null)
                throw new NullReferenceException("The real alumno doesn't exist yet.");

            return _realAlumno.IsEqual(comparable);
        }
        public bool IsLessThan(IMyComparable comparable)
        {
            if (_realAlumno==null)
                throw new NullReferenceException("The real alumno doesn't exist yet.");

            return _realAlumno.IsLessThan(comparable);
        }
        public bool IsGreaterThan(IMyComparable comparable)
        {
            if (_realAlumno==null)
                throw new NullReferenceException("The real alumno doesn't exist yet.");

            return _realAlumno.IsGreaterThan(comparable);
        }

        // ---------------------------------------------------------
        // Observer Pattern Implementation (IObserver)
        // ---------------------------------------------------------
        
        public void Update(IObservable observable)
        {
            if (_realAlumno==null)
                throw new NullReferenceException("The real alumno doesn't exist yet.");

            _realAlumno.Update(observable);
        }

        // ---------------------------------------------------------
        // Strategy Pattern Implementation
        // ---------------------------------------------------------
        
        public void SetStrategy(IComparisonStrategy strategy)
        {
            if (_realAlumno==null)
                throw new NullReferenceException("The real alumno doesn't exist yet.");

            _realAlumno.SetStrategy(strategy);
        }

        // ---------------------------------------------------------
        // Proxy Pattern Implementation
        // ---------------------------------------------------------

        /// <summary>
        /// Generates a random <see cref="int"/> representing an answer to a question for exam simulation.
        /// Ensures that the real <see cref="IAlumno"/> instance is created and initialized.
        /// </summary>
        /// <param name="question">The question number being answered.</param>
        /// <remarks>
        /// This method implements the <c>Lazy Loading</c> pattern. It checks if the <see cref="_realAlumno"/> is null 
        /// and instantiates it only upon the first request, optimizing memory usage and startup time.
        /// </remarks>
        /// <returns>A random <see cref="int"/> between 1 (lowest score) and 3 (Higuest score).</returns>
        public int AnswerQuestion(int question)         
        {
            if (_realAlumno==null)
                CreateProxy();

            return _realAlumno.AnswerQuestion(question);
        }

        // ---------------------------------------------------------
        // Alumno methods (IAlumno)
        // ---------------------------------------------------------
        public void PayAttention()
        {
            if (_realAlumno==null)
                throw new NullReferenceException("The real alumno doesn't exist yet.");

            _realAlumno.PayAttention();
        }

        public void LoseFocus()
        {
            if (_realAlumno==null)
                throw new NullReferenceException("The real alumno doesn't exist yet.");

            _realAlumno.LoseFocus();
        }

        public string ShowCalification()
        {
            if (_realAlumno==null)
                throw new NullReferenceException("The real alumno doesn't exist yet.");

            return _realAlumno.ShowCalification();
        }

        // ---------------------------------------------------------
        // AlumnoProxy methods
        // ---------------------------------------------------------
        //Create method, private because is only used internally
        private void CreateProxy()
        {
            _realAlumno=(IAlumno)MyComparableFactory.RandomCreate(_option);
            _realAlumno.Name = _name;
            Console.WriteLine("<< Real IAlumno created >>");
        }
    }
}
