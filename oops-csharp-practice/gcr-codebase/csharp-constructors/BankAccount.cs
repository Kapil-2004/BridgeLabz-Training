using System;

// Base class
class BankAccount
{
    public string accountNumber;      // Public
    protected string accountHolder;   // Protected
    private double balance;            // Private

    // Constructor
    public BankAccount(string accNo, string holder, double balance)
    {
        this.accountNumber = accNo;
        this.accountHolder = holder;
        this.balance = balance;
    }

    // Public method to get balance
    public double GetBalance()
    {
        return balance;
    }

    // Public method to deposit money
    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine("Amount Deposited Successfully.");
        }
    }

    // Public method to withdraw money
    public void Withdraw(double amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
            Console.WriteLine("Amount Withdrawn Successfully.");
        }
        else
        {
            Console.WriteLine("Insufficient Balance or Invalid Amount.");
        }
    }
}

// Derived class
class SavingsAccount : BankAccount
{
    public SavingsAccount(string accNo, string holder, double balance)
        : base(accNo, holder, balance)
    {
    }

    // Access public and protected members
    public void DisplayAccountDetails()
    {
        Console.WriteLine("Account Number : " + accountNumber); // Public
        Console.WriteLine("Account Holder : " + accountHolder); // Protected
        Console.WriteLine("Balance        : " + GetBalance());  // Private via method
        Console.WriteLine("----------------------------------");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter Account Number: ");
        string accNo = Console.ReadLine();

        Console.Write("Enter Account Holder Name: ");
        string holder = Console.ReadLine();

        Console.Write("Enter Initial Balance: ");
        double balance = Convert.ToDouble(Console.ReadLine());

        SavingsAccount account = new SavingsAccount(accNo, holder, balance);

        account.DisplayAccountDetails();

        Console.Write("\nEnter amount to deposit: ");
        double deposit = Convert.ToDouble(Console.ReadLine());
        account.Deposit(deposit);

        Console.Write("Enter amount to withdraw: ");
        double withdraw = Convert.ToDouble(Console.ReadLine());
        account.Withdraw(withdraw);

        Console.WriteLine("\nUpdated Account Details:");
        account.DisplayAccountDetails();
    }
}
