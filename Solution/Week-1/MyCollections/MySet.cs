using System;
using System.Collections.Generic;
using Week2.Iterator_Pattern;

//Week 2 Exercise: Implement Set class. It is a collection that stores elements without repetition.
//Week 2 Exercise: Implement the iterator pattern in every collection type.

namespace Week2.MyCollections
{
    /// <summary>
    /// Represents a Set-based implementation of <see cref="IMyCollection"/> that stores <see cref="IMyComparable"/> elements.
    /// </summary>
    /// <remarks>
    /// This collection provides specialized comparison and search utilities for store elements without repetition.
    /// </remarks>
    public class MySet : IMyCollection
    {
        private readonly List<IMyComparable> _set;

        public MySet()
        {
            _set = new List<IMyComparable>();
        }

        // -----------------------------------------------------------
        // IMyCollection Implementation
        // -----------------------------------------------------------
        public int Count()
        {
            return _set.Count;
        }

        public IMyComparable Minimum()
        {
            IMyComparable smaller = _set[0];
            for (int i = 1; i<_set.Count; i++)
            {
                if (_set[i].IsLessThan(smaller))
                    smaller=_set[i];
            }
            return smaller;
        }

        public IMyComparable Maximum()
        {
            IMyComparable larger = _set[0];
            for (int i = 1; i<_set.Count; i++)
            {
                if (_set[i].IsGreaterThan(larger))
                    larger=_set[i];
            }
            return larger;
        }

        public bool Contains(IMyComparable comparable)
        {
            foreach (IMyComparable actual in _set)
            {
                if (actual.IsEqual(comparable))
                    return true;
            }
            return false;
        }

        // -----------------------------------------------------------
        // IIterableCollection Implementation
        // -----------------------------------------------------------
        public IIterator CreateIterator()
        {
            return new MySetIterator(this);
        }

        //-----------------------------------------------------------
        // Set methods
        //-----------------------------------------------------------
        public void Add(IMyComparable c)
        {
            if (!Contains(c))
                _set.Add(c);
        }

        public IMyComparable GetElement(int i)
        { //create this method to allow the iterator to access the specific elements
            return _set[i];
        }
    }
}
