using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4.People;

//Week 4 Exercise : Implement the decorator pattern to show califications
//Letter decorator: Adds the calification in letters

namespace Week4.Decorator_Pattern
{
    /// <summary>
    /// Implements a concrete decorator logic for an <see cref="AlumnoBaseDecorator"/> object. 
    /// </summary>
    /// <remarks>
    /// Decorates the calification string by adding the calification in letters. 
    /// </remarks>
    public class LetterDecorator : AlumnoBaseDecorator
    {
        public LetterDecorator(IAlumno alumno) : base(alumno) { }

        public override string ShowCalification()
        {
            string[] score = { "CERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN" };
            return string.Format("{0} ({1})", base.ShowCalification(), score[this.Calification]);
        }
    }
}
