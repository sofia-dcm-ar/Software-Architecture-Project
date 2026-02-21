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

// Factories:
// ( 1 MyNumber ) ( 2 Alumno ) ( 3 Professor ) ( 4 DiligentAlumno )
// ( 5 AlumnoBaseDecorator ) ( 6 DiligentAlumnoBaseDecorator ) ( 7 AlumnoProxy ) (8 CompositeAlumno )
//Week 7 Exercise: Add a specific amount of Alumnos of different types using a function

namespace Week3
{
    class Program
    {
        public static void Main(string[] args)
        { 
            PrintTitle("Classroom handled by queue using command pattern");
            Classroom classroom = new Classroom();
            MyQueue queued = new MyQueue();
            try
            {
                CommandedQueue(queued, classroom, true, true, true);

                //1 Composite Alumno -> Random
                FillCollection(queued, 8, 1, 1);
                PrintTitle("Composite Alumno creado");
                //3 Proxy Alumno -> Random
                FillCollection(queued, 7, 3, 1);
                PrintTitle("proxis creado");
                // 16 Diligent Alumno -> Random
                FillCollection(queued, 6, 16, 1);
                PrintTitle("diligent Alumno random creado");
                //4 Diligent Alumno -> File read
                FillCollection(queued, 6, 4, 3);
                PrintTitle("diligent Alumno file creado");
                //5 Alumno -> File read
                FillCollection(queued, 5, 5, 3);
                PrintTitle(" Alumno file creado");
                //10 Alumno -> Random
                FillCollection(queued, 5, 10, 1);
                PrintTitle(" Alumno random creado");
                //1 Alumno -> Keyboard
                FillCollection(queued, 2, 1, 2);
                PrintTitle(" Alumno teclado creado");

            }
            catch (ArgumentException ex)
            { Console.WriteLine(ex.Message); }

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
        /// Fill the <see cref="IMyCollection"/> with <see cref="IMyComparable"/> objects following the selected options.
        /// </summary>
        /// <param name="collection">The <see cref="IMyCollection"/> instance to be filled.</param>
        /// <param name="alumnoOption">Determines which concrete objects to create for fill the collection (1: Number, 2: Alumno, 3: Professor, 4: Diligent Alumno, 5: Decorated Alumno, 6: Decorated Diligent Alumno, 7: Proxy Alumno, 8: Composite Alumno).</param>
        /// <param name="amount">Determines the amount of instances to create and add to the collection.</param>
        /// <param name="creationOption">Determines the imput method for create the <see cref="IMyComparable"/> instances (1: Random, 2: Keyboard, 3: Text file).</param>
        public static void FillCollection(IMyCollection collection, int alumnoOption, int amount, int creationOption) 
        {
            for (int i = 0; i<amount; i++)
            {
                switch (creationOption)
                {
                    case 1:
                        collection.Add(MyComparableFactory.RandomCreate(alumnoOption));
                        break;
                    case 2:
                        collection.Add(MyComparableFactory.KeyboardCreate(alumnoOption));
                        break;
                    case 3:
                        collection.Add(MyComparableFactory.FileCreate(alumnoOption));
                        break;
                }
                
            }
        }

    }

}
