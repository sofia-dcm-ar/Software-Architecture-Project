using System;
using Week1.ChainOfResponsability_Pattern;

//Week 7 Exercise: Implemment the chain of responsability pattern for creation

namespace Week7.ChainOfResponsability_Pattern
{
    /// <summary>
    /// Represents the base class for managing the chain of data provider handlers.
    /// </summary>
    /// <remarks>
    /// This class serves as the base handler in the Chain of Responsibility Pattern, 
    /// coordinating <see cref="DataKeyboardReader"/>, <see cref="FileDataReader"/>, and <see cref="RandomDataGenerator"/>.
    /// </remarks>
    public abstract class BaseHandler
    {
        protected BaseHandler _nextHandler;
        public BaseHandler(BaseHandler handler)
        {
            _nextHandler = handler;
        }

        // ---------------------------------------------------------
        // DataKeyboardReader methods
        // ---------------------------------------------------------
        public virtual int KeyboardNumber()
        {
            if (_nextHandler!=null)
            {
                return _nextHandler.KeyboardNumber();
            }
            return 0;
        }

        public virtual string KeyboardString()
        {
            if (_nextHandler!=null)
                return _nextHandler.KeyboardString();
            return "hello";
        }

        // ---------------------------------------------------------
        // RandomDataGenerator methods
        // ---------------------------------------------------------
        public virtual int RandomNumber(int max = 10)
        {
            if (_nextHandler!=null)
                return _nextHandler.RandomNumber(max);
            return 0;
        }

        public virtual string RandomString(int cant = 6)
        {
            if (_nextHandler!=null)
                return _nextHandler.RandomString(cant);
            return "hola";
        }

        // ---------------------------------------------------------
        // FileDataReader methods
        // ---------------------------------------------------------
        public virtual double NumberFromFile(double max = 10)
        {
            if (_nextHandler!=null)
                return _nextHandler.NumberFromFile(max);
            return 0;
        }

        public virtual string StringFromFile(int cant = 6)
        {
            if (_nextHandler!=null)
                return _nextHandler.StringFromFile(cant);
            return "hola";
        }
    }
}
