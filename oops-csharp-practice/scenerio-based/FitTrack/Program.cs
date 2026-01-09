using System;

class Program
{
    static void Main(string[] args)
    {
        // Create user profile
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        Console.Write("Enter your age: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Enter your weight (kg): ");
        double weight = double.Parse(Console.ReadLine());

        Console.Write("Enter your height (cm): ");
        double height = double.Parse(Console.ReadLine());

        UserProfile user = new UserProfile(name, age, weight, height);

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n--- Fitness Tracker Menu ---");
            Console.WriteLine("1. Add Cardio Workout");
            Console.WriteLine("2. Add Strength Workout");
            Console.WriteLine("3. Show Workout History");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter distance (km): ");
                    double distance = double.Parse(Console.ReadLine());

                    CardioWorkout cardio = new CardioWorkout(distance);
                    cardio.StartWorkout();
                    Console.WriteLine("Press Enter to end workout...");
                    Console.ReadLine();
                    cardio.EndWorkout();

                    user.AddWorkout(cardio);
                    Console.WriteLine($"Calories burned: {cardio.CalculateCalories(user.Weight):0.00}");
                    break;

                case "2":
                    Console.Write("Enter number of sets: ");
                    int sets = int.Parse(Console.ReadLine());

                    Console.Write("Enter number of reps per set: ");
                    int reps = int.Parse(Console.ReadLine());

                    StrengthWorkout strength = new StrengthWorkout(sets, reps);
                    strength.StartWorkout();
                    Console.WriteLine("Press Enter to end workout...");
                    Console.ReadLine();
                    strength.EndWorkout();

                    user.AddWorkout(strength);
                    Console.WriteLine($"Calories burned: {strength.CalculateCalories(user.Weight):0.00}");
                    break;

                case "3":
                    user.ShowWorkoutHistory();
                    break;

                case "4":
                    exit = true;
                    Console.WriteLine("Exiting Fitness Tracker. Stay healthy!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
