using System;
using Week2;
using Week2.Iterator_Pattern;

namespace Week1.MyCollections
{
    /// <summary>
    /// Defines the contract for a collection of <see cref="IMyComparable"/> elements. Provides methods of search, count, addition and comparison.
    /// </summary>
    /// <remarks>
    /// This interface is intended for homogenic collections that store elements implementing <see cref="IMyComparable"/>. 
    /// It provides methods to determine the number of elements, retrieve the minimum and maximum elements, add new elements, and check for the presence of a specific element.
    /// </remarks>
    public interface IMyCollection :IIterableCollection
    {
        /// <summary>
        /// Returns the number of elements in the collection.
        /// </summary>
        int Count();

        /// <summary>
        /// Finds and returns the smallest element within the collection based on its comparison logic.
        /// </summary>
        /// <returns>The <see cref="IMyComparable"/> object with the lowest value.</returns>
        IMyComparable Minimum();

        /// <summary>
        /// Finds and returns the largest element within the collection based on its comparison logic.
        /// </summary>
        /// <returns>The <see cref="IMyComparable"/> object with the highest value.</returns>
        IMyComparable Maximum();

        /// <summary>
        /// Adds the specified <see cref="IMyComparable"/> instance to the collection.
        /// </summary>
        /// <param name="comparable">The object to add. Must implement <see cref="IMyComparable"/>.</param>
        void Add(IMyComparable comparable);

        /// <summary>
        /// Determines whether the collection contains a specific element. 
        /// </summary>
        /// <param name= "comparable"> the <see cref="IMyComparable"/> object to locate in the collection.</param>
        /// <returns>true if object is found; otherwise false.</returns>
        bool Contains(IMyComparable comparable);
    }
}
