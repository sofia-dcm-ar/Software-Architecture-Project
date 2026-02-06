using System;
using System.Collections.Generic;
using Week2;
using Week2.Iterator_Pattern;

//Week 2 Exercise: Implement the iterator pattern in every collection type.

namespace Week1.MyCollections
{
    /// <summary>
    /// Represents a Stack-based implementation of <see cref="IMyCollection"/> that stores <see cref="IMyComparable"/> elements.
    /// </summary>
    /// <remarks>
    /// This collection follows a LIFO (Last-In-First-Out) structure and provides specialized comparison and search utilities.
    /// </remarks>
    public class MyStack : IMyCollection
    {
        private readonly List<IMyComparable> _stacked;

        public MyStack()
        {
            _stacked = new List<IMyComparable>();
        }

        // -----------------------------------------------------------
        // IMyCollection Implementation
        // -----------------------------------------------------------
        #region IMyCollection Implementation 
        
        public int Count()
        {
            return _stacked.Count;
        }

        public IMyComparable Minimum()
        {
            IMyComparable smaller = _stacked[0];
            for (int i = 1; i<_stacked.Count; i++)
            {
                if (_stacked[i].IsLessThan(smaller))
                    smaller=_stacked[i];
            }
            return smaller;
        }

        public IMyComparable Maximum()
        {
            IMyComparable larger = _stacked[0];
            for (int i = 1; i<_stacked.Count; i++)
            {
                if (_stacked[i].IsGreaterThan(larger))
                    larger=_stacked[i];
            }
            return larger;
        }

        public void Add(IMyComparable c)
        {
            Push(c);
        }

        public bool Contains(IMyComparable c)
        {
            foreach (IMyComparable actual in _stacked)
            {
                if (actual.IsEqual(c))
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
            return new MyStackIterator(this);
        }

        //-----------------------------------------------------------
        // Stack methods
        //-----------------------------------------------------------
        public void Push(IMyComparable comparable)
        {
            _stacked.Add(comparable);
        }

        public IMyComparable Pop()
        {
            IMyComparable stack = _stacked[_stacked.Count -1];
            _stacked.RemoveAt(_stacked.Count -1);
            return stack;
        }

        public IMyComparable GetElement(int i)
        { //Week 2: create this method to allow the iterator to access the specific elements
            return _stacked[i];
        }
    }
}
