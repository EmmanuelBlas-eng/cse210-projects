using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _unusedPrompts;
   

    public ListingActivity(): base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life having by having you list as many things as you can in a certain area."
    )
    {
        _prompts = new List<string>
        {
            "Who are the people you appreciate?",
            "What are the personal strength of yours?",
            "Who are people that you have helped this week?",
            "When have you felt inspiration or gratitude this month?",
            "Who are some of your personal heroes?"
        };

        _unusedPrompts = new List<string>(_prompts);

    }

    public void Run()
    {
        DisplayStartingMessage();

       
        Console.WriteLine("List as many responses as you can to the following prompt: ");
        Console.WriteLine($"---{GetRandomPrompt()}---");
        Console.Write("You may begin in:");
        ShowCountDown(5);
        Console.WriteLine();

        List<string> userItems = GetListFromUser();

        Console.WriteLine($"You listed {userItems.Count} items!");
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
    private List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime endtime = startTime.AddSeconds(GetDuration());

        while (DateTime.Now < endtime)
        {
            Console.Write("> ");

            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                items.Add(input);
            }
        }
        return items;
    }
}
    