using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompts;
    private List<string> _question;

    private List<string> _unusedPrompts;
    private List<string> _unusedQuestions;
    public ReflectionActivity()
    : base("Reflection Activity", "This activity will help you reflect on the times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life")
    {
        _prompts = new List<string>
        {
            "Thinks of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of atime when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _question = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done something like this before",
            "How you get started?",
            "How did you feel when it was complete?",
            "What made this time different then other times when you were not as successful?",
            "What is your favorite thing is about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experiences?",
            "How can you keep this experience in mind in the future?"

        };

        _unusedPrompts = new List<string>(_prompts);
        _unusedQuestions = new List<string>(_question);
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("\nConsider the following Prompt: ");
        Console.WriteLine($"\n--- {GetRandomPrompt()} ---");
        Console.WriteLine("\nWhen you have something in mind press enter to continue.");
        Console.ReadLine();


        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);

        Console.Clear();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            string question = GetRandomQuestion();
            Console.Write($"> {question} ");
            ShowSpinner(5);
            Console.WriteLine();
        }
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        if (_unusedPrompts.Count == 0)
        {
            _unusedPrompts = new List<string>(_prompts);
        }

        Random rand = new Random();
        int index = rand.Next(_unusedPrompts.Count);
        string prompt = _unusedPrompts[index];
        _unusedPrompts.RemoveAt(index);

        return prompt;
    }

    private string GetRandomQuestion()
    {
        if (_unusedQuestions.Count == 0)
        {
            _unusedQuestions = new List<string>(_question);
        }

        Random rand = new Random();
        int index = rand.Next(_unusedQuestions.Count);
        string question = _unusedQuestions[index];
        _unusedQuestions.RemoveAt(index);

        return question;
    }
}