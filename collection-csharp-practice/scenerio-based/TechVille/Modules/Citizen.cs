using System;

namespace TechVille.Modules
{
    public class Citizen
    {
        // Encapsulation
        private string id;
        private string name;
        private int age;
        private double income;
        private int residencyYears;
        private string servicePlan;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public double Income
        {
            get { return income; }
            set { income = value; }
        }

        public int ResidencyYears
        {
            get { return residencyYears; }
            set { residencyYears = value; }
        }

        public string ServicePlan
        {
            get { return servicePlan; }
            set { servicePlan = value; }
        }

        public Citizen()
        {
            ServicePlan = "Not Assigned";
        }

        public Citizen(string id, string name, int age, double income, int residencyYears)
        {
            Id = id;
            Name = name;
            Age = age;
            Income = income;
            ResidencyYears = residencyYears;
            ServicePlan = "Not Assigned";
        }

        public override string ToString()
        {
            return $"Citizen ID: {Id}\n" +
                   $"Name: {Name}\n" +
                   $"Age: {Age}\n" +
                   $"Income: {Income}\n" +
                   $"Residency Years: {ResidencyYears}\n" +
                   $"Service Plan: {ServicePlan}";
        }
    }
}
