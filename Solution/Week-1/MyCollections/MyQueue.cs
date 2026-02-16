using System;
using System.Collections.Generic;
using Week2;
using Week2.Iterator_Pattern;
using Week5.Command_Pattern;

//Week 5 Exercice: Implement the necessary attributes for the Orderable interface
//The queue can be just a queue or have orders associated with it 

namespace Week1.MyCollections
{
    /// <summary>
    /// Represents a Queue-based implementation of <see cref="IMyCollection"/> that stores <see cref="IMyComparable"/> elements 
    /// and implements <see cref="IOrderable"/> to support command injection.
    /// </summary>
    /// <remarks>
    /// This collection follows a FIFO (First-In-First-Out) structure and provides specialized comparison and search utilities.
    /// As an <c>invoker</c> in the Command Pattern, it triggers specific behaviors during the <see cref="Enqueue"/> process based on its internal state.
    /// </remarks>
    public class MyQueue : IMyCollection, IOrderable
    {
        private readonly List<IMyComparable> _queued;
        IClassroomCommand1 _startCommand;
        IClassroomCommand1 _fullClassroomCommand;
        IClassroomCommand2 _alumnoArrivalCommand;

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
        // Queue methods
        //-----------------------------------------------------------
        /// <summary>
        /// Adds an object to the end of the queue and triggers specific behaviors based on the current <see cref="MyQueue"/> internal state.
        /// </summary>
        /// <param name="comparable">The <see cref="IMyComparable"/> instance to be enqueued.</param>
        public void Enqueue(IMyComparable comparable)
        {
            _queued.Add(comparable);

            //Only if commands are active
            if (this.Count()==1 && _startCommand!=null)
                _startCommand.Execute();

            if (_alumnoArrivalCommand!=null)
                _alumnoArrivalCommand.Execute(comparable);

            if (this.Count()==40 && _fullClassroomCommand!=null)
                _fullClassroomCommand.Execute();
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
