/*
 * CSE 210 Scripture Memorizer
 * 
 * CREATIVITY AND EXCEEDING REQUIREMENTS:
 * 1. Scripture Library with File Fallback: Loads scriptures from an external text file ("scriptures.txt") 
 *    formatted as `Book|Chapter|StartVerse|EndVerse|Text`. If the file is absent, it loads a default library.
 * 2. Random Scripture Selection: Randomly selects a scripture from the library each session.
 * 3. Smart Word Selection: The hiding algorithm only selects words that are not already hidden.
 * 4. Punctuation Preservation: The Word class retains punctuation marks (e.g., commas, periods) when replacing letters with underscores.
 */

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> library = LoadScriptureLibrary("scriptures.txt");

       
        Random random = new Random();
        Scripture scripture = library[random.Next(library.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

         
            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.WriteLine("Press Enter to continue or type 'quit' to finish:");
            string input = Console.ReadLine();

            if (input != null && input.Trim().ToLower() == "quit")
            {
                break;
            }

       
            scripture.HideRandomWords(3);
        }
    }

  
    private static List<Scripture> LoadScriptureLibrary(string filePath)
    {
        List<Scripture> scriptures = new List<Scripture>();

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

               
                string[] parts = line.Split('|');
                if (parts.Length == 5)
                {
                    string book = parts[0].Trim();
                    int chapter = int.Parse(parts[1].Trim());
                    int startVerse = int.Parse(parts[2].Trim());
                    int endVerse = int.Parse(parts[3].Trim());
                    string text = parts[4].Trim();

                    Reference reference;
                    if (startVerse == endVerse)
                    {
                        reference = new Reference(book, chapter, startVerse);
                    }
                    else
                    {
                        reference = new Reference(book, chapter, startVerse, endVerse);
                    }

                    scriptures.Add(new Scripture(reference, text));
                }
            }
        }

        
        if (scriptures.Count == 0)
        {
            scriptures.Add(new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the LORD with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."
            ));
            scriptures.Add(new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
            ));
            scriptures.Add(new Scripture(
                new Reference("Ether", 12, 27),
                "And if men come unto me I will show unto them their weakness. I give unto men weakness that they may be humble; and my grace is sufficient for all men."
            ));
        }

        return scriptures;
    }
}