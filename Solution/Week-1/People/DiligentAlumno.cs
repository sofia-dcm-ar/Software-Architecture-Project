using System;
using Week1.People;

//Week 4 Exercise: Create the very diligent student that inherits from Student and reimplements the answer question method.

namespace Week4.People
{
    /// <summary>
    /// Represents a diligent Student entity that extends <see cref="Alumno"/> and has the highest value calification attribute.
    /// </summary>
    /// <remarks>
    /// Inherits from <see cref="Alumno"/> and implements specific exam behaviors for develop the best calification.
    /// </remarks>
    public class DiligentAlumno :Alumno
    {
        public DiligentAlumno(string name, int id, int fileNumber, double average) : base(name, id, fileNumber, average) { }

        /// <summary>
        /// Generates an <see cref="int"/> representing an answer to a question for exam simulation.
        /// </summary>
        /// <param name="question">The question number being answered.</param>
        /// <returns>The <see cref="int"/> 3 , that represents the highest score</returns>
        public override int AnswerQuestion(int question)
        {
            return question % 3;
        }
    }
}
