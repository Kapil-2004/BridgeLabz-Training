using System;
using System.Collections.Generic;

public class UserProfile
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }

    public List<Workout> WorkoutHistory { get; set; }

    public UserProfile(string name, int age, double weight, double height)
    {
        Name = name;
        Age = age;
        Weight = weight;
        Height = height;
        WorkoutHistory = new List<Workout>();
    }

    public void AddWorkout(Workout workout)
    {
        WorkoutHistory.Add(workout);
        Console.WriteLine($"{workout.GetType().Name} added for {Name}.");
    }

    public void ShowWorkoutHistory()
    {
        Console.WriteLine($"\n{Name}'s Workout History:");
        foreach (var w in WorkoutHistory)
        {
            Console.WriteLine($"{w.GetType().Name} | Duration: {w.DurationMinutes} min | Calories burned: {w.CalculateCalories(Weight):0.00}");
        }
    }
}
