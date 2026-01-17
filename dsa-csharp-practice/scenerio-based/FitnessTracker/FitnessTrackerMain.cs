using System;
using System.ComponentModel.Design;

namespace FitnessTracker
{
    public class FitnessTrackerMain
    {
        public void Start()
        {
            FitnessTrackerMenu menu = new FitnessTrackerMenu();
            menu.ShowMenu();
        }
    }
}