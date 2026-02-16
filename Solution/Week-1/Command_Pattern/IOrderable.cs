using System;
using Week1.MyCollections;

//Week 5 Exercise: Create an interface for those classes that are gonna be commanded following the command pattern

namespace Week5.Command_Pattern
{
    /// <summary>
    /// Defines the contract for command objects following the Command Pattern.
    /// </summary>
    /// <remarks>
    /// This interface allows <see cref="IMyCollection"/> to add new behavior by command.
    /// </remarks>
    /// <remarks>
    /// This interface enables <see cref="IMyCollection"/> to extend its functionality dynamically by encapsulating requests as standalone objects.
    /// </remarks>
    public interface IOrderable
    {
        /// <summary>
        /// Sets the command to be executed when the collection process starts.
        /// </summary>
        /// <param name="command">An <see cref="IClassroomCommand1"/> representing the start action.</param>
        void SetStartCommand(IClassroomCommand1 command);

        /// <summary>
        /// Sets the command to be executed whenever a new student arrives at the collection.
        /// </summary>
        /// <param name="command">An <see cref="IClassroomCommand2"/> that handles the student arrival logic.</param>
        void SetAlumnoArrivalCommand(IClassroomCommand2 command);

        /// <summary>
        /// Sets the command to be executed when the collection reaches its maximum capacity.
        /// </summary>
        /// <param name="command">An <see cref="IClassroomCommand1"/> representing the full capacity action.</param>
        void SetFullClassroomCommand(IClassroomCommand1 command);
    }
}
