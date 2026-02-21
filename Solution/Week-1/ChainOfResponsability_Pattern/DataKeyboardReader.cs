using System;
using Week7.ChainOfResponsability_Pattern:

//Week 3 Exercise: Implement a class capable of reading data from keyboard

namespace Week1.ChainOfResponsability_Pattern
{
    /// <summary>
    /// Represents a data generator that reads strings and numbers from the keyboard.
    /// </summary>
    /// <remarks>
    /// This class facilitates user input for creating string and number instances during runtime. 
    /// This class is a concrete handler, part of the chain of data provider handlers following the Chain of Responsability Pattern.
    /// </remarks>
    public class DataKeyboardReader : BaseHandler
    {
        public DataKeyboardReader(BaseHandler handler) : base(handler) { }

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
