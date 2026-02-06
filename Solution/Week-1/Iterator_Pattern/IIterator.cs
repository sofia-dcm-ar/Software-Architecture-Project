using System;
using static System.Net.Mime.MediaTypeNames;

namespace Week2.Iterator_Pattern
{
    //Week 2 Exercise -> Implement the Iterator Pattern for collections

    /// <summary>
    /// Defines the contract for collection iteration logic following the Iterator Pattern.
    /// </summary>
    /// <remarks>
    /// This interface allows <see cref="IMyCollection"/> to delegate its iteration logic to specialized classes to avoid exposing its internal structure.
    /// </remarks>
    public interface IIterator
    {
        /// <summary>
        /// Resets the iterator by setting the first element of the collection as the current element.
        /// </summary>
        void First();

        /// <summary>
        /// Advances the iterator to the next element of the collection.
        /// </summary>
        void Next();

        /// <summary>
        /// Determines whether the iteration has reached the end of the collection.
        /// </summary>
        /// <returns><see langword="true"/> if the iteration is complete; otherwise, <see langword="false"/>.</returns>
        bool IsDone();

        /// <summary>
        /// Gets the current element in the iteration.
        /// </summary>
        /// <returns>The current <see cref="IMyComparable"/> object.</returns>
        IMyComparable CurrentItem(); 
    }
}
