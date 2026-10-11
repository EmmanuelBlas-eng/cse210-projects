using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool running = true;
        while (running)
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    running = false;
                    Console.WriteLine("Keep pressing forward on your Eternal Quest!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\n========================================");
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Current Rank/Level: {GetPlayerRank()}");
        Console.WriteLine($"========================================");
    }

    // EXCEEDING REQUIREMENTS: Dynamic ranking/leveling system based on total score
    private string GetPlayerRank()
    {
        if (_score < 500) return "Novice Seeker (Level 1)";
        if (_score < 1500) return "Dedicated Disciple (Level 2)";
        if (_score < 3000) return "Quest Pathfinder (Level 3)";
        if (_score < 5000) return "Master Achiever (Level 4)";
        return "Eternal Explorer (Level 5+ Legend)";
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("  No goals created yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal (Bad Habit Penalty - Exceeds Requirements)");
        Console.Write("Which type of goal would you like to create? ");

        string typeChoice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal = null;

        if (typeChoice == "1")
        {
            newGoal = new SimpleGoal(name, description, points);
        }
        else if (typeChoice == "2")
        {
            newGoal = new EternalGoal(name, description, points);
        }
        else if (typeChoice == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            newGoal = new ChecklistGoal(name, description, points, target, bonus);
        }
        else if (typeChoice == "4")
        {
            newGoal = new NegativeGoal(name, description, points);
        }

        if (newGoal != null)
        {
            _goals.Add(newGoal);
            Console.WriteLine("Goal created successfully!");
        }
    }

    public void RecordEvent()
    {
        ListGoalDetails();
        if (_goals.Count == 0) return;

        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            Goal goal = _goals[index];
            int pointsEarned = goal.RecordEvent();
            _score += pointsEarned;

            if (pointsEarned > 0)
            {
                Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
            }
            else if (pointsEarned < 0)
            {
                Console.WriteLine($"Penalty applied: {pointsEarned} points lost. Stay focused!");
            }
            else
            {
                Console.WriteLine("This goal is already completed.");
            }
            Console.WriteLine($"You now have {_score} points.");
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        _goals.Clear();

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split(":");
            string type = parts[0];
            string details = parts[1];

            string[] values = details.Split(",");

            if (type == "SimpleGoal")
            {
                string name = values[0];
                string description = values[1];
                int points = int.Parse(values[2]);
                bool isComplete = bool.Parse(values[3]);
                _goals.Add(new SimpleGoal(name, description, points, isComplete));
            }
            else if (type == "EternalGoal")
            {
                string name = values[0];
                string description = values[1];
                int points = int.Parse(values[2]);
                _goals.Add(new EternalGoal(name, description, points));
            }
            else if (type == "ChecklistGoal")
            {
                string name = values[0];
                string description = values[1];
                int points = int.Parse(values[2]);
                int target = int.Parse(values[3]);
                int bonus = int.Parse(values[4]);
                int amountCompleted = int.Parse(values[5]);
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus, amountCompleted));
            }
            else if (type == "NegativeGoal")
            {
                string name = values[0];
                string description = values[1];
                int points = int.Parse(values[2]);
                _goals.Add(new NegativeGoal(name, description, points));
            }
        }
        Console.WriteLine("Goals loaded successfully!");
    }
}