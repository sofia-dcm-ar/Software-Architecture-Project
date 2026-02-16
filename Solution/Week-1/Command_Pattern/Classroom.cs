using System;
using MetodologíasDeProgramaciónI;
using Week4.People;

//Week 5 Exercise : Implement the classroom class to be the receiver to the commands.

namespace Week5.Command_Pattern
{
    /// <summary>
    /// Represents a classroom that manages a <see cref="Teacher"/> and student arrivals.
    /// </summary>
    /// <remarks>
    /// This class acts as the receiver in the Command Pattern implementation.
    /// It provides the bussines logic that is encapsulated by various <see cref="IClassroomCommand1"/> and <see cref="IClassroomCommand2"/> 
    /// objects, wich are stored and triggered by an <see cref="IOrderable"/> collection.
    /// </remarks>
    public class Classroom
    {
        private Teacher _teacher;

        public Classroom() { }

        /// <summary>
        /// Initializes the <see cref="Teacher"/> and displays an open classroom message.
        /// </summary>
        public void Start()
        {
            Console.WriteLine("\nClassroom is open");
            _teacher=new Teacher();
        }

        /// <summary>
        /// Adds an <see cref="IAlumno"/> to the notify collection managed by the <see cref="Teacher"/>.
        /// </summary>
        /// <param name="alumno">The <see cref="IAlumno"/> that is added to the collection.</param>
        public void AddAlumno(IAlumno alumno)
        {
            Console.WriteLine("\nStudent send to classroom");
            _teacher.goToClass(new AlumnoAdapter(alumno)); 
        }

        /// <summary>
        /// Signals the <see cref="Teacher"/> to begin teaching the class.
        /// </summary>
        public void ReadyClass()
        {
            Console.WriteLine("\nClassroom full, starting class");
            _teacher.teachingAClass();
        }
    }
}
