using System;

namespace EduResults
{
    public class EduResultsMenu
    {
        private IEduResults eduUtil = new EduResultsUtility();
        public void ShowMenu()
        {
            int choice;

            do
            {
                Console.WriteLine("\n===== EduResults – Rank Sheet Generator =====");
                Console.WriteLine("1. View Final Rank List");
                Console.WriteLine("2. Add New District List");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        eduUtil.SortedResult();   // display handled in utility
                        break;

                    case 2:
                        eduUtil.AddList();        // input + add handled in utility
                        break;

                    case 3:
                        Console.WriteLine("Exiting EduResults...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

            } while (choice != 3);
        }
    }
}
