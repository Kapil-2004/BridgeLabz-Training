using NUnit.Framework;
using CSharpNUnit;
using System;

namespace CSharpNUnitTests
{
    [TestFixture]
    public class BankAccountTests
    {
        private BankAccount account;

        [SetUp]
        public void SetUp()
        {
            account = new BankAccount(1000);
        }

        [Test]
        public void BankAccount_InitialBalance_CorrectBalance()
        {
            Assert.AreEqual(1000, account.GetBalance());
        }

        [Test]
        public void Deposit_ValidAmount_IncrementsBalance()
        {
            account.Deposit(500);
            Assert.AreEqual(1500, account.GetBalance());
        }

        [Test]
        public void Deposit_MultipleTransactions_CorrectBalance()
        {
            account.Deposit(100);
            account.Deposit(200);
            account.Deposit(300);
            Assert.AreEqual(1600, account.GetBalance());
        }

        [Test]
        public void Deposit_NegativeAmount_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => account.Deposit(-100));
        }

        [Test]
        public void Deposit_ZeroAmount_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => account.Deposit(0));
        }

        [Test]
        public void Withdraw_ValidAmount_DecrementsBalance()
        {
            account.Withdraw(300);
            Assert.AreEqual(700, account.GetBalance());
        }

        [Test]
        public void Withdraw_InsufficientFunds_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(2000));
        }

        [Test]
        public void Withdraw_NegativeAmount_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => account.Withdraw(-100));
        }

        [Test]
        public void Withdraw_ZeroAmount_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => account.Withdraw(0));
        }

        [Test]
        public void Withdraw_ExactBalance_SucceedsAndBalanceBecomesZero()
        {
            account.Withdraw(1000);
            Assert.AreEqual(0, account.GetBalance());
        }

        [Test]
        public void DepositAndWithdraw_MultipleTransactions_CorrectBalance()
        {
            account.Deposit(500);
            Assert.AreEqual(1500, account.GetBalance());

            account.Withdraw(300);
            Assert.AreEqual(1200, account.GetBalance());

            account.Deposit(200);
            Assert.AreEqual(1400, account.GetBalance());

            account.Withdraw(400);
            Assert.AreEqual(1000, account.GetBalance());
        }

        [Test]
        public void Constructor_NegativeInitialBalance_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new BankAccount(-500));
        }
    }
}
