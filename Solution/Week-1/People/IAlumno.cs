using System;
using Week1;
using Week2.Strategy_Pattern;
using Week3.Observer_Pattern;

// Week 4 Exercise: Implement a interface for adapter and decorator pattern

namespace Week4.People
{
    /// <summary>
    /// Defines the contract for objects that has student behavior and attributes.
    /// </summary>
    /// <remarks>
    /// Inherites the comparison contract from <see cref="IMyComparable"/> and the observer behavior contract from <see cref="IObserver"/>.
    /// </remarks>
    public interface IAlumno : IMyComparable, IObserver
    {
        string Name { get; }
        int Id { get; }
        int FileNumber { get; }
        double Average { get; }
        int Calification { get; set; }
        void SetStrategy(IComparisonStrategy strategy);
        /// <summary>
        /// Causes the current object to pay attention to the class.
        /// </summary>
        /// <remarks>
        /// This method simulates paying attention displaying a message.
        /// </remarks>
        void PayAttention();
        /// <summary>
        /// Causes the current object to lose focus and perform a random distraction action.
        /// </summary>
        /// <remarks>
        /// This method simulates a loss of focus by selecting and displaying a random distraction action. 
        /// </remarks>
        void LoseFocus();
        /// <summary>
        /// Generates a random <see cref="int"/> representing an answer to a question for exam simulation.
        /// </summary>
        /// <param name="question">The question number being answered.</param>
        /// <returns>A random <see cref="int"/> between 1 (lowest score) and 2 (medium score).</returns>
        int AnswerQuestion(int question);
        string ShowCalification();
    }
}
