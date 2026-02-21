using System;
using System.Text;
using Week7.ChainOfResponsability_Pattern;

//Week 7 Exercise: Made the class a concrete handler

namespace Week1.ChainOfResponsability_Pattern
{
    /// <summary>
    /// Represents a data generator that creates random strings and numbers.
    /// </summary>
    /// <remarks>
    /// This class is a concrete handler, part of the chain of data provider handlers following the Chain of Responsability Pattern.
    /// </remarks>
    public class RandomDataGenerator : BaseHandler
    {
        private readonly Random _r;
        public RandomDataGenerator(BaseHandler handler) : base(handler) 
        {
            _r = new Random();
        }

        /// <summary>
        /// Creates a random <see cref="int"/> between 1 and <paramref name="max"/>.
        /// </summary>
        /// <param name="max">The maximum number to select.</param>
        /// <returns>A random <see cref="int"/> instance.</returns>
        public override int RandomNumber(int max = 13)
        {
            return _r.Next(1, max);
        }

        /// <summary>
        /// Creates a random <see cref="string"/> with a length of <paramref name="cant"/>.
        /// </summary>
        /// <param name="cant">The string length.</param>
        /// <remarks>
        /// The <see cref="string"/> created doesnt form a word, it is a string of letters from the alphabet mixed together.
        /// </remarks>
        /// <returns>A random <see cref="string"/> instance.</returns>
        public override string RandomString(int cant = 6)
        { 
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            StringBuilder token = new StringBuilder();
            token.Append(char.ToUpper(alphabet[_r.Next(alphabet.Length)]));//First letter uppercase
            for (int i = 1; i < cant; i++)
            {
                token.Append(alphabet[_r.Next(alphabet.Length)]);
            }
            return token.ToString();
        }
    }
}
