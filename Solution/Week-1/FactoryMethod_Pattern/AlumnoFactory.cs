using System;
using Week1.People;
using Week1;

//Week 3 Exercise: Concrete Factory -> Alumno Factory

namespace Week3.FactoryMethod_Pattern
{
    /// <summary>
    /// A concrete factory that implements the <see cref="MyComparableFactory"/> to create <see cref="Alumno"/> instances. 
    /// </summary>
    /// <remarks>
    /// Encapsulates the logic for creating <see cref="Alumno"/> instances either throug automated random generation, automated read data from text file or manual keyboard input.
    /// </remarks>
    public class AlumnoFactory : MyComparableFactory
    {
        public AlumnoFactory()
        {
            this.CreateChainOfHandlers();
        }

        /// <summary>
        /// Creates a new <see cref="Alumno"/> with automated randomly generated attributes.
        /// </summary>
        /// <returns>A concrete <see cref="Alumno"/> as an <see cref="IMyComparable"/>.</returns>
        public override IMyComparable RandomCreate()
        {
            return new Alumno(base._chainOfHandlers.RandomString(), base._chainOfHandlers.RandomNumber(50000000), base._chainOfHandlers.RandomNumber(2000), (double)base._chainOfHandlers.RandomNumber(10));
        }

        /// <summary>
        /// Creates a new <see cref="Alumno"/> with manual keyboard input attributes.
        /// </summary>
        /// <returns>A concrete <see cref="Alumno"/> as an <see cref="IMyComparable"/>.</returns>
        public override IMyComparable KeyboardCreate()
        {
            Console.Write("Introduce the Name: ");
            string name = base._chainOfHandlers.KeyboardString();
            Console.Write("\nIntroduce the ID: ");
            int id = base._chainOfHandlers.KeyboardNumber();
            Console.Write("\nIntroduce the File Number: ");
            int fileNumber = base._chainOfHandlers.KeyboardNumber();
            Console.Write("\nIntroduce the Average: ");
            double average = double.Parse(Console.ReadLine());
            return new Alumno(name, id, fileNumber, average);
        }

        /// <summary>
        /// Creates a new <see cref="Alumno"/> with automated read data from text file attributes.
        /// </summary>
        /// <returns>A concrete <see cref="Alumno"/> as an <see cref="IMyComparable"/>.</returns>
        public override IMyComparable FileCreate()
        {
            return new Alumno(_chainOfHandlers.StringFromFile(), (int)_chainOfHandlers.NumberFromFile(50000000), (int)_chainOfHandlers.NumberFromFile(2000), _chainOfHandlers.NumberFromFile(10));
        }
    }
}
