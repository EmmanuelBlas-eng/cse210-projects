using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        List<int> numbers = new List<int>();

        int inputNumber = -1;
        
        while (inputNumber != 0)
        {
            
            Console.Write("Enter number: ");
            string userInput = Console.ReadLine();
                inputNumber = int.Parse(userInput);

            if (inputNumber != 0 )
            {
                numbers.Add(inputNumber);
                 
            } 
        }

            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }

            Console.WriteLine($"The sum is: {sum}");


           float average = ((float)sum) / numbers.Count;
           Console.WriteLine($"The average number: {average}");


           int max = numbers[0];

           foreach (int number in numbers)
            {
            if (number > max)
                {
                    max = number;
                }
            }

            Console.WriteLine($"The Largest number is: {max}");



            int min = numbers[0];

            foreach (int number in numbers)
        {
            if (number < max)
            {
                max = number;
            }
        }

        Console.WriteLine($"The smallest number is: {min}");


        numbers.Sort();

        Console.WriteLine("The sorted list is: ");
        foreach (int number in numbers)
        {
            Console.WriteLine($" {number}");
        }
        
    }
}