using System;

//Week 5 Exercise:Implement a new concrete command of IClassroomCommand1 interface

namespace Week5.Command_Pattern
{
    /// <summary>
    /// Concrete command that triggers the classroom start logic.
    /// </summary>
    /// <remarks>
    /// This class implements <see cref="IClassroomCommand1"/> to wrap the <see cref="Classroom.Start"/> method, allowing it to be executed by an invoker.
    /// </remarks>
    internal class StartCommand : IClassroomCommand1
    {
        private Classroom _classroom;
        public StartCommand(Classroom classroom)
        {
            _classroom = classroom;
        }
        public void Execute()
        {
            _classroom.Start();
        }
    }
}
