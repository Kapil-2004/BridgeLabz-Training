using NUnit.Framework;
using System;

[TestFixture]
public class UnitTest
{
    [Test]
    public void Test_Deposit_ValidAmount()
    {
        IBankAccount account = new Program(1000m);

        account.Deposit(500m);

        Assert.That(account.Balance, Is.EqualTo(1500m));
    }

    [Test]
    public void Test_Deposit_NegativeAmount()
    {
        IBankAccount account = new Program(1000m);

        var ex = Assert.Throws<Exception>(() => account.Deposit(-200m));

        Assert.That(ex.Message, Is.EqualTo("Deposit amount cannot be negative"));
    }

    [Test]
    public void Test_Withdraw_ValidAmount()
    {
        IBankAccount account = new Program(1000m);

        account.Withdraw(400m);

        Assert.That(account.Balance, Is.EqualTo(600m));
    }

    [Test]
    public void Test_Withdraw_InsufficientFunds()
    {
        IBankAccount account = new Program(500m);

        var ex = Assert.Throws<Exception>(() => account.Withdraw(800m));

        Assert.That(ex.Message, Is.EqualTo("Insufficient funds."));
    }
}
