using System;
using System.Collections.Generic;

class BankingSystem
{
    static void Main()
    {
        // Dictionary to store account balances (AccountNo -> Balance)
        Dictionary<int, double> accounts = new Dictionary<int, double>();

        // Add some accounts
        accounts[101] = 5000;
        accounts[102] = 12000;
        accounts[103] = 3000;
        accounts[104] = 8000;

        // Display all accounts
        Console.WriteLine("All Accounts:");
        foreach (var pair in accounts)
        {
            Console.WriteLine("Account " + pair.Key + " : Balance = " + pair.Value);
        }

        // Queue to process withdrawal requests
        Queue<WithdrawalRequest> withdrawalQueue = new Queue<WithdrawalRequest>();

        // Add withdrawal requests (AccountNo, Amount)
        withdrawalQueue.Enqueue(new WithdrawalRequest(101, 2000));
        withdrawalQueue.Enqueue(new WithdrawalRequest(103, 1000));
        withdrawalQueue.Enqueue(new WithdrawalRequest(102, 5000));
        withdrawalQueue.Enqueue(new WithdrawalRequest(104, 9000)); // insufficient balance case

        Console.WriteLine("\nProcessing Withdrawal Requests:");

        while (withdrawalQueue.Count > 0)
        {
            WithdrawalRequest request = withdrawalQueue.Dequeue();
            ProcessWithdrawal(accounts, request);
        }

        // Sort customers by balance using SortedDictionary
        SortedDictionary<double, List<int>> sortedByBalance = new SortedDictionary<double, List<int>>();

        foreach (var pair in accounts)
        {
            if (!sortedByBalance.ContainsKey(pair.Value))
                sortedByBalance[pair.Value] = new List<int>();

            sortedByBalance[pair.Value].Add(pair.Key);
        }

        Console.WriteLine("\nCustomers Sorted by Balance (Ascending):");
        foreach (var pair in sortedByBalance)
        {
            foreach (int accNo in pair.Value)
            {
                Console.WriteLine("Account " + accNo + " : Balance = " + pair.Key);
            }
        }
    }

    static void ProcessWithdrawal(Dictionary<int, double> accounts, WithdrawalRequest request)
    {
        if (!accounts.ContainsKey(request.AccountNo))
        {
            Console.WriteLine("Account " + request.AccountNo + " does not exist.");
            return;
        }

        double balance = accounts[request.AccountNo];

        if (balance >= request.Amount)
        {
            accounts[request.AccountNo] = balance - request.Amount;
            Console.WriteLine("Withdrawal successful: Account " + request.AccountNo +
                              ", Amount = " + request.Amount +
                              ", Remaining Balance = " + accounts[request.AccountNo]);
        }
        else
        {
            Console.WriteLine("Insufficient balance for Account " + request.AccountNo +
                              ". Requested = " + request.Amount +
                              ", Available = " + balance);
        }
    }
}

// Class for withdrawal requests
class WithdrawalRequest
{
    public int AccountNo { get; set; }
    public double Amount { get; set; }

    public WithdrawalRequest(int accountNo, double amount)
    {
        AccountNo = accountNo;
        Amount = amount;
    }
}
