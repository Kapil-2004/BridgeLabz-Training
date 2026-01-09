using System;

public abstract class Workout
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public int DurationMinutes
    {
        get
        {
            return (int)(EndTime - StartTime).TotalMinutes;
        }
    }

    public abstract void StartWorkout();
    public abstract void EndWorkout();
    public abstract double CalculateCalories(double weight);
}
