using System;
using Week1;
using Week1.FactoryMethod_Pattern;
using Week4.FactoryMethod_Pattern;
using Week6.FactoryMethod_Pattern;

//Week 3 Exercise: Implement the abstract class Factory for Factory Method Pattern

namespace Week3.FactoryMethod_Pattern
{
    /// <summary>
    /// Represents the base structure for concrete factories that creates <see cref="IMyComparable"/> instances using different input methods.
    /// </summary>
    /// <remarks>
    /// <see cref="MyComparableFactory"/> defines a common interface for creating <see cref="IMyComparable"/> objects either with randomly generated data 
    /// or by reading input from the keyboard.
    /// </remarks>
    public abstract class MyComparableFactory
    {
        protected RandomDataGenerator _create = new RandomDataGenerator();
        protected DataKeyboardReader _read = new DataKeyboardReader();

        /// <summary>
        /// Creates an <see cref="IMyComparable"/> instance with random data using a specific concrete factory.
        /// </summary>
        /// <param name="option">Determines which concrete factory to use (1: Number, 2: Alumno, 3: Professor, 4: Diligent Alumno, 5: Decorated Alumno, 6: Decorated Diligent Alumno, 7: Proxy Alumno, 8: Composite Alumno).</param>
        /// <returns>A concrete <see cref="IMyComparable"/> object.</returns>
        public static IMyComparable RandomCreate(int option)
        {
            return CreateFactory(option).RandomCreate();
        }

        /// <summary>
        /// Creates an <see cref="IMyComparable"/> instance by reading keyboard input using a specific concrete factory.
        /// </summary>
        /// <param name="option">Determines which concrete factory to use (1: Number, 2: Alumno, 3: Professor, 4: Diligent Alumno, 5: Decorated Alumno, 6: Decorated Diligent Alumno, 7: Proxy Alumno, 8: Composite Alumno).</param>
        /// <returns>A concrete <see cref="IMyComparable"/> object.</returns>
        public static IMyComparable KeyboardCreate(int option)
        {
            return CreateFactory(option).KeyboardCreate();
        }

        /// <summary>
        /// Selects and instantiates the appropriate concrete factory based on the provided <paramref name="option"/>.
        /// </summary>
        /// <remarks>
        /// The <see cref="MyComparableFactory"/> created is a concrete factory that creates concrete <see cref="IMyComparable"/> instances.
        /// </remarks>
        /// <param name="option">The selection criteria for the factory type.</param>
        /// <returns>An instance of a concrete <see cref="MyComparableFactory"/>.</returns>
        private static MyComparableFactory CreateFactory(int option)
        {
            MyComparableFactory factory = null;
            switch (option)
            {
                case 1:
                    factory = new MyNumberFactory();
                    break;
                case 2:
                    factory = new AlumnoFactory();
                    break;
                case 3:
                    factory = new ProfesorFactory();
                    break;
                case 4:
                    factory = new DiligentAlumnoFactory();
                    break;
                case 5:
                    factory = new AlumnoBaseDecoratorFactory();
                    break;
                case 6:
                    factory = new DiligentAlumnoBaseDecoratorFactory();
                    break;
                case 7:
                    factory = new AlumnoProxyFactory();
                    break;
                case 8:
                    factory = new CompositeAlumnoFactory();
                    break;
                default:
                    throw new ArgumentException($"The option {option} is not a valid factory type");
            }
            return factory;
        }

        /// <summary>
        /// Creates a concrete <see cref="IMyComparable"/> object with random generation.
        /// </summary>
        /// <returns>A concrete <see cref="IMyComparable"/>.</returns>
        public abstract IMyComparable RandomCreate();

        /// <summary>
        /// Creates a concrete <see cref="IMyComparable"/> object by reading input from keyboard.
        /// </summary>
        /// <returns>A concrete <see cref="IMyComparable"/>.</returns>
        public abstract IMyComparable KeyboardCreate();
    }
}
