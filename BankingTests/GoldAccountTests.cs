using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class GoldAccountTests
    {
        BankAccount account;
        public GoldAccountTests()
        {
            account = new BankAccount();
        }
        [Theory]
        [InlineData(100, 10)]
        [InlineData(1000, 100)]
        public void DepositsGetTheBonus(decimal amount, decimal bonus)
        {
            account.TypeOfAccount = AccountType.Gold;
            var initialBalance = account.GetBalance();
            
            account.Deposit(amount);

            Assert.Equal(
                initialBalance + amount + bonus,
                account.GetBalance());
        }
    }
}
