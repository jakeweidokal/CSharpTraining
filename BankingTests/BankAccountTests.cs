using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    
    public class BankAccountTests
    {
        BankAccount account;

        public BankAccountTests()
        {
            account = new BankAccount(new DummyBonusCalculator());
        }

        [Fact]
        public void NewAccountHasCorrectBalance()
        {
            decimal currentBalance = account.GetBalance();

            Assert.Equal(5000M, currentBalance);
        }

        [Fact]
        public void WithdrawalDecreasesBalance()
        {
            // Arrange - Given
            var openingBalance = account.GetBalance();
            var amountToWithdraw = 1M;

            // Act - When
            account.Withdraw(amountToWithdraw);

            // Assert - Then
            Assert.Equal(
                openingBalance - amountToWithdraw,
                account.GetBalance());
        }

        [Fact]
        public void DepositIncreasesBalance()
        {
            // Arrange - Given
            var openingBalance = account.GetBalance();
            var amountToDeposit = 1M;

            // Act - When
            account.Deposit(amountToDeposit);

            // Assert - Then
            Assert.Equal(
                openingBalance + amountToDeposit,
                account.GetBalance());
        }

        [Fact]
        public void OverdraftDoesNotDecreaseBalance()
        {
            var openingBalance = account.GetBalance();

            try
            {
                account.Withdraw(openingBalance + 1);
            }
            catch (Exception)
            {

                // Intentionally swallowed
            }

            Assert.Equal(openingBalance, account.GetBalance());
        }

        [Fact]
        public void OverdraftThrowsAnException()
        {
            Assert.Throws<OverdraftException>(
               () => account.Withdraw(account.GetBalance() + 1)
               );
        }
    }

    public class DummyBonusCalculator : ICalculateBonuses
    {
        public decimal GetBonusFor(IProvideBalances bankAccount, decimal amountToDeposit)
        {
            return 0;
        }
    }
}
