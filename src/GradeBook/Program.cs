using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            // A Gradebook application, enter grades and they will be written to a text file.
            // The highest, lowest and average grades will be calculated and printed to the console.

            IBook book = new DiskBook("The grade book");
            book.GradeAdded += OnGradeAdded;


            // book.AddGrade(40.2);
            // book.AddGrade(89.3);
            // book.AddGrade(88.8);

            EnterGrades(book);

            System.Console.WriteLine("Enter a grade");

            Statistics stats = book.GetStatistics();

            Console.WriteLine($"For the book named {book.Name}.");
            Console.WriteLine($"The highest grade is {stats.High:N2}.");
            Console.WriteLine($"The lowest grade is {stats.Low:N2}.");
            Console.WriteLine($"The average grade is {stats.Average:N2}.");
            Console.WriteLine($"The grade letter is {stats.Letter}.");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a Grade or 'q' to quit");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    //CLOSE all files and connections
                    // This code is always run.
                    System.Console.WriteLine();
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}
