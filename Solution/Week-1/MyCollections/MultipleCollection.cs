using System;
using Week2;
using Week2.Iterator_Pattern;

namespace Week1.MyCollections
{
    /// <summary>
    /// A composite collection that encapsulates both a <see cref="MyStack"/> and a <see cref="MyQueue"/>, 
    /// treating them as a single logical unit.
    /// </summary>
    /// <remarks>
    /// All the operations are performed across both internal structures to provide a unified result.
    /// </remarks>
    public class MultipleCollection : IMyCollection
    {
        private readonly MyStack _stacked;
        private readonly MyQueue _queued;

        public MultipleCollection(MyStack stack, MyQueue queue)
        {
            _stacked=new MyStack();
            _stacked=stack;
            _queued=new MyQueue();
            _queued=queue;
        }

        // -----------------------------------------------------------
        // IMyCollection Implementation
        // -----------------------------------------------------------
        #region IMyCollection Implementation
        /// <summary>
        /// Returns the number of elements in total in both collections.
        /// </summary>
        public int Count()
        { 
            return _stacked.Count()+_queued.Count();
        }

        /// <summary>
        /// Finds and returns the smallest element by comparing the minimum values of both internal collections based on its comparison logic.
        /// </summary>
        /// <returns>The <see cref="IMyComparable"/> object with the lowest value found in either collections.</returns>
        public IMyComparable Minimum()
        { 
            //returns the element of lesser value between both collections
            IMyComparable toCompare1 = _stacked.Minimum();
            IMyComparable toCompare2 = _queued.Minimum();
            if (toCompare1.IsLessThan(toCompare2))
                return toCompare1;
            return toCompare2;
        }

        /// <summary>
        /// Finds and returns the largest element by comparing the maximum values of both internal collections based on its comparison logic.
        /// </summary>
        /// <returns>The <see cref="IMyComparable"/> object with the largest value found in either collections.</returns>
        public IMyComparable Maximum()
        {
            //returns the element of greater value between both collections
            IMyComparable toCompare1 = _stacked.Maximum();
            IMyComparable toCompare2 = _queued.Maximum();
            if (toCompare1.IsGreaterThan(toCompare2))
                return toCompare1;
            return toCompare2;
        }

        /// <summary>
        /// In this collection there is not addition
        /// </summary>
        /// <remarks>Is For fulfill the <see cref="IMyCollection"/> requitements</remarks>
        public void Add(IMyComparable comparable) { }

        /// <summary>
        /// Determines whether the collections contains a specific element. 
        /// </summary>
        /// <param name= "comparable"> the <see cref="IMyComparable"/> object to locate in the collections.</param>
        /// <returns><see langword="true"/> if object is found; otherwise <see langword="false"/>.</returns>
        public bool Contains(IMyComparable comparable)
        {
            return _stacked.Contains(comparable)||_queued.Contains(comparable);

        }
        #endregion

        // -----------------------------------------------------------
        // Iterator Pattern Implementation (IIterableCollection)
        // -----------------------------------------------------------
        public IIterator CreateIterator() //just for the interface requirement
        {
            return null;
        }
    }
}
