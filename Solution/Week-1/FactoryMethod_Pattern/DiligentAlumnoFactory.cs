using System;
using Week1;
using Week3.FactoryMethod_Pattern;
using Week4.People;

namespace Week4.FactoryMethod_Pattern
{
    /// <summary>
    /// A concrete factory that implements the <see cref="MyComparableFactory"/> to create <see cref="DiligentAlumno"/> instances. 
    /// </summary>
    /// <remarks>
    /// Encapsulates the logic for creating <see cref="DiligentAlumno"/> instances either throug automated random generation, automated read data from text file or manual keyboard input.
    /// </remarks>
    public class DiligentAlumnoFactory : MyComparableFactory
    {
        public DiligentAlumnoFactory()
        {
            this.CreateChainOfHandlers();
        }

        /// <summary>
        /// Creates a new <see cref="DiligentAlumno"/> with automated randomly generated attributes.
        /// </summary>
        /// <returns>A concrete <see cref="DiligentAlumno"/> as an <see cref="IMyComparable"/>.</returns>
        public override IMyComparable RandomCreate()
        {
            return new DiligentAlumno(base._chainOfHandlers.RandomString(), base._chainOfHandlers.RandomNumber(50000000), base._chainOfHandlers.RandomNumber(2000), (double)base._chainOfHandlers.RandomNumber(10));
        }

        /// <summary>
        /// Creates a new <see cref="DiligentAlumno"/> with manual keyboard input attributes.
        /// </summary>
        /// <returns>A concrete <see cref="DiligentAlumno"/> as an <see cref="IMyComparable"/>.</returns>
        public override IMyComparable KeyboardCreate()
        {
            Console.Write("Introduce the name: ");
            string name = base._chainOfHandlers.KeyboardString();
            Console.Write("\nIntroduce the ID: ");
            int id = base._chainOfHandlers.KeyboardNumber();
            Console.Write("\nIntroduce the File Number: ");
            int fileNumber = base._chainOfHandlers.KeyboardNumber();
            Console.Write("\nIntroduce the Average: ");
            double average = double.Parse(Console.ReadLine());
            return new DiligentAlumno(name, id, fileNumber, average);
        }

        /// <summary>
        /// Creates a new <see cref="DiligentAlumno"/> with automated read data from text file attributes.
        /// </summary>
        /// <returns>A concrete <see cref="DiligentAlumno"/> as an <see cref="IMyComparable"/>.</returns>
        public override IMyComparable FileCreate()
        {
            return new DiligentAlumno(_chainOfHandlers.StringFromFile(), (int)_chainOfHandlers.NumberFromFile(50000000), (int)_chainOfHandlers.NumberFromFile(2000), _chainOfHandlers.NumberFromFile(10));
        }
    }
}
