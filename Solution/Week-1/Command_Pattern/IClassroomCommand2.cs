using System;
using Week1;

//Week 5 Exercise: Implemment the interfaces for commands.

namespace Week5.Command_Pattern
{
    /// <summary>
    /// Defines a command contract for <see cref="Classroom"/> actions that requires student data (an <see cref="IMyComparable"/>).
    /// </summary>
    public interface IClassroomCommand2
    {
        /// <summary>
        /// Executes the specific <see cref="Classroom"/> action encapsulated by this command using the provided student data.
        /// </summary>
        /// <param name="comparable">The <see cref="IMyComparable"/> object representing the student involved in the action.</param>
        void Execute(IMyComparable comparable);
    }
}
