using System;
using System.Collections.Generic;

namespace EduResults
{
    public class EduResultsUtility : IEduResults
    {
        private List<List<Student>> allDistricts;
        private MergeSorter sorter;

        public EduResultsUtility()
        {
            allDistricts = new List<List<Student>>();
            sorter = new MergeSorter();

            // Load initial sample data
            LoadDistrictData();
        }

        // ===== Load Sample Districts =====
        private void LoadDistrictData()
        {
            // District 1
            List<Student> district1 = new List<Student>
            {
                new Student(101, "Amit", 95),
                new Student(102, "Ravi", 90),
                new Student(103, "Neha", 85)
            };

            // District 2
            List<Student> district2 = new List<Student>
            {
                new Student(201, "Kiran", 98),
                new Student(202, "Pooja", 90),
                new Student(203, "Manoj", 80)
            };

            allDistricts.Add(district1);
            allDistricts.Add(district2);
        }

        // ===== Menu Option 2: Add New District =====
        public void AddList()
        {
            Console.Write("\nEnter number of students in this district: ");
            int n;

            if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.WriteLine("Invalid number.");
                return;
            }

            List<Student> newDistrict = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\nStudent {0}", i + 1);

                Console.Write("Roll No: ");
                int rollNo = int.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Score: ");
                int score = int.Parse(Console.ReadLine());

                newDistrict.Add(new Student(rollNo, name, score));
            }

            allDistricts.Add(newDistrict);

            Console.WriteLine("New district list added successfully!");
        }

        // ===== Menu Option 1: Show Final Rank List =====
        public void SortedResult()
        {
            List<Student> combined = new List<Student>();

            foreach (var district in allDistricts)
                combined.AddRange(district);

            List<Student> finalRankList = sorter.Sort(combined);

            Console.WriteLine("\nFinal State-Wise Rank List\n");

            int rank = 1;
            foreach (var student in finalRankList)
            {
                Console.WriteLine("Rank {0}: {1}", rank, student);
                rank++;
            }
        }
    }
}
