using System;

//Week 3 Exercise: Implement a class capable of reading data from keyboard

namespace Week3
{
    /// <summary>
    /// Represents a data generator that reads strings and numbers from the keyboard.
    /// </summary>
    /// <remarks>
    /// This class facilitates user input for creating string and number instances during runtime.
    /// </remarks>
    public class DataKeyboardReader
    {
        public DataKeyboardReader() { }

        /// <summary>
        /// Creates an <see cref="int"/> from keyboard input.
        /// </summary>
        /// <returns>An <see cref="int"/> instance.</returns>
        public int KeyboardNumber()
        {
            return (int.Parse(Console.ReadLine()));
        }

        /// <summary>
        /// Creates an <see cref="string"/> from keyboard input.
        /// </summary>
        /// <returns>A <see cref="string"/> instance.</returns>
        public string KeyboardString()
        {
            return (Console.ReadLine());
        }
    }
}
