using System;

namespace FitnessTracker
{
    public class FitnessTrackerUtility : IFitnessTracker
    {
        private Runners[] runners;

        public FitnessTrackerUtility()
        {
            runners = new Runners[]
            {
                new Runners("Alice", 12000),
                new Runners("Bob", 15000),
                new Runners("Charlie", 8000),
                new Runners("Diana", 20000),
                new Runners("Ethan", 17000),
                new Runners("Fiona", 11000),
                new Runners("George", 9000),
                new Runners("Hannah", 14000)
            };
        }

        // ✔ Matches interface
        public void AddRunner()
        {
            Console.WriteLine("Enter The Name of Runner:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter The Steps of Runner:");
            int steps = Convert.ToInt32(Console.ReadLine());

            Runners newRunner = new Runners(name, steps);

            // Create new array with +1 size
            Runners[] temp = new Runners[runners.Length + 1];

            for (int i = 0; i < runners.Length; i++)
            {
                temp[i] = runners[i];
            }

            temp[temp.Length - 1] = newRunner;
            runners = temp;

            Console.WriteLine("Runner added successfully!");
        }

        public void ShowRankings()
        {
            Console.WriteLine("\n--- Rankings ---");
            for (int i = runners.Length-1; i>=0 ; i--)
            {
                Console.WriteLine(runners[i].Display());
            }
        }

        public void SortUsersBySteps()
        {
            for (int i = 0; i < runners.Length - 1; i++)
            {
                for (int j = 0; j < runners.Length - 1 - i; j++)
                {
                    if (runners[j].Steps > runners[j + 1].Steps)
                    {
                        Runners temp = runners[j];
                        runners[j] = runners[j + 1];
                        runners[j + 1] = temp;
                    }
                }
            }

            ShowRankings();
        }
    }
}
