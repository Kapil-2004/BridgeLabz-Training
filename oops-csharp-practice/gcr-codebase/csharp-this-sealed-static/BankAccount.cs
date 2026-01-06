using System;

class BankAccount
{
    // static variable (shared by all accounts)
    public static string bankName = "National Bank";
    private static int totalAccounts = 0;

    // readonly variable
    public readonly int AccountNumber;

    // instance variables
    public string AccountHolderName;
    private double balance;

    // constructor using 'this'
    public BankAccount(string AccountHolderName, int AccountNumber, double balance)
    {
        this.AccountHolderName = AccountHolderName;
        this.AccountNumber = AccountNumber; // readonly can be set only here
        this.balance = balance;

        totalAccounts++;
    }

    // static method
    public static void GetTotalAccounts()
    {
        Console.WriteLine("Total Accounts Created: " + totalAccounts);
    }

    // method to display account details
    public void DisplayDetails()
    {
        Console.WriteLine("Bank Name: " + bankName);
        Console.WriteLine("Account Holder: " + AccountHolderName);
        Console.WriteLine("Account Number: " + AccountNumber);
        Console.WriteLine("Balance: " + balance);
    }
}

class Program
{
    static void Main()
    {
        BankAccount acc1 = new BankAccount("Rahul", 101, 5000);
        BankAccount acc2 = new BankAccount("Anita", 102, 8000);

        // is operator usage
        if (acc1 is BankAccount)
        {
            Console.WriteLine("\nAccount 1 Details:");
            acc1.DisplayDetails();
        }

        if (acc2 is BankAccount)
        {
            Console.WriteLine("\nAccount 2 Details:");
            acc2.DisplayDetails();
        }

        Console.WriteLine();
        BankAccount.GetTotalAccounts();
    }
}
