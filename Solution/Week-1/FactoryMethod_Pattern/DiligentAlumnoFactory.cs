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
    /// Encapsulates the logic for creating <see cref="DiligentAlumno"/> instances either throug automated random generation or manual keyboard input.
    /// </remarks>
    public class DiligentAlumnoFactory : MyComparableFactory
    {
        /// <summary>
        /// Creates a new <see cref="DiligentAlumno"/> with automated randomly generated attributes.
        /// </summary>
        /// <returns>A concrete <see cref="DiligentAlumno"/> as an <see cref="IMyComparable"/>.</returns>
        public override IMyComparable RandomCreate()
        {
            return new DiligentAlumno(base._create.RandomString(), base._create.RandomNumber(50000000), base._create.RandomNumber(2000), (double)base._create.RandomNumber(10));
        }

        /// <summary>
        /// Creates a new <see cref="DiligentAlumno"/> with manual keyboard input attributes.
        /// </summary>
        /// <returns>A concrete <see cref="DiligentAlumno"/> as an <see cref="IMyComparable"/>.</returns>
        public override IMyComparable KeyboardCreate()
        {
            Console.Write("Introduce the name: ");
            string name = base._read.KeyboardString();
            Console.Write("\nIntroduce the ID: ");
            int id = base._read.KeyboardNumber();
            Console.Write("\nIntroduce the File Number: ");
            int fileNumber = base._read.KeyboardNumber();
            Console.Write("\nIntroduce the Average: ");
            double average = double.Parse(Console.ReadLine());
            return new DiligentAlumno(name, id, fileNumber, average);
        }
    }
}
