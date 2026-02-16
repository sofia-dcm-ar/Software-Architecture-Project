using System;
using Week3.FactoryMethod_Pattern;
using Week4.People;
using Week5.People;

//Week 5 Exercise: Concrete Factory -> Alumno Proxy Factory

namespace Week1.FactoryMethod_Pattern
{
    /// <summary>
    /// A concrete factory that implements the <see cref="MyComparableFactory"/> to create <see cref="AlumnoProxy"/> instances. 
    /// </summary>
    /// <remarks>
    /// Encapsulates the logic for creating <see cref="AlumnoProxy"/> instances either throug automated random generation or manual keyboard input.
    /// </remarks>
    public class AlumnoProxyFactory : MyComparableFactory
    {
        /// <summary>
        /// Creates a new <see cref="AlumnoProxy"/> with automated randomly generated attributes and the <see cref="IAlumno"/> option for the real object.
        /// </summary>
        /// <returns>A concrete <see cref="AlumnoProxy"/> as an <see cref="IMyComparable"/>.</returns>
        public override IMyComparable RandomCreate()
        {
            Console.Write("\nDifferent Alumno types:\n2 -> Alumno\n4 -> Diligent Alumno\n5 -> Alumno Decorated\n6 -> Diligent Alumno Decorated\nIntroduce the Alumno type: ");
            int option = base._read.KeyboardNumber();
            return new AlumnoProxy(base._create.RandomString(), option);
        }

        /// <summary>
        /// Creates a new <see cref="AlumnoProxy"/> with manual keyboard input attributes and the <see cref="IAlumno"/> option for the real object.
        /// </summary>
        /// <returns>A concrete <see cref="AlumnoProxy"/> as an <see cref="IMyComparable"/>.</returns>
        public override IMyComparable KeyboardCreate()
        {
            Console.Write("\nDifferent Alumno types:\n2 -> Alumno\n4 -> Diligent Alumno\n5 -> Alumno Decorated\n6 -> Diligent Alumno Decorated\nIntroduce the Alumno type: ");
            int option = base._read.KeyboardNumber();
            return new AlumnoProxy(base._read.KeyboardString(), option);
        }
    }
}
