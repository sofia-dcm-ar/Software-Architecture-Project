using System;
using System.Collections.Generic;
using Week2;
using Week2.Iterator_Pattern;
using Week5.Command_Pattern;

namespace Week1.MyCollections
{
    /// <summary>
    /// Represents a Stack-based implementation of <see cref="IMyCollection"/> that stores <see cref="IMyComparable"/> elements
    /// and implements <see cref="IOrderable"/> to support command injection.
    /// </summary>
    /// <remarks>
    /// This collection follows a LIFO (Last-In-First-Out) structure and provides specialized comparison and search utilities.
    /// As an <c>invoker</c> in the Command Pattern, it triggers specific behaviors during the <see cref="Push"/> process based on its internal state.
    /// </remarks>
    public class MyStack : IMyCollection, IOrderable
    {
        private readonly List<IMyComparable> _stacked;
        IClassroomCommand1 _startCommand;
        IClassroomCommand1 _fullClassroomCommand;
        IClassroomCommand2 _alumnoArrivalCommand;
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

        // -----------------------------------------------------------
        // Command Pattern Implementation (IOrderable)
        // -----------------------------------------------------------
        public void SetStartCommand(IClassroomCommand1 command)
        {
            _startCommand=command;
        }
        public void SetAlumnoArrivalCommand(IClassroomCommand2 command)
        {
            _alumnoArrivalCommand=command;
        }
        public void SetFullClassroomCommand(IClassroomCommand1 command)
        {
            _fullClassroomCommand=command;
        }

        //-----------------------------------------------------------
        // Stack methods
        //-----------------------------------------------------------
        /// <summary>
        /// Adds an object to the end of the stack and triggers specific behaviors based on the current <see cref="MyStack"/> internal state.
        /// </summary>
        /// <param name="comparable">The <see cref="IMyComparable"/> instance to be pushed.</param>
        public void Push(IMyComparable comparable)
        {
            _stacked.Add(comparable);

            //Only if commands are active
            if (this.Count()==1 && _startCommand!=null)
                _startCommand.Execute();

            if (_alumnoArrivalCommand!=null)
                _alumnoArrivalCommand.Execute(comparable);

            if (this.Count()==40 && _fullClassroomCommand!=null)
                _fullClassroomCommand.Execute();
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
