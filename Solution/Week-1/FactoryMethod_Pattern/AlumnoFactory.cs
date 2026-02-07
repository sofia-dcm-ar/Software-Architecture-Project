using System;
using Week1;

//Week 3 Exercise: Concrete Factory -> Alumno Factory

namespace Week3.FactoryMethod_Pattern
{
    /// <summary>
    /// A concrete factory that implements the <see cref="MyComparableFactory"/> to create <see cref="Alumno"/> instances. 
    /// </summary>
    /// <remarks>
    /// Encapsulates the logic for creating <see cref="Alumno"/> instances either throug automated random generation or manual keyboard input.
    /// </remarks>
    public class AlumnoFactory : MyComparableFactory
    {
        /// <summary>
        /// Creates a new <see cref="Alumno"/> with automated randomly generated attributes.
        /// </summary>
        /// <returns>A concrete <see cref="Alumno"/> as an <see cref="IMyComparable"/>.</returns>
        public override IMyComparable RandomCreate()
        {
            return new Alumno(base._create.RandomString(), base._create.RandomNumber(50000000), base._create.RandomNumber(2000), (double)base._create.RandomNumber(10));
        }

        /// <summary>
        /// Creates a new <see cref="Alumno"/> with manual keyboard input attributes.
        /// </summary>
        /// <returns>A concrete <see cref="Alumno"/> as an <see cref="IMyComparable"/>.</returns>
        public override IMyComparable KeyboardCreate()
        {
            Console.Write("Introduce the Name: ");
            string name = base._read.KeyboardString();
            Console.Write("\nIntroduce the ID: ");
            int id = base._read.KeyboardNumber();
            Console.Write("\nIntroduce the File Number: ");
            int fileNumber = base._read.KeyboardNumber();
            Console.Write("\nIntroduce the Average: ");
            double average = double.Parse(Console.ReadLine());
            return new Alumno(name, id, fileNumber, average);
        }
    }
}
