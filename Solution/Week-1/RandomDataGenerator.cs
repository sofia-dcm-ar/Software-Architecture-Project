using System;
using System.Text;

//Week 3 Exercise: Implement a class for generating random data
namespace Week3
{
    /// <summary>
    /// Represents a data generator that creates random strings and numbers.
    /// </summary>
    public class RandomDataGenerator
    {
        private readonly Random _r;
        public RandomDataGenerator()
        {
            _r = new Random();
        }

        /// <summary>
        /// Creates a random <see cref="int"/> between 0 and <paramref name="max"/>.
        /// </summary>
        /// <param name="max">The maximum number to select.</param>
        /// <returns>A random <see cref="int"/> instance.</returns>
        public int RandomNumber(int max = 10)
        {
            return this._r.Next(max);
        }

        /// <summary>
        /// Creates a random <see cref="string"/> with a length of <paramref name="cant"/>.
        /// </summary>
        /// <param name="cant">The string length.</param>
        /// <remarks>
        /// The <see cref="string"/> created doesnt form a word, it is a string of letters from the alphabet mixed together.
        /// </remarks>
        /// <returns>A random <see cref="string"/> instance.</returns>
        public string RandomString(int cant = 6)
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
