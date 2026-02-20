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
        /// Generates an <see cref="int"/> representing a correct answer to a question for exam simulation.
        /// </summary>
        /// <param name="question">The question number being answered.</param>
        /// <remarks>
        /// The question number is divided by 3, obtaining the remainder. The remainder represents the appropriate answer to the question.
        /// </remarks>
        /// <returns>The remainder <see cref="int"/> that represents the correct answer for that question.</returns>
        public override int AnswerQuestion(int question)
        {
            return question % 3;
        }
    }
}
