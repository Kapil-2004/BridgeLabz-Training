using System;

public class CardioWorkout : Workout
{
    public double Distance { get; set; } // km

    public CardioWorkout(double distance)
    {
        Distance = distance;
    }

    public override void StartWorkout()
    {
        StartTime = DateTime.Now;
        Console.WriteLine("Cardio workout started at " + StartTime);
    }

    public override void EndWorkout()
    {
        EndTime = DateTime.Now;
        Console.WriteLine("Cardio workout ended at " + EndTime);
    }

    public override double CalculateCalories(double weight)
    {
        // Calories burned = distance * weight * 1.036 (approx.)
        return Distance * weight * 1.036;
    }
}
