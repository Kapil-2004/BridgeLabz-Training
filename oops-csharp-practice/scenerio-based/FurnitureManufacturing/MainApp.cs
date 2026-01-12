using System;

class MainApp
{
    public void Run()
    {
        Console.Write("Enter rod length (ft): ");
        int length = int.Parse(Console.ReadLine());

        RodDetails rod = new RodDetails(length);
        int[] price = new int[length + 1];

        Console.WriteLine("\nEnter price for each length:");
        for (int i = 1; i <= length; i++)
        {
            Console.Write($"Price for {i} ft: ");
            price[i] = int.Parse(Console.ReadLine());
        }

        ICuttingStrategy utility = new CuttingUtility();
        bool exit = false;

        while (!exit)
        {
            Menu.ShowMenu();
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Max Revenue: ₹" +
                        utility.GetMaxRevenue(rod.RodLength, price));
                    break;

                case 2:
                    Console.Write("Enter max allowed waste (ft): ");
                    int waste = int.Parse(Console.ReadLine());
                    Console.WriteLine("Revenue with waste limit: ₹" +
                        utility.GetRevenueWithWaste(rod.RodLength, price, waste));
                    break;

                case 3:
                    utility.GetBestRevenueWithMinWaste(rod.RodLength, price);
                    break;

                case 4:
                    exit = true;
                    Console.WriteLine("Exiting system...");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
