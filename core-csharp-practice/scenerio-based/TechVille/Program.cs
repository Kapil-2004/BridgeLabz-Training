using System;

namespace TechVille
{
    class Program
    {
        /// <summary>
        /// Module 3: This program stores multiple citizen IDs using arrays.
        /// It also manages zone and sector citizen counts using a 2D array.
        /// It supports basic operations like sorting, searching, and copying data.
        /// </summary>

        static void Main(string[] args)
        {
            // 1D Array: Store citizen IDs (capacity 1000)
            int[] citizenIds = new int[1000];
            int citizenCount = 0;

            // 2D Array: 5 zones and 5 sectors in each zone
            int[,] zoneSectorCounts = new int[5, 5];

            while (true)
            {
                Console.WriteLine("\n===== TechVille Smart Citizen Database (Module 3) =====");
                Console.WriteLine("1. Add Citizen ID");
                Console.WriteLine("2. Display Citizen IDs");
                Console.WriteLine("3. Sort Citizen IDs");
                Console.WriteLine("4. Search Citizen ID");
                Console.WriteLine("5. Copy Citizen IDs");
                Console.WriteLine("6. Update Zone-Sector Citizen Count");
                Console.WriteLine("7. Display Zone-Sector Citizen Counts");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid choice!");
                    continue;
                }

                if (choice == 0)
                {
                    Console.WriteLine("Exiting Module 3...");
                    break;
                }

                switch (choice)
                {
                    case 1:
                        // Add Citizen ID
                        if (citizenCount >= citizenIds.Length)
                        {
                            Console.WriteLine("Citizen ID storage is full!");
                            break;
                        }

                        Console.Write("Enter Citizen ID: ");
                        if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
                        {
                            Console.WriteLine("Invalid Citizen ID!");
                            break;
                        }

                        citizenIds[citizenCount] = id;
                        citizenCount++;

                        Console.WriteLine("Citizen ID added successfully!");
                        break;

                    case 2:
                        // Display Citizen IDs
                        if (citizenCount == 0)
                        {
                            Console.WriteLine("No Citizen IDs found!");
                            break;
                        }

                        Console.WriteLine("\nCitizen IDs:");
                        for (int i = 0; i < citizenCount; i++)
                        {
                            Console.Write(citizenIds[i] + " ");
                        }
                        Console.WriteLine();
                        break;

                    case 3:
                        // Sort Citizen IDs
                        if (citizenCount == 0)
                        {
                            Console.WriteLine("No Citizen IDs to sort!");
                            break;
                        }

                        // Copy only entered IDs into a temp array for sorting
                        int[] tempSort = new int[citizenCount];
                        Array.Copy(citizenIds, tempSort, citizenCount);

                        Array.Sort(tempSort);

                        // Put sorted back into main array
                        Array.Copy(tempSort, citizenIds, citizenCount);

                        Console.WriteLine("Citizen IDs sorted successfully!");
                        break;

                    case 4:
                        // Search Citizen ID
                        if (citizenCount == 0)
                        {
                            Console.WriteLine("No Citizen IDs to search!");
                            break;
                        }

                        Console.Write("Enter Citizen ID to search: ");
                        if (!int.TryParse(Console.ReadLine(), out int searchId) || searchId <= 0)
                        {
                            Console.WriteLine("Invalid Citizen ID!");
                            break;
                        }

                        int foundIndex = -1;

                        for (int i = 0; i < citizenCount; i++)
                        {
                            if (citizenIds[i] == searchId)
                            {
                                foundIndex = i;
                                break;
                            }
                        }

                        if (foundIndex != -1)
                        {
                            Console.WriteLine($"Citizen ID {searchId} found at position {foundIndex + 1}.");
                        }
                        else
                        {
                            Console.WriteLine("Citizen ID not found!");
                        }
                        break;

                    case 5:
                        // Copy Citizen IDs
                        if (citizenCount == 0)
                        {
                            Console.WriteLine("No Citizen IDs to copy!");
                            break;
                        }

                        int[] copiedIds = new int[citizenCount];
                        Array.Copy(citizenIds, copiedIds, citizenCount);

                        Console.WriteLine("Citizen IDs copied successfully!");
                        Console.WriteLine("Copied IDs:");

                        for (int i = 0; i < copiedIds.Length; i++)
                        {
                            Console.Write(copiedIds[i] + " ");
                        }
                        Console.WriteLine();
                        break;

                    case 6:
                        // Update Zone-Sector Citizen Count
                        Console.Write("Enter Zone (1-5): ");
                        if (!int.TryParse(Console.ReadLine(), out int zone) || zone < 1 || zone > 5)
                        {
                            Console.WriteLine("Invalid Zone!");
                            break;
                        }

                        Console.Write("Enter Sector (1-5): ");
                        if (!int.TryParse(Console.ReadLine(), out int sector) || sector < 1 || sector > 5)
                        {
                            Console.WriteLine("Invalid Sector!");
                            break;
                        }

                        Console.Write("Enter Citizen Count for this Zone-Sector: ");
                        if (!int.TryParse(Console.ReadLine(), out int count) || count < 0)
                        {
                            Console.WriteLine("Invalid Count!");
                            break;
                        }

                        zoneSectorCounts[zone - 1, sector - 1] = count;
                        Console.WriteLine("Zone-Sector citizen count updated successfully!");
                        break;

                    case 7:
                        // Display Zone-Sector Citizen Counts
                        Console.WriteLine("\nZone-Sector Citizen Counts (5x5):");

                        for (int z = 0; z < 5; z++)
                        {
                            Console.Write($"Zone {z + 1}: ");

                            for (int s = 0; s < 5; s++)
                            {
                                Console.Write(zoneSectorCounts[z, s] + " ");
                            }

                            Console.WriteLine();
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
            }
        }
    }
}
