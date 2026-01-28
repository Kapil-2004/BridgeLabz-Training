using System;

namespace CSharpNUnit
{
    public class BankAccount
    {
        private double balance;

        public BankAccount(double initialBalance)
        {
            if (initialBalance < 0)
                throw new ArgumentException("Initial balance cannot be negative");

            balance = initialBalance;
        }

        public void Deposit(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive");

            balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive");

            if (amount > balance)
                throw new InvalidOperationException("Insufficient funds");

            balance -= amount;
        }

        public double GetBalance()
        {
            return balance;
        }
    }
}
