using System;
using Week1;
using Week1.People;
using Week3.FactoryMethod_Pattern;
using Week4.Decorator_Pattern;

namespace Week4.FactoryMethod_Pattern
{
    /// <summary>
    /// A concrete factory that implements the <see cref="MyComparableFactory"/> to create <see cref="AlumnoBaseDecorator"/> instances. 
    /// </summary>
    /// <remarks>
    /// Encapsulates the logic for creating <see cref="AlumnoBaseDecorator"/> instances either throug automated random generation, automated read data from text file or manual keyboard input.
    /// </remarks>
    public class AlumnoBaseDecoratorFactory : MyComparableFactory
    {
        public AlumnoBaseDecoratorFactory()
        {
            this.CreateChainOfHandlers();
        }

        /// <summary>
        /// Creates a new <see cref="AlumnoBaseDecorator"/> with automated randomly generated attributes.
        /// </summary>
        /// <returns>A concrete <see cref="AlumnoBaseDecorator"/> as an <see cref="IMyComparable"/>.</returns>
        public override IMyComparable RandomCreate()
        {
            return this.Decorate(MyComparableFactory.RandomCreate(2));
        }

        /// <summary>
        /// Creates a new <see cref="AlumnoBaseDecorator"/> with manual keyboard input attributes.
        /// </summary>
        /// <returns>A concrete <see cref="AlumnoBaseDecorator"/> as an <see cref="IMyComparable"/>.</returns>
        public override IMyComparable KeyboardCreate()
        {
            return this.Decorate(MyComparableFactory.KeyboardCreate(2));
        }

        /// <summary>
        /// Creates a new <see cref="AlumnoBaseDecorator"/> with automated read data from text file attributes.
        /// </summary>
        /// <returns>A concrete <see cref="AlumnoBaseDecorator"/> as an <see cref="IMyComparable"/>.</returns>
        public override IMyComparable FileCreate()
        {
            return this.Decorate(MyComparableFactory.FileCreate(2));
        }

        /// <summary>
        /// Decorates the <see cref="AlumnoBaseDecorator"/> wrapping it in diferent concrete decorators.
        /// </summary>
        /// <param name="comparable">The <see cref="AlumnoBaseDecorator"/> object to be decorated.</param>
        /// <returns>An <see cref="AlumnoBaseDecorator"/> instance as an <see cref="IMyComparable"/>.</returns>
        private IMyComparable Decorate(IMyComparable comparable)
        {
            FileNumberDecorator decoration0 = new FileNumberDecorator((Alumno)comparable);
            var decoration1 = new LetterDecorator(decoration0);
            var decoration2 = new StatusDecorator(decoration1);
            var decoration3 = new ContainerDecorator(decoration2);
            return decoration3;
        }
    }
}
