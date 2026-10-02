using System;
using System.Reflection;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Testing BaseAssignment Class
            Assignment baseAssignment = new Assignment("Samuel Bennett", "Multiplicaiton");
            Console.WriteLine(baseAssignment.GetSummary());
            Console.WriteLine();


            // 2. Test MathAssignment Class
            MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fraction", "7.3", "8-19") ;
            Console.WriteLine(mathAssignment.GetSummary());
            Console.WriteLine(mathAssignment.GetHomeworkList());
            Console.WriteLine();

            // 3. Test WritingAssingment Class
            WritingAssignment writingAssignment = new WritingAssignment("Mary Waters", "Eurupean History", "The Causes of the World War II");
            Console.WriteLine(writingAssignment.GetSummary());
            Console.WriteLine(writingAssignment.GetWritingInformation());
        }
    }
}