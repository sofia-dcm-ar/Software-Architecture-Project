using System;
using Week7.ChainOfResponsability_Pattern;

//Week 7 Exercise: Make the handlers single instances following the singletone pattern

namespace Week1.ChainOfResponsability_Pattern
{
    /// <summary>
    /// Represents a data generator that reads strings and numbers from the keyboard.
    /// </summary>
    /// <remarks>
    /// This class facilitates user input for creating string and number instances during runtime. 
    /// <para>This class is a <c>concrete handler</c>, part of the chain of data provider handlers following the Chain of Responsability Pattern.</para>
    /// <para>This class is a <c>single instance</c> following the singletone pattern.</para>
    /// </remarks>
    public class DataKeyboardReader : BaseHandler
    {
        private static DataKeyboardReader _instance = null;
        public DataKeyboardReader(BaseHandler handler) : base(handler) { }

        //------------------------------------------------------
        // Singletone Pattern Implementation
        //------------------------------------------------------

        /// <summary>
        /// Gets the unique instance of the <see cref="DataKeyboardReader"/> class.
        /// </summary>
        /// <remarks>This method is the only acces to the instance.</remarks>
        /// <param name="handler">The <see cref="BaseHandler"/> instance to assign if it has not been created yet</param>
        /// <returns>The current singleton instance of the handler.</returns>
        public static DataKeyboardReader GetInstance(BaseHandler handler)
        {
            if (_instance==null)
                _instance = new DataKeyboardReader(handler);
            return _instance;
        }

        //-------------------------------------------------------
        // RandomDataGenerator methods
        //-------------------------------------------------------

        /// <summary>
        /// Creates an <see cref="int"/> from keyboard input.
        /// </summary>
        /// <returns>An <see cref="int"/> instance.</returns>
        public override int KeyboardNumber()
        {
            string stringNumber = Console.ReadLine();
            if (int.TryParse(stringNumber, out int intNumber))
                return intNumber;
            else
                Console.WriteLine("That wasn´t an integer");
            return 0;
        }

        /// <summary>
        /// Creates an <see cref="string"/> from keyboard input.
        /// </summary>
        /// <returns>A <see cref="string"/> instance.</returns>
        public override string KeyboardString()
        {
            return Console.ReadLine();
        }
    }
}
