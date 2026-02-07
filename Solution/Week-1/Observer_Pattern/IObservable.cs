using System;

//Week 3 Exercise: Implemments the observer pattern for professor and Alumno interaction

namespace Week3.Observer_Pattern
{
    /// <summary>
    /// Defines the contract for an object that maintains a list of <see cref="IObserver"/> and notifies them of state changes.
    /// </summary>
    /// <remarks>
    /// Also known as the "Subject" in the Observer Pattern.
    /// </remarks>
    public interface IObservable
    {
        /// <summary>
        /// Adds an <see cref="IObserver"/> to the notification list.
        /// </summary>
        /// <param name="observer">The observer to be registered.</param>
        void Attach(IObserver observer);

        /// <summary>
        /// Removes an <see cref="IObserver"/> from the notification list.
        /// </summary>
        /// <param name="observer">The observer to be unregistered.</param>
        void Detach(IObserver observer);

        /// <summary>
        /// Notifies all registered <see cref="IObserver"/> about a change in state.
        /// </summary>
        void Notify();
    }
}
