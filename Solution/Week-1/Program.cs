using System;
using Week1.MyCollections;

//Week 1 Exercise:
//implement a main module where a multipleCollection is created
//fill and report the collection using functions

namespace Week1
{
    class Program
    {
        public static void Main(string[] args)
        {

            MyStack stacked = new MyStack();
            MyQueue queued = new MyQueue();
            MultipleCollection multiple = new MultipleCollection(stacked, queued);

            FillAlumnos(stacked);
            Console.WriteLine("MyStack filled");
            FillAlumnos(queued);
            Console.WriteLine("MyQueue filled");

            Report(multiple);
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }

        //------------------------------------------------------
        //                     FUNCTIONS
        //------------------------------------------------------
        /// <summary>
        /// Displays a detailed report based on the provided collection.
        /// </summary>
        /// <remarks>The report includes the total elements count, the minimum and maximum values, and the result of searching for a specific element provided via keyboard input</remarks>
        /// <param name="collection">The <see cref="IMyColleccion"/> instance to be analyzed.</param>
        public static void Report(IMyCollection collection)
        {
            Console.WriteLine(collection.Count());
            Console.WriteLine("\nYounger Student\n"); 
            Console.WriteLine(collection.Minimum().ToString()); 
            Console.WriteLine("\nOlder Student\n");
            Console.WriteLine(collection.Maximum().ToString());

            //search for an student by their file number
            Console.Write("introduce the number of the student file:"); 
            int fileNumber = int.Parse(Console.ReadLine());
            IMyComparable search = new Alumno("nombre", 1, fileNumber, 1); 
            if (collection.Contains(search))
                Console.WriteLine("The student is in the collection");
            else
                Console.WriteLine("The student is not in the collection");
        }

        /// <summary>
        /// Fill the <see cref="IMyCollection"/> with 20 random <see cref="Alumno"/>.
        /// </summary>
        /// <param name="collection">The <see cref="IMyColleccion"/> instance to be filled.</param>
        public static void FillAlumnos (IMyCollection collection)
        {
            Random r = new Random();
            string[] names = new string[] { "Johnny", "Simon", "John", "Kyle", "Alejandro", "Joel", "Arthur", "Leon", "Valeria", "Kate", "Farah", "Sarah", "Ada", "Helena", "Alice" };
            for (int i = 0; i<20; i++)
            {
                IMyComparable student = new Alumno(names[r.Next(names.Length-1)], r.Next(10000000, 50000000), r.Next(10000, 70000), r.NextDouble());
                collection.Add(student);
            }
        }
    }

}
