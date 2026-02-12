using System;
using Week4.People;

//Week 4 Exercise: Implement the decorator pattern to show califications
// Status Decorator: Adds the status of the grade "Promoted, Passed, Failed"

namespace Week4.Decorator_Pattern
{
    public class StatusDecorator : AlumnoBaseDecorator
    {
        /// <summary>
        /// Implements a concrete decorator logic for an <see cref="AlumnoBaseDecorator"/> object. 
        /// </summary>
        /// <remarks>
        /// Decorates the calification string by adding the calification status (Promoted, Passed, Failed). 
        /// </remarks>
        public StatusDecorator(IAlumno alumno) : base(alumno) { }

        public override string ShowCalification()
        {
            string status;
            int calification = this.Calification;
            if (calification>=7)
                status = "PROMOTED";
            else if ((7>calification)&&(calification>=4))
                status = "PASSED";
            else
                status = "FAILED";
            return string.Format("{0} ({1})", base.ShowCalification(), status);
        }
    }
}
