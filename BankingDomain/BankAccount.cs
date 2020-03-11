using System;

namespace BankingDomain
{
    public class BankAccount : IProvideBalances
    {
        private ICalculateBonuses BonusCalculator;

        private decimal CurrentBalance = 5000;

        public BankAccount(ICalculateBonuses bonusCalculator)
        {
            BonusCalculator = bonusCalculator;
        }

        public decimal GetBalance()
        {
            return CurrentBalance; // JFHCI -- Just ****ing hard code it
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            if(amountToWithdraw > CurrentBalance)
            {
                throw new OverdraftException();
            }
            CurrentBalance -= amountToWithdraw;
        }

        public void Deposit(decimal amountToDeposit)
        {
            // WTCYWYH
            decimal bonus = BonusCalculator.GetBonusFor(this, amountToDeposit);
            CurrentBalance += amountToDeposit + bonus;
        }
    }
}