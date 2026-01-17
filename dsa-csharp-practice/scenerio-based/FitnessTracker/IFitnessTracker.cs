using System;

namespace FitnessTracker
{
    interface IFitnessTracker
    {
        void AddRunner();
        void ShowRankings();
        void SortUsersBySteps();
    }
}