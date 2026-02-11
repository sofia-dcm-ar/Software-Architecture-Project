using MetodologíasDeProgramaciónI;
using System;
using Week1;
using Week1.People;

//Week 4 Exercise: Implement the Adapter Pattern
// An adapter for alumno(Adaptable) that can behave like Student (Target)
//NOTE: Student is defined in MDPI.cs. For this reason "Alumno" wasn´t translated to English
//In class , the exercise was to conect our spanish code to an english library, in this case, the MDPI.cs file so "Student".

namespace Week4.People
{
    /// <summary>
    /// Adapts an <see cref="IAlumno"/> object to the <see cref="Student"/> interface.
    /// </summary>
    /// <remarks>
    /// This adapter allows the <see cref="Teacher"/> class to interact with <see cref="IAlumno"/> implementations using the <see cref="Student"/> contract 
    /// without modifying the original class hierarchy.
    /// </remarks>
    public class AlumnoAdapter : Student
    {
        private IAlumno _alumno;
        public AlumnoAdapter(IAlumno alumno)
        {
            _alumno = alumno;
        }

        public string getName()
        {
            return _alumno.Name;
        }
        public void setScore(int score)
        {
            _alumno.Calification = score;
        }

        // ---------------------------------------------------------
        // IMyComparable Implementation
        // ---------------------------------------------------------
        public bool equals(Student student)
        {
            return _alumno.IsEqual(((AlumnoAdapter)student)._alumno);
        }

        public bool lessThan(Student student)
        {
            return _alumno.IsLessThan(((AlumnoAdapter)student)._alumno);
        }

        public bool greaterThan(Student student)
        {
            return _alumno.IsGreaterThan(((AlumnoAdapter)student)._alumno);
        }

        // ---------------------------------------------------------
        // Student Methods
        // ---------------------------------------------------------
        public int yourAnswerIs(int question)
        {
            return _alumno.AnswerQuestion(question);
        }
        public string showResult()
        {
            return _alumno.ShowCalification();
        }


    }
}
