using System;
using Week2.MyCollections;

namespace Week2.Iterator_Pattern
{
    //Week 2 ITERATOR -> Concrete iterator : Stack iterator

    /// <summary>
    /// Implements the concrete iterator logic for <see cref="MyStack"/> based on the Iterator Pattern.
    /// </summary>
    /// <remarks>
    /// Inherits the iterator contract from <see cref="IIterator"/>.
    /// </remarks>
    public class MyStackIterator : IIterator
    {
        private readonly MyStack _stacked;
        private int _index;

        public MyStackIterator(MyStack stacked)
        {
            _stacked=stacked;
            this.First();
        }

        public void First()
        {
            _index=_stacked.Count()-1;
        }

        public void Next()
        {
            _index--;
        }

        public bool IsDone()
        {
            return (_index<0);
        }

        public IMyComparable CurrentItem()
        {
            return (_stacked.GetElement(_index));
        }

    }
}
