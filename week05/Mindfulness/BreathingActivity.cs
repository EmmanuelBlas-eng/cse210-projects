using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() :
    base("BreathingActivity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing. ")
    {
        
    }
    public void Run()
    {
        DisplayStartingMessage();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());

        Console.WriteLine();
        while (DateTime.Now < endTime)
        {
            
            Console.Write("Breathe in...");
            ShowAnimatedBreath(true, 4);
            Console.WriteLine();


            if(DateTime.Now >= endTime) break;


            Console.Write("Breathe out...");
            ShowAnimatedBreath(false, 4);
            Console.WriteLine("\n");
        }

        DisplayEndingMessage();

    }


    private void ShowAnimatedBreath(bool isBreatheIn, int seconds)
    {
        int steps = seconds * 2;
        string symbol = isBreatheIn ? ">" : "<";

        if (isBreatheIn)
        {
            for(int i = 1; i <= steps; i++)
            {
                Console.Write(symbol);
                Thread.Sleep(500);
            }
        }
        else
        {
            for (int i = 0; i < steps; i++) Console.Write(symbol);
            for (int i = 0; i < steps; i++)
            {
                Thread.Sleep(500);
                Console.Write("\b \b");
            }
        }
    }
}