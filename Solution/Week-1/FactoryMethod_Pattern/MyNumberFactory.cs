using System;
using Week1;

//Week 3 Exercise: Concrete Factory -> MyNumber Factory

namespace Week3.FactoryMethod_Pattern
{
    /// <summary>
    /// A concrete factory that implements the <see cref="MyComparableFactory"/> to create <see cref="MyNumber"/> instances. 
    /// </summary>
    /// <remarks>
    /// Encapsulates the logic for creating <see cref="MyNumber"/> instances either throug automated random generation or manual keyboard input.
    /// </remarks>
    public class MyNumberFactory : MyComparableFactory
    {

        /// <summary>
        /// Creates a new <see cref="MyNumber"/> with automated randomly generated attributes.
        /// </summary>
        /// <returns>A concrete <see cref="MyNumber"/> as an <see cref="IMyComparable"/>.</returns>
        public override IMyComparable RandomCreate()
        {
            return new MyNumber(base._create.RandomNumber());
        }

        /// <summary>
        /// Creates a new <see cref="MyNumber"/> with manual keyboard input attributes.
        /// </summary>
        /// <returns>A concrete <see cref="MyNumber"/> as an <see cref="IMyComparable"/>.</returns>
        public override IMyComparable KeyboardCreate()
        {
            return new MyNumber(base._read.KeyboardNumber());
        }
    }
}
