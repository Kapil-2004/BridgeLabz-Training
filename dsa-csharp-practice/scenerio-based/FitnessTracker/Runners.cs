using System;

namespace FitnessTracker
{
    public class Runners
    {
        public string Name { get; private set; }
        public int Steps { get; private set; }

        public Runners(string name, int steps)
        {
            Name = name;
            Steps = steps;
        }

        public string Display()
        {
            return "Total Steps of " + Name + ": " + Steps;
        }
    }
}
