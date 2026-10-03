using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;


public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        Console.WriteLine($"{_description}\n");


        Console.Write("\nHow long, in seconds, would you like for your session? ");
        string input = Console.ReadLine();
        while (!int.TryParse(input, out _duration) || _duration <= 0)
        {
            Console.Write("Please enter a valid positive integer for a seconds: ");
            input = Console.ReadLine();
            
        }
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner(3);
        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name}");
        ShowSpinner(4);
    }
    public void ShowSpinner(int seconds)
    {
        List<string> spinnerFrames = new List<string> { "|", "/", "-", "\\"};
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(spinnerFrames[i]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i = (i + 1) % spinnerFrames.Count;
        }
    }
    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);

            int length = i.ToString().Length;
            for (int j = 0; j < length; j++)
            {
                Console.Write("\b \b");
            }
        }
    }
}