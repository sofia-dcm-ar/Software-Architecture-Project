using System;
using Week1;
using Week1.MyCollections;
using Week2.MyCollections;

namespace Week2.Iterator_Pattern
{
    /// <summary>
    /// Implements the concrete iterator logic for <see cref="MySet"/> based on the Iterator Pattern.
    /// </summary>
    /// <remarks>
    /// Inherits the iterator contract from <see cref="IIterator"/>.
    /// </remarks>
    public class MySetIterator : IIterator
    {
        private MySet _set;
        private int _index;
        public MySetIterator(MySet c)
        {
            _set=c;
            this.First();
        }

        public void First()
        {
            _index=0;
        }

        public void Next()
        {
            _index++;
        }

        public bool IsDone()
        {
            return (_index>=_set.Count());
        }

        public IMyComparable CurrentItem()
        {
            return (_set.GetElement(_index));
        }
    }
}
