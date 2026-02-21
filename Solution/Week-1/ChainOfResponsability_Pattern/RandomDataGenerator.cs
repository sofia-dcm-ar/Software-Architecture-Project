using System;
using System.Text;
using Week7.ChainOfResponsability_Pattern;

//Week 7 Exercise: Made the class a concrete handle and only instance

namespace Week1.ChainOfResponsability_Pattern
{
    /// <summary>
    /// Represents a data generator that creates random strings and numbers.
    /// </summary>
    /// <remarks>
    /// <para>This class is a <c>concrete handler</c>, part of the chain of data provider handlers following the Chain of Responsability Pattern.</para>
    /// <para>This class is a <c>single instance</c> following the singletone pattern.</para>
    /// </remarks>
    public class RandomDataGenerator : BaseHandler
    {
        private readonly Random _r;
        private static RandomDataGenerator _instance = null;

        public RandomDataGenerator(BaseHandler handler) : base(handler) 
        {
            _r = new Random();
        }

        //------------------------------------------------------
        // Singletone Pattern Implementation
        //------------------------------------------------------

        /// <summary>
        /// Gets the unique instance of the <see cref="RandomDataGenerator"/> class.
        /// </summary>
        /// <remarks>This method is the only acces to the instance.</remarks>
        /// <param name="handler">The <see cref="BaseHandler"/> instance to assign if it has not been created yet</param>
        /// <returns>The current singleton instance of the handler.</returns>
        public static RandomDataGenerator GetInstance(BaseHandler handler)
        {
            if (_instance==null)
                _instance = new RandomDataGenerator(handler);
            return _instance;
        }

        //-------------------------------------------------------
        // RandomDataGenerator methods
        //-------------------------------------------------------

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
