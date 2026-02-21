using System;
using Week1;
using Week3.FactoryMethod_Pattern;
using Week4.People;
using Week5.People;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

//Week 5 Exercise: Concrete Factory -> Alumno Proxy Factory

namespace Week1.FactoryMethod_Pattern
{
    /// <summary>
    /// A concrete factory that implements the <see cref="MyComparableFactory"/> to create <see cref="AlumnoProxy"/> instances. 
    /// </summary>
    /// <remarks>
    /// Encapsulates the logic for creating <see cref="AlumnoProxy"/> instances either throug automated random generation, automated read data from text file or manual keyboard input.
    /// </remarks>
    public class AlumnoProxyFactory : MyComparableFactory
    {
        public AlumnoProxyFactory() 
        {
            this.CreateChainOfHandlers();
        }

        /// <summary>
        /// Creates a new <see cref="AlumnoProxy"/> with automated randomly generated attributes and the <see cref="IAlumno"/> option for the real object.
        /// </summary>
        /// <returns>A concrete <see cref="AlumnoProxy"/> as an <see cref="IMyComparable"/>.</returns>
        public override IMyComparable RandomCreate()
        {
            int option = this.ComproveOption();
            return new AlumnoProxy(base._chainOfHandlers.RandomString(), option);
        }

        /// <summary>
        /// Creates a new <see cref="AlumnoProxy"/> with manual keyboard input attributes and the <see cref="IAlumno"/> option for the real object.
        /// </summary>
        /// <returns>A concrete <see cref="AlumnoProxy"/> as an <see cref="IMyComparable"/>.</returns>
        public override IMyComparable KeyboardCreate()
        {
            int option = this.ComproveOption();
            return new AlumnoProxy(base._chainOfHandlers.KeyboardString(), option);
        }

        /// <summary>
        /// Creates a new <see cref="AlumnoProxy"/> with automated read data from text file attributes and the <see cref="IAlumno"/> option for the real object.
        /// </summary>
        /// <returns>A concrete <see cref="AlumnoProxy"/> as an <see cref="IMyComparable"/>.</returns>
        public override IMyComparable FileCreate()
        {
            int option = this.ComproveOption();
            return new AlumnoProxy(base._chainOfHandlers.StringFromFile(), option);
        }

        /// <summary>
        /// Comproves the concrete factory option to ensure the type selected is an <see cref="IAlumno"/>.
        /// </summary>
        /// <returns>An <see cref="int"/> that is the concrete factory option.</returns>
        private int ComproveOption() 
        {
            bool correct = false;
            int option = 2;
            while (!correct)
            {
                Console.Write("\nDifferent Alumno types for the Proxy:\n2 -> Alumno\n4 -> Diligent Alumno\n5 -> Alumno Decorated\n6 -> Diligent Alumno Decorated\nIntroduce the Alumno type: ");
                option = base._chainOfHandlers.KeyboardNumber();
                if (option == 2 || option == 4 || option == 5 || option == 6)
                {
                    correct = true;
                    break;
                }
                Console.WriteLine("\nIncorrect Alumno Option");
            }
            return option;
        }
    }
}
