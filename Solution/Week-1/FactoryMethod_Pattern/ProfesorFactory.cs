using System;
using Week1.People;
using Week1;

//Week 3 Exercise: Concrete Factory -> Professor Factory

namespace Week3.FactoryMethod_Pattern
{
    /// <summary>
    /// A concrete factory that implements the <see cref="MyComparableFactory"/> to create <see cref="Professor"/> instances. 
    /// </summary>
    /// <remarks>
    /// Encapsulates the logic for creating <see cref="Professor"/> instances either throug automated random generation, automated read data from text file or manual keyboard input.
    /// </remarks>
    public class ProfesorFactory : MyComparableFactory
    {
        public ProfesorFactory()
        {
            this.CreateChainOfHandlers();
        }

        /// <summary>
        /// Creates a new <see cref="Professor"/> with automated randomly generated attributes.
        /// </summary>
        /// <returns>A concrete <see cref="Professor"/> as an <see cref="IMyComparable"/>.</returns>
        public override IMyComparable RandomCreate()
        {
            return new Professor(base._chainOfHandlers.RandomNumber(), base._chainOfHandlers.RandomString(), base._chainOfHandlers.RandomNumber(50000000));
        }

        /// <summary>
        /// Creates a new <see cref="Professor"/> with manual keyboard input attributes.
        /// </summary>
        /// <returns>A concrete <see cref="Professor"/> as an <see cref="IMyComparable"/>.</returns>
        public override IMyComparable KeyboardCreate()
        {
            Console.Write("Ingrese el _name: ");
            string name = base._chainOfHandlers.KeyboardString();
            Console.Write("\nIngrese el DNI: ");
            int id = base._chainOfHandlers.KeyboardNumber();
            Console.Write("\nIngrese la antiguedad: ");
            int tenure = base._chainOfHandlers.KeyboardNumber();
            return new Professor(tenure, name, id);
        }

        /// <summary>
        /// Creates a new <see cref="Professor"/> with automated read data from text file attributes.
        /// </summary>
        /// <returns>A concrete <see cref="Professor"/> as an <see cref="IMyComparable"/>.</returns>
        public override IMyComparable FileCreate()
        {
            return new Professor((int)_chainOfHandlers.NumberFromFile(), _chainOfHandlers.StringFromFile(), (int)_chainOfHandlers.NumberFromFile(50000000));
        }
    }
}
