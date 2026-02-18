using System.Collections.Generic;
using System.IO;
using TechVille.Modules;

namespace TechVille.Services
{
    public class FileHandler
    {
        private static string filePath = "citizens.txt";

        public static void Save(List<Citizen> citizens)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (Citizen c in citizens)
                {
                    sw.WriteLine($"{c.Id}|{c.Name}|{c.Age}|{c.Income}|{c.ResidencyYears}|{c.ServicePlan}");
                }
            }
        }

        public static List<Citizen> Load()
        {
            List<Citizen> citizens = new List<Citizen>();

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
                return citizens;
            }

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] parts = line.Split('|');

                Citizen c = new Citizen();
                c.Id = parts[0];
                c.Name = parts[1];
                c.Age = int.Parse(parts[2]);
                c.Income = double.Parse(parts[3]);
                c.ResidencyYears = int.Parse(parts[4]);
                c.ServicePlan = parts[5];

                citizens.Add(c);
            }

            return citizens;
        }
    }
}
