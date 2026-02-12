using System;
using Week4.People;

// Week 4 exercise: Implement the decorator pattern to show califications
//Container Decorator: Adds a box around the calification

namespace Week4.Decorator_Pattern
{
    /// <summary>
    /// Implements a concrete decorator logic for an <see cref="AlumnoBaseDecorator"/> object. 
    /// </summary>
    /// <remarks>
    /// Decorates the calification string by enclosing it in a dots container. 
    /// </remarks>

    public class ContainerDecorator : AlumnoBaseDecorator
    {
        public ContainerDecorator(IAlumno alumno) : base(alumno) { }

        public override string ShowCalification()
        {
            string text = string.Format("*     {0}     *", base.ShowCalification());
            string box = new string('*', text.Length);
            return string.Format("{0}\n{1}\n{2}", box, text, box);
        }
    }
}
