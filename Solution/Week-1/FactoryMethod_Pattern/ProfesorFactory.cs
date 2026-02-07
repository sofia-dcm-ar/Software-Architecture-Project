using System;
using Week1;

//Week 3 Exercise: Concrete Factory -> Professor Factory

namespace Week3.FactoryMethod_Pattern
{
    /// <summary>
    /// A concrete factory that implements the <see cref="MyComparableFactory"/> to create <see cref="Professor"/> instances. 
    /// </summary>
    /// <remarks>
    /// Encapsulates the logic for creating <see cref="Professor"/> instances either throug automated random generation or manual keyboard input.
    /// </remarks>
    public class ProfesorFactory : MyComparableFactory
    {
        /// <summary>
        /// Creates a new <see cref="Professor"/> with automated randomly generated attributes.
        /// </summary>
        /// <returns>A concrete <see cref="Professor"/> as an <see cref="IMyComparable"/>.</returns>
        public override IMyComparable RandomCreate()
        {
            return new Professor(base._create.RandomNumber(), base._create.RandomString(), base._create.RandomNumber(50000000));
        }

        /// <summary>
        /// Creates a new <see cref="Professor"/> with manual keyboard input attributes.
        /// </summary>
        /// <returns>A concrete <see cref="Professor"/> as an <see cref="IMyComparable"/>.</returns>
        public override IMyComparable KeyboardCreate()
        {
            Console.Write("Ingrese el nombre: ");
            string name = base._read.KeyboardString();
            Console.Write("\nIngrese el DNI: ");
            int id = base._read.KeyboardNumber();
            Console.Write("\nIngrese la antiguedad: ");
            int tenure = base._read.KeyboardNumber();
            return new Professor(tenure, name, id);
        }
    }
}
