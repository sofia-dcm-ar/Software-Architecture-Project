using System;
using Week1;
using Week1.MyCollections;
using Week2.MyCollections;

namespace Week2.Iterator_Pattern
{
    //Week 2 ITERATOR -> Concrete iterator : Queue iterator

    /// <summary>
    /// Implements the concrete iterator logic for <see cref="MyQueue"/> based on the Iterator Pattern.
    /// </summary>
    /// <remarks>
    /// Inherits the iterator contract from <see cref="IIterator"/>.
    /// </remarks>
    public class MyQueueIterator : IIterator
    {
        private MyQueue _queued;
        private int _index;
        public MyQueueIterator(MyQueue queued)
        {
            _queued=queued;
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
            return (_index>=_queued.Count());
        }

        public IMyComparable CurrentItem()
        {
            return (_queued.GetElement(_index));
        }
    }
}
