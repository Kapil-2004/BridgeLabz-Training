using System;
using System.Collections.Generic;

public class Menu
{
    private EngagementUtility utility = new EngagementUtility();

    public void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("\n1. Register Creator");
            Console.WriteLine("2. Show Top Posts");
            Console.WriteLine("3. Calculate Average Likes");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RegisterCreator();
                    break;
                case "2":
                    ShowTopPosts();
                    break;
                case "3":
                    ShowAverageLikes();
                    break;
                case "4":
                    Console.WriteLine("Logging off — Keep Creating with StreamBuzz!");
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }

    private void RegisterCreator()
    {
        Console.Write("Enter Creator Name: ");
        string name = Console.ReadLine();

        double[] likes = new double[4];
        Console.WriteLine("Enter weekly likes (Week 1 to 4):");
        for (int i = 0; i < 4; i++)
        {
            likes[i] = double.Parse(Console.ReadLine());
        }

        CreatorStats creator = new CreatorStats(name, likes);
        utility.RegisterCreator(creator);
    }

    private void ShowTopPosts()
    {
        Console.Write("Enter like threshold: ");
        double threshold = double.Parse(Console.ReadLine());

        Dictionary<string, int> topPosts = utility.GetTopPostCounts(CreatorStats.EngagementBoard, threshold);

        if (topPosts.Count == 0)
        {
            Console.WriteLine("No top-performing posts this week");
        }
        else
        {
            foreach (KeyValuePair<string, int> kvp in topPosts)
            {
                Console.WriteLine(kvp.Key + " - " + kvp.Value);
            }
        }
    }

    private void ShowAverageLikes()
    {
        double average = utility.CalculateAverageLikes();
        Console.WriteLine("Overall average weekly likes: " + Math.Round(average));
    }
}
