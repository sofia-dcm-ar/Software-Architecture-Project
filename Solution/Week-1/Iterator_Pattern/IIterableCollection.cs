using System;
using Week1.MyCollections;

namespace Week2.Iterator_Pattern
{
    //Week 2 Exercise -> Implement the Iterator Pattern for collections

    /// <summary>
    /// Defines the contract to create concrete iterators for a collection following the Iterator Pattern.
    /// </summary>
    /// <remarks>
    /// This interface allows the <see cref="IMyCollection"/> to create its corresponding concrete iterator.
    /// </remarks>

    public interface IIterableCollection
    {
        /// <summary>
        /// Create the concrete iterator for the current collection.
        /// </summary>
        /// <returns>A concrete <see cref="IIterator"/> instance.</returns>
        IIterator CreateIterator();
    }
}
