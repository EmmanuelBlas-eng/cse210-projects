using System;

public class Entry
{
    public string _date { get ;set;}
    public string _promptText { get; set;}
    public string _entryText { get; set;}
    public string _mood { get; set;}

    public Entry(string date, string promptText, string entryText, string mood = "N/A")
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
        _mood =mood;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Response: {_entryText}");
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine(new string('-', 40));
    }

    public string GetAsFormattedString(string delimiter = "|~|")
    {
        return $"{_date}{delimiter}{_promptText}{delimiter}{_entryText}{delimiter}{_mood}";
    }
}