using System;

class InvoiceGenerator
{
    // Method to split invoice string into tasks
    public static string[] ParseInvoice(string input)
    {
        // Split tasks using comma
        string[] tasks = input.Split(',');
        return tasks;
    }

    // Method to calculate total amount
    public static int GetTotalAmount(string[] tasks)
    {
        int total = 0;

        foreach (string task in tasks)
        {
            // Example task: "Logo Design - 3000 INR"
            string[] parts = task.Split('-');

            if (parts.Length == 2)
            {
                // Extract amount part
                string amountPart = parts[1].Replace("INR", "").Trim();
                int amount = Convert.ToInt32(amountPart);
                total += amount;
            }
        }
        return total;
    }
}

class Program
{
    static void Main()
    {
        string input = "Logo Design - 3000 INR, Web Page - 4500 INR";

        // Parse invoice
        string[] tasks = InvoiceUtility.ParseInvoice(input);

        Console.WriteLine("Invoice Details:");
        foreach (string task in tasks)
        {
            Console.WriteLine(task.Trim());
        }

        // Calculate total
        int totalAmount = InvoiceUtility.GetTotalAmount(tasks);

        Console.WriteLine("\nTotal Invoice Amount: " + totalAmount + " INR");
    }
}
