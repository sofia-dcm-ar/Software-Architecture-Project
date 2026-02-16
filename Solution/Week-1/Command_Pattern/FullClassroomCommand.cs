using System;

//Week 5 Exercise:Implement a new concrete command of IClassroomCommand1 interface

namespace Week5.Command_Pattern
{
    /// <summary>
    /// Concrete command that triggers the classroom maximum capacity logic.
    /// </summary>
    /// <remarks>
    /// This class implements <see cref="IClassroomCommand2"/> to wrap the <see cref="Classroom.ReadyClass"/> method, allowing it to be executed by an invoker.
    /// </remarks>
    internal class FullClassroomCommand : IClassroomCommand1
    {
        private Classroom _classroom;
        public FullClassroomCommand(Classroom classroom)
        {
            _classroom = classroom;
        }
        public void Execute()
        {
            _classroom.ReadyClass();
        }
    }
}
