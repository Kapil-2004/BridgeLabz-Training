using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fittrack
{
    internal interface ITrackable
    {
        void StartWorkout();
        void EndWorkout();
        double CalculateCalories();
    }
}
