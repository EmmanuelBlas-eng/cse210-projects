using System;


class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;


        Console.WriteLine("\nWelcome to the journal Program!\n");

        while (running)
        {
            Console.WriteLine("\nPlease choose one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.WriteLine("\nWhat would you like to do?");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("> ");
                    string response = Console.ReadLine();


                    Console.WriteLine("How would describe your mood today? ");
                    Console.Write("> ");
                    // Creativity addition: each journal entry also records the user's mood.
                    string mood = Console.ReadLine();

                    string currentDate = DateTime.Now.ToShortDateString();
                    Entry newEntry = new Entry(currentDate, prompt, response, mood);
                    journal.AddEntry(newEntry);
                    Console.WriteLine("\nEntry recorded!\n");
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                
                case "3":
                    Console.WriteLine("What is the filename?");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "4":
                    Console.Write("What is the file name? ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("\nGoodbye!");
                    break;

                default:
                    Console.WriteLine("\nInvalid selection. Please enter a number between 1 and 5.\n");
                    break;

            }
        }
    }
}