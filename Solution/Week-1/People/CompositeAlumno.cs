using System;
using System.Collections.Generic;
using System.Linq;
using Week1;
using Week2.Strategy_Pattern;
using Week3.Observer_Pattern;
using Week4.People;
using MetodologíasDeProgramaciónI;
using static System.Runtime.InteropServices.JavaScript.JSType;

//Week 6 Exercise: Create the Composite IAlumno using the composite pattern
// any IAlumno could be a child
//AnswerQuestion should return the most chosed answer for the children, not an average of answers

namespace Week6.People
{
    /// <summary>
    /// Represents a composite group of <see cref="IAlumno"/> objects.
    /// </summary>
    /// <remarks>
    /// This class follows the Composite Pattern, allowing a collection of students to be treated as a single student entity. 
    /// It aggregates the behavior of its children to provide collective results.
    /// </remarks>
    public class CompositeAlumno : IAlumno
    {
        private List<IAlumno> _children;

        public CompositeAlumno()
        {
            _children = new List<IAlumno>();
        }
        public string Name
        {
            get 
            { 
                string names = "";
                foreach (IAlumno child in _children)
                {
                    names += (child.Name+" , ");
                }
                return names;
            }
            set
            {
                foreach (IAlumno child in _children)
                    child.Name = value;
            }
        }

        public int Id { get { return 0; } }

        public int FileNumber { get { return 0; } }

        public double Average
        {
            get 
            {
                return _children.Average(child => child.Calification);
            }
        }

        public int Calification
        {
            get
            {
                double averageCalification = _children.Average(child => child.Calification);

                return (int)Math.Round(averageCalification, MidpointRounding.AwayFromZero);
            }
            set 
            {
                foreach (IAlumno child in _children)
                {
                    child.Calification = value;
                }
            }
        }

        // ---------------------------------------------------------
        // IMyComparable Implementation
        // ---------------------------------------------------------
        public bool IsEqual(IMyComparable c)
        {
            if (this == c) 
                return true;
            foreach (IAlumno child in _children)
            {
                if (child.IsEqual(c))
                    return true;
            }
            return false;
        }

        public bool IsLessThan(IMyComparable c)
        {
            foreach (IAlumno child in _children)
            {
                if (!child.IsLessThan(c))
                    return false;
            }
            return true;
        }

        public bool IsGreaterThan(IMyComparable c)
        {
            foreach (IAlumno child in _children)
            {
                if (!child.IsGreaterThan(c))
                    return false;
            }
            return true;
        }

        // ---------------------------------------------------------
        // Observer Pattern Implementation (IObserver)
        // ---------------------------------------------------------
        public void Update(IObservable observable)
        {
            foreach (IAlumno child in _children)
                child.Update(observable);
        }

        // ---------------------------------------------------------
        // Strategy Pattern Implementation
        // ---------------------------------------------------------
        public void SetStrategy(IComparisonStrategy strategy)
        {
            foreach (IAlumno child in _children)
                child.SetStrategy(strategy);
        }


        // ---------------------------------------------------------
        // IAlumno methods
        // ---------------------------------------------------------
        /// <summary>
        /// Calculates a collective answer by polling all children in the composite.
        /// </summary>
        /// <remarks>
        /// The method executes <see cref="IAlumno.AnswerQuestion"/> for each child and determines the final result based on a majority voting logic.
        /// </remarks>
        /// <param name="question">The question number provided by the <see cref="Teacher"/>.</param>
        /// <returns>The most frequent answer among the children, aligned with the expected solution format.</returns>
        public int AnswerQuestion(int question)
        {
            int[] answers = { 0, 0, 0 };
            int correctAnswer = question % 3;
            foreach (IAlumno child in _children)
            {
                int answer = child.AnswerQuestion(question);
                if (answer == correctAnswer) //for diligent alumno, always highest score
                    answers[2]++;
                else 
                    answers[child.AnswerQuestion(question) - 1]++; //for other alumnos, lowest or medium score
            }
            int actual = 1;
            if (answers[1] > answers[0])
                actual = 2;
            if (answers[2] > answers[1] && answers[2] >= answers[0]) 
                return correctAnswer;
            return actual;
        }

        /// <summary>
        /// Retrieves the califications of all students contained within the composite.
        /// </summary>
        /// <returns>A collection of strings containing the califications of every <see cref="IAlumno"/>.</returns>
        public string ShowCalification()
        {
            string califications = "";
            foreach (IAlumno child in _children)
            {
                califications += (child.ShowCalification()+"\n");
            }
            return califications;
        }

        public void PayAttention()
        {
            foreach (IAlumno child in _children)
                child.PayAttention();
        }

        public void LoseFocus()
        {
            foreach (IAlumno child in _children)
                child.LoseFocus();
        }

        // ---------------------------------------------------------
        // CompositeAlumno methods
        // ---------------------------------------------------------
        /// <summary>
        /// Adds an <see cref="IAlumno"/> to the end of the children list.
        /// </summary>
        /// <param name="child">The <see cref="IAlumno"/> instance to be added.</param>
        public void Add(IAlumno child)
        {
            _children.Add(child);
        }

        /// <summary>
        /// Returns the number of children in the list including the current <see cref="CompositeAlumno"/> instance.
        /// </summary>
        /// <param name="cant">The number of children above the current object.</param>
        /// <returns>Retuns the number of elements.</returns>
        public int Count(int cant = 1)
        {
            int i = cant;
            foreach (IAlumno child in _children)
            {
                i++;
                if (child is CompositeAlumno)
                    i=((CompositeAlumno)child).Count(i);
            }
            return i;
        }

        /// <summary>
        /// Removes the first ocurrence of an <see cref="IAlumno"/>. 
        /// </summary>
        /// <param name="alumno">The <see cref="IAlumno"/> to remove.</param>
        /// <param name="removed">A bool that advice if the removal was made. <see langword="true"/> if the instance was removed; otherwhise <see langword="false"/>.</param>
        /// <returns></returns>
        public bool Remove(IAlumno alumno, bool removed = false)
        {
            if (_children.Remove(alumno)) //remove directly if it's one direct children
                return true;
            foreach (IAlumno child in _children)
            {
                if (child is CompositeAlumno)
                { 
                    removed = ((CompositeAlumno)child).Remove(alumno, removed);
                    if (removed) 
                        return true;
                }
            }
            return false; 
        }
    }
}
