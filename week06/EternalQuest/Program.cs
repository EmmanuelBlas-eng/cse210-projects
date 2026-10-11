using System;

// ====================================================================================
// PROGRAM: Eternal Quest (W06 Project - CSE 210)
// AUTHOR: Emmanuel Blas Roberto
// 
// DESCRIPTION OF HOW REQUIREMENTS WERE EXCEEDED:
// 1. Added a "NegativeGoal" class that allows users to track bad habits and deduct points 
//    when recorded, adding an extra layer of real-life accountability to the gamification.
// 2. Implemented a dynamic "Rank & Leveling System" (`GetPlayerRank()`) that automatically
//    upgrades the user's title (e.g., Novice Seeker -> Dedicated Disciple -> Eternal Explorer)
//    as their total score increases.
// ====================================================================================

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}