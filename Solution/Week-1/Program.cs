using MetodologíasDeProgramaciónI;
using Microsoft.VisualBasic.FileIO;
using System;
using Week1;
using Week1.MyCollections;
using Week1.People;
using Week2.Iterator_Pattern;
using Week2.Strategy_Pattern;
using Week3.FactoryMethod_Pattern;
using Week4.Decorator_Pattern;
using Week4.People;
using Week5.Command_Pattern;
using Week5.People;

// Factories: ( 1 MyNumber ) ( 2 Alumno ) ( 3 Professor ) ( 4 DiligentAlumno ) ( 5 AlumnoBaseDecorator ) ( 6 DiligentAlumnoBaseDecorator ) ( 7 AlumnoProxy )
//Week 6 Exercise: Add a CompositeAlumno to the queue

namespace Week3
{
    class Program
    {
        public static void Main(string[] args)
        {

                PrintTitle("Classroom handled by queue using command pattern");
                Classroom classroom = new Classroom();
                MyQueue queued = new MyQueue();

                CommandedQueue(queued, classroom, true, true, true);
                queued.Add(MyComparableFactory.RandomCreate(8));
                FillCollection(queued, 2);
                FillCollection(queued, 4);


            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }

        //------------------------------------------------------
        //                     FUNCTIONS
        //------------------------------------------------------
        public static void PrintTitle(string title)
        {
            Console.WriteLine("\n-----------------"+title+"-----------------\n");
        }

        /// <summary>
        /// Sets new specific behavior by enabling concrete commands in the collection.
        /// </summary>
        /// <param name="queue">The <see cref="MyQueue"/> instance to set the concrete commands.</param>
        /// <param name="classroom">The <see cref="Classroom"/> to wrap inside the concrete commands.</param>
        /// <param name="startCommand">Set the command to be executed when the collection process starts.</param>
        /// <param name="arribalCommand">Set the command to be executed whenever a new student arrives at the collection.</param>
        /// <param name="fullClassCommand">Set the command to be executed when the collection reaches its maximum capacity</param>
        public static void CommandedQueue(MyQueue queue, Classroom classroom, bool startCommand = false, bool arribalCommand = false, bool fullClassCommand = false) 
        {
            if(startCommand)
                queue.SetStartCommand(new StartCommand(classroom));
            if(arribalCommand)
                queue.SetAlumnoArrivalCommand(new AlumnoArrivalCommand(classroom));
            if(fullClassCommand)
                queue.SetFullClassroomCommand(new FullClassroomCommand(classroom));
        }

        /// <summary>
        /// Fill the <see cref="IMyCollection"/> with 20 random <see cref="IMyComparable"/> objects.
        /// </summary>
        /// <param name="collection">The <see cref="IMyCollection"/> instance to be filled.</param>
        /// <param name="option">Determines which concrete objects to create for fill the collection (1: Number, 2: Alumno, 3: Professor, 4: Diligent Alumno, 5: Decorated Alumno, 6: Decorated Diligent Alumno, 7: Proxy Alumno, 8: Composite Alumno).</param>
        public static void FillCollection(IMyCollection collection, int option)
        {
            for (int i = 0; i<20; i++)
            {
                collection.Add(MyComparableFactory.RandomCreate(option));
            }
        }

    }

}
