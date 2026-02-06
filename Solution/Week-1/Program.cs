using System;
using Week2.Iterator_Pattern;
using Week2.MyCollections;
using Week2.Strategy_Pattern;

//Week 2 Exercise:
//ITERATOR-> modify main to use printElements
//STRATEGY -> modify main to change comparison strategy of the elements

namespace Week2
{
    class Program
    {
        public static void Main(string[] args)
        {

            MyQueue queued = new MyQueue();
            FillAlumnos(queued);
            PrintTitle("Comparison for Name");
            ChangeComparisonStrategy(queued, new NameComparison());
            Report(queued);
            PrintTitle("Comparison for File Number");
            ChangeComparisonStrategy(queued, new FileNumberComparison());
            Report(queued);
            PrintTitle("Comparison for Average");
            ChangeComparisonStrategy(queued, new AverageComparison());
            Report(queued);
            PrintTitle("Comparison for ID");
            ChangeComparisonStrategy(queued, new IDComparison());
            Report(queued);

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
        /// Displays a detailed report based on the provided collection.
        /// </summary>
        /// <remarks>The report includes the total elements count, the minimum and maximum values, and the result of searching for a specific element provided via keyboard input</remarks>
        /// <param name="collection">The <see cref="IMyCollection"/> instance to be analyzed.</param>
        public static void Report(IMyCollection collection)
        {
            Console.WriteLine("Number of Items: ");
            Console.WriteLine(collection.Count());
            Console.WriteLine("\nYounger Student\n"); 
            Console.WriteLine(collection.Minimum().ToString()); 
            Console.WriteLine("\nOlder Student\n");
            Console.WriteLine(collection.Maximum().ToString());
            Console.Write("Introduce information for search:");
            string search = Console.ReadLine();
            double searchNumber = 0;
            double.TryParse(search, out searchNumber);
            IMyComparable searched = new Alumno(search, (int)searchNumber, (int)searchNumber, searchNumber);
            if (collection.Contains(searched))
                Console.WriteLine("The read element is in the collection");
            else
                Console.WriteLine("The read element is not in the collection");
        }

        /// <summary>
        /// Fill the <see cref="IMyCollection"/> with 20 random <see cref="Alumno"/>.
        /// </summary>
        /// <param name="collection">The <see cref="IMyCollection"/> instance to be filled.</param>
        public static void FillAlumnos (IMyCollection collection)
        {
            Random r = new Random();
            FileNumberComparison comparison = new FileNumberComparison();
            string[] names = new string[] { "Johnny", "Simon", "John", "Kyle", "Alejandro", "Joel", "Arthur", "Leon", "Valeria", "Kate", "Farah", "Sarah", "Ada", "Helena", "Alice" };
            for (int i = 0; i<20; i++)
            {
                double prom = double.Parse(r.NextDouble().ToString("F2")); //Para que sean solo dos cifras significativas
                IMyComparable student = new Alumno(names[r.Next(names.Length-1)], r.Next(10000000, 50000000), r.Next(10000, 70000), prom);
                ((Alumno)student).SetStrategy(comparison);
                collection.Add(student);
            }
        }

        /// <summary>
        /// Display the <see cref="IMyCollection"/> elements using the concrete iterator.
        /// </summary>
        /// <param name="collection">The <see cref="IMyCollection"/> instance to be iterated.</param>
        public static void PrintElements(IMyCollection collection)
        {
            IIterator concreteIterator = collection.CreateIterator();
            concreteIterator.First();
            while (!concreteIterator.IsDone())
            {
                Console.WriteLine(concreteIterator.CurrentItem());
                concreteIterator.Next();
            }

        }

        /// <summary>
        /// Change the <see cref="IComparisonStrategy"/> to all the <see cref="IMyCollection"/> elements.
        /// </summary>
        /// <param name="collection">The <see cref="IMyCollection"/> instance to be iterated.</param>
        /// <param name="newStrategy">The new <see cref="IComparisonStrategy"/> to set.</param>
        public static void ChangeComparisonStrategy(IMyCollection collection, IComparisonStrategy newStrategy)
        {
            IIterator concreteIterator = collection.CreateIterator();
            while (!concreteIterator.IsDone())
            {
                ((Alumno)concreteIterator.CurrentItem()).SetStrategy(newStrategy);
                concreteIterator.Next();
            }
        }
    }

}
