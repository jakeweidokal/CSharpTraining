using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class StandardBonusCalculatorTests
    {
        [Fact]
        public void AccountsWithCreditBelowCutoffGetNoBonus()
        {
            // Given
            ICalculateBonuses bonusCalculator = new StandardBonusCalculator();
            // And we have an account with balance < 10000
            var accountStub = new Mock<IProvideBalances>();
            accountStub.Setup(a => a.GetBalance()).Returns(9999.99M);
            // When I ask it to calculate a bonus for an account < 10000
            var bonus = bonusCalculator.GetBonusFor(accountStub.Object, 100);
            // Then no bonus is given
            Assert.Equal(0, bonus);
        }

        [Fact]
        public void AccountsWithCreditAboveCutoffGetNoBonus()
        {
            // Given
            ICalculateBonuses bonusCalculator = new StandardBonusCalculator();
            // And we have an account with balance == 10000
            var accountStub = new Mock<IProvideBalances>();
            accountStub.Setup(a => a.GetBalance()).Returns(10000M);
            // When I ask it to calculate a bonus for an account >= 10000
            var bonus = bonusCalculator.GetBonusFor(accountStub.Object, 100);
            // Then a bonus is given
            Assert.Equal(10, bonus);
        }
    }
}
