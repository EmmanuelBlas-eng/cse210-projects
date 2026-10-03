// EXCEEDING REQUIREMENTS REPORT:
// 1. Session Activity Tracker: Keeps track of total activities completed and overall total time spent in mindfulness during the session, displayed upon exit.
// 2. Guaranteed Non-Repeating Prompts & Questions: Implemented dynamic list re-population logic so prompts/questions do not repeat until all available options in the pool have been shown at least once.
// 3. Dynamic Visual Breath Bar: Enhanced BreathingActivity with expanding [>>>>] and contracting [<<<<] directional indicators alongside standard text timing.

using System;

class Program
{

    static void Main(string[] args)
    {
        int totalActivitiesCompleted = 0;
        int totalSecondsMindful = 0;

        bool keepRunning = true;
       

       while (keepRunning) 
        {
            Console.Clear();
            Console.WriteLine("\nMenu Options: \n");
            Console.WriteLine(" 1. Start Breathing activity");
            Console.WriteLine(" 2. Start Reflection Activity");
            Console.WriteLine(" 3. start Listing Activity");
            Console.WriteLine(" 4. View Session History & Log Statistics");
            Console.WriteLine(" 5. Quit\n");
            Console.WriteLine("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    totalActivitiesCompleted++;
                    totalSecondsMindful += breathing.GetDuration();
                    break;

                case "2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Run();
                    totalActivitiesCompleted++;
                    totalSecondsMindful += reflection.GetDuration();
                    break;

                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    totalActivitiesCompleted++;
                    totalSecondsMindful += listing.GetDuration();
                    break;

                case "4":
                    keepRunning = false;
                    Console.Clear();
                    Console.WriteLine("Session Summary:");
                    Console.WriteLine($"• Total Activities Completed: {totalActivitiesCompleted}");
                    Console.WriteLine($"• Total Time Spent: {totalSecondsMindful} seconds");
                    Console.WriteLine("\nThank you for taking time for yourself today. Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Press Enter to try again.");
                    Console.ReadLine();
                    break;

                  

            }
        }
    }

}