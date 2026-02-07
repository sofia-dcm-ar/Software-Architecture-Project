using System;

//Week 3 Exercise: Implemments the observer pattern for professor and Alumno interaction

namespace Week3.Observer_Pattern
{
    /// <summary>
    /// Defines a provider for push-style notifications following the Observer Pattern.
    /// </summary>
    /// <remarks>
    /// Objects implementing this interface act as subscribers that react to changes in an <see cref="IObservable"/> instance.
    /// </remarks>
    public interface IObserver
    {
        /// <summary>
        /// Updates the <see cref="IObserver"/> with the latest state from the <see cref="IObservable"/>.
        /// </summary>
        /// <param name="observable">The source of the notification.</param>
        void Update(IObservable observable); 
    }
}
