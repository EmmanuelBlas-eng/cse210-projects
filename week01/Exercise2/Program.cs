using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage: ");
        string userInput = Console.ReadLine();
        int grade = int.Parse(userInput);

        string letter = "";
        

        if (grade >= 90 % 10)
        {
            letter = "A";
        
        }

        else if (grade >= 80)
        {
            letter = "B";
        }

        else if (grade >=70) 
        {
           letter = "C"; 
        }

        else if (grade >=60)
        {
            letter = "D";
        }

        else 
        {
            letter = "F";
        }

        string sign = "";
        int lastDigit = grade % 10;

        if (lastDigit >=7)
        {
            sign = "+";
        }

        else
        {
            sign = "-";
        }
       

        Console.WriteLine($"Your Grade is: {letter}{sign}");

        if (grade >=70)
        {
            Console.WriteLine("You Passed.");
        }
        else
        {
            Console.WriteLine("Better Luck next time.");
        }

    }
}