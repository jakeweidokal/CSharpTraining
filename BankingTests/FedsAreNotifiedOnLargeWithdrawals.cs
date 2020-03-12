using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class FedsAreNotifiedOnLargeWithdrawals
    {
        [Fact]
        public void FedNotified()
        {
            var mockedFed = new Mock<INotifyTheFeds>();

            var account = new BankAccount(
                null,
                mockedFed.Object
                );

            account.Withdraw(5.23M);

            mockedFed.Verify(v => v.NotifyOfWithdrawal(
                account,
                5.23M));
        }
    }
}
