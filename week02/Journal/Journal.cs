using System;
using System.Collections.Generic;
using System.IO;



public class Journal
{
    public List<Entry> _entries { get; set; } = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\nYour Journal is currently empty.\n");
            return;
        }

        Console.WriteLine("\n--- Journal Entries ---");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        string delimiter = "|~|";
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.GetAsFormattedString(delimiter));
            }
        }
        Console.WriteLine($"\nJournal saved successfully to '{file}'.\n");
    }
    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine($"\nError: The file '{file}' does not exist.\n");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(file);
        string[] delimiter = new string[] { "|~|"};

        foreach (string line in lines)
        {
            string[] parts = line.Split(delimiter, StringSplitOptions.None);
            if (parts.Length >= 3)
            {
                string date = parts[0];
                string prompt = parts[1];
                string response = parts[2];
                string mood = parts.Length > 3 ? parts[3] : "N/A";

                _entries.Add(new Entry(date, prompt, response, mood));
            }
        }
        Console.WriteLine($"\nJournal loaded successfully from '{file}'.\n");
    }
}

