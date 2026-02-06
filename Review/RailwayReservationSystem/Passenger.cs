using System;
using System.Dynamic;

namespace RailwayReservationSystem
{
    class Passenger
    {
        public string Name{get ; set;}
        public int Age{get; set;}
        public int PNR{get; set;}
        public string Category{get; set;}
        public double Fare { get; set; }

        public Passenger(string name, int age, int pnr, string category , double fare)
        {
            Name = name;
            Age = age;
            PNR = pnr;
            Category = category;
            Fare = fare;    
        }
    }
}