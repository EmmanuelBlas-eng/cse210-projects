using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("C# Object-Oriented Programming Tutorial", "Code Academy", 600);
        video1.AddComment(new Comment("Alice", "Great explanation of classes!"));
        video1.AddComment(new Comment("Bob", "This helped me pass my assignment. Thank you!"));
        video1.AddComment(new Comment("Charlie", "Could you do a follow-up on inheritance?"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Top 10 Unity Game Development Tips", "GameDev Pro", 850);
        video2.AddComment(new Comment("Dave", "Tip #3 saved me so much debugging time."));
        video2.AddComment(new Comment("Eve", "Awesome video as always!"));
        video2.AddComment(new Comment("Frank", "Loved the visuals in this one."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("How to Bake the Perfect Sourdough", "Baking Mastery", 1200);
        video3.AddComment(new Comment("Grace", "Tried this recipe today and the crust was amazing."));
        video3.AddComment(new Comment("Heidi", "What brand of flour do you recommend?"));
        video3.AddComment(new Comment("Ivan", "Best sourdough tutorial on YouTube!"));
        videos.Add(video3);

        // Video 4
        Video video4 = new Video("10 Minute Morning Stretch Routine", "Fitness With Sarah", 600);
        video4.AddComment(new Comment("Judy", "Doing this every morning now. Feels great!"));
        video4.AddComment(new Comment("Mallory", "Simple and easy to follow."));
        video4.AddComment(new Comment("Niaj", "My back feels so much better, thanks!"));
        videos.Add(video4);

        // Display video details and comments
        foreach (Video video in videos)
        {
            Console.WriteLine("========================================");
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.Name}: \"{comment.Text}\"");
            }

            Console.WriteLine();
        }
    }
}