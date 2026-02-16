using System;
using Week1;
using Week4.People;

//Week 5 Exercise:Implement a new concrete command of IClassroomCommand2 interface

namespace Week5.Command_Pattern
{
    /// <summary>
    /// Concrete command that triggers the classroom alumno arrival logic.
    /// </summary>
    /// <remarks>
    /// This class implements <see cref="IClassroomCommand2"/> to wrap the <see cref="Classroom.AddAlumno"/> method, allowing it to be executed by an invoker.
    /// </remarks>
    public class AlumnoArrivalCommand : IClassroomCommand2
    {
        private Classroom _classroom;
        public AlumnoArrivalCommand(Classroom classroom)
        {
            _classroom = classroom;
        }
        public void Execute(IMyComparable comparable)
        {
            _classroom.AddAlumno((IAlumno)comparable);
        }
    }
}
