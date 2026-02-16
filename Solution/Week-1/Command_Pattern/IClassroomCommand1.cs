using System;

//Week 5 Exercise: Implemment the interfaces for commands.

namespace Week5.Command_Pattern
{
    /// <summary>
    /// Defines a command contract for <see cref="Classroom"/> actions that do not require additional data.
    /// </summary>
    public interface IClassroomCommand1
    {
        /// <summary>
        /// Executes the specific <see cref="Classroom"/> action encapsulated by this command.
        /// </summary>
        void Execute();
    }
}
