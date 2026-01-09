// ATM Cash Distribution Program
// Purpose: Dispense cash using the least number of currency notes
// Cases:
// 1) All denominations available → ₹880
// 2) ₹500 note unavailable → revised distribution
// 3) Show alternate message when exact amount cannot be given

using System;

class CashMachine
{
    public static void DistributeCash(int totalAmount, int[] denominations)
    {
        int balance = totalAmount;
        bool isAnyNoteUsed = false;

        for (int index = 0; index < denominations.Length; index++)
        {
            int noteCount = balance / denominations[index];

            if (noteCount > 0)
            {
                balance -= denominations[index] * noteCount;
                isAnyNoteUsed = true;
                Console.WriteLine($"{denominations[index]} x {noteCount}");
            }
        }

        if (balance != 0)
        {
            Console.WriteLine("Requested amount cannot be fully processed.");
            Console.WriteLine($"Unpaid balance: ₹{balance}");
            Console.WriteLine("Alternative option: Choose another amount.\n");
        }
        else if (isAnyNoteUsed)
        {
            Console.WriteLine("\nCash successfully dispensed.\n");
        }
    }

    static void Main()
    {
        int[] caseOne = { 500, 200, 100, 50, 20, 10, 5, 2, 1 };
        int[] caseTwo = { 200, 100, 50, 20, 10, 5, 2, 1 };
        int[] caseThree = { 10, 5 };

        Console.WriteLine("\nScenario 1: ₹880 with all denominations available:");
        DistributeCash(880, caseOne);

        Console.WriteLine("\nScenario 2: ₹880 without ₹500 denomination:");
        DistributeCash(880, caseTwo);

        Console.WriteLine("\nScenario 3: No exact change available:\n");
        DistributeCash(2, caseThree);
    }
}
