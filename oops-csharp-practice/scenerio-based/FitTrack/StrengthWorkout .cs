using System;

public class StrengthWorkout : Workout
{
    public int Sets { get; set; }
    public int Reps { get; set; }

    public StrengthWorkout(int sets, int reps)
    {
        Sets = sets;
        Reps = reps;
    }

    public override void StartWorkout()
    {
        StartTime = DateTime.Now;
        Console.WriteLine("Strength workout started at " + StartTime);
    }

    public override void EndWorkout()
    {
        EndTime = DateTime.Now;
        Console.WriteLine("Strength workout ended at " + EndTime);
    }

    public override double CalculateCalories(double weight)
    {
        // Calories burned = sets * reps * 0.5 (approx.)
        return Sets * Reps * 0.5;
    }
}
