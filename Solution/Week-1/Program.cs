using Microsoft.VisualBasic.FileIO;
using System;
using Week1;
using Week1.MyCollections;
using Week2.Iterator_Pattern;
using Week2.Strategy_Pattern;
using Week3.FactoryMethod_Pattern;

// Factorys: ( 1 MyNumber ) ( 2 Alumno ) ( 3 Professor )
// Week 3 Exercise: Implement a main where the Professor has a class to teach.

namespace Week3
{
    class Program
    {
        public static void Main(string[] args)
        {

            Professor professor = ((Professor)MyComparableFactory.RandomCreate(3));
            MyStack stacked = new MyStack();
            FillCollection(stacked, 2);

            IIterator iterator = stacked.CreateIterator();
            while (!iterator.IsDone())
            {
                professor.Attach((Alumno)iterator.CurrentItem());
                iterator.Next();
            }

            TeachingClasses(professor);

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
        /// <param name="option">Determines which concrete object to create for search in the collection (1: Number, 2: Alumno, 3: Professor).</param>
        public static void Report(IMyCollection collection, int option)
        {
            Console.WriteLine("Number of Items: "+ collection.Count());
            Console.WriteLine("Greaten Element: "+collection.Maximum());
            Console.WriteLine("Lesser Element: "+collection.Minimum());
            IMyComparable comparable = MyComparableFactory.KeyboardCreate(option);
            if (collection.Contains(comparable))
                Console.WriteLine("\nThe read element is in the collection");
            else
                Console.WriteLine("\nThe read element is not in the collection");
        }

        /// <summary>
        /// Fill the <see cref="IMyCollection"/> with 20 random <see cref="IMyComparable"/> objects.
        /// </summary>
        /// <param name="collection">The <see cref="IMyCollection"/> instance to be filled.</param>
        /// <param name="option">Determines which concrete objects to create for fill the collection (1: Number, 2: Alumno, 3: Professor).</param>
        public static void FillCollection(IMyCollection collection, int option)
        {
            for (int i = 0; i<20; i++)
            {
                collection.Add(MyComparableFactory.RandomCreate(option));
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

        /// <summary>
        /// Teaches a class speaking and writing.
        /// </summary>
        /// <param name="professor">The <see cref="Professor"/> instance that teach the class.</param>
        public static void TeachingClasses(Professor professor)
        {
            for (int i = 0; i<2; i++)
            {
                professor.SpeakToTheClass();
                professor.WriteInTheBoard();
            }
        }
    }

}
