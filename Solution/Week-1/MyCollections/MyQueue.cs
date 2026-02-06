using System;
using System.Collections.Generic;
using Week2;
using Week2.Iterator_Pattern;

//Week 2 Exercise: Implement the iterator pattern in every collection type.

namespace Week1.MyCollections
{
    /// <summary>
    /// Represents a Queue-based implementation of <see cref="IMyCollection"/> that stores <see cref="IMyComparable"/> elements.
    /// </summary>
    /// <remarks>
    /// This collection follows a FIFO (First-In-First-Out) structure and provides specialized comparison and search utilities.
    /// </remarks>
    public class MyQueue : IMyCollection
    {
        private readonly List<IMyComparable> _queued;

        public MyQueue()
        {
            _queued= new List<IMyComparable>();
        }

        // -----------------------------------------------------------
        // IMyCollection Implementation
        // -----------------------------------------------------------
        #region IMyCollection Implementation
        
        public int Count()
        {
            return _queued.Count;
        }

        public IMyComparable Minimum()
        {
            IMyComparable smaller = _queued[0];
            for (int i = 1; i<_queued.Count; i++)
            {
                if (_queued[i].IsLessThan(smaller))
                    smaller=_queued[i];
            }
            return smaller;
        }

        public IMyComparable Maximum()
        {
            IMyComparable larger = _queued[0];
            for (int i = 1; i<_queued.Count; i++)
            {
                if (_queued[i].IsGreaterThan(larger))
                    larger=_queued[i];
            }
            return larger;
        }

        public void Add(IMyComparable comparable)
        {
            Enqueue(comparable);
        }

        public bool Contains(IMyComparable comparable)
        {
            foreach (IMyComparable actual in _queued)
            {
                if (actual.IsEqual(comparable)) 
                    return true;
            }
            return false;
        }
        #endregion

        // -----------------------------------------------------------
        // Iterator Pattern Implementation (IIterableCollection)
        // -----------------------------------------------------------
        public IIterator CreateIterator()
        {
            return new MyQueueIterator(this);
        }

        //-----------------------------------------------------------
        // Queue methods
        //-----------------------------------------------------------
        public void Enqueue(IMyComparable comparable)
        {
            _queued.Add(comparable);
        }

        public IMyComparable Dequeue()
        {
            IMyComparable element = _queued[0];
            _queued.RemoveAt(0);
            return element;
        }

        public IMyComparable GetElement(int i)
        { //Week 2: create this method to allow the iterator to access the specific elements
            return _queued[i];
        }
    }
}
