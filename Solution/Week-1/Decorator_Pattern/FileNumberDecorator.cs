using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4.People;

//Week 4 Exercise: Implement the decorator pattern to show califications
// FileNumberDecorator: Decorator that adds the file number of the student before the calification

namespace Week4.Decorator_Pattern
{
    /// <summary>
    /// Implements a concrete decorator logic for an <see cref="AlumnoBaseDecorator"/> object. 
    /// </summary>
    /// <remarks>
    /// Decorates the calification string by adding the file Number of the student. 
    /// </remarks>

    public class FileNumberDecorator : AlumnoBaseDecorator
    {
        public FileNumberDecorator(IAlumno alumno) : base(alumno) { }

        public override string ShowCalification()
        {
            string temp = base.ShowCalification();
            return temp.Insert(temp.IndexOf(' '), string.Format(" ({0}/{1})", this.FileNumber, this.Calification));
        }
    }
}
