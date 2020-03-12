using System;

namespace BankingDomain
{
    public class BankAccount : IProvideBalances
    {
        private ICalculateBonuses BonusCalculator;
        private INotifyTheFeds FedNotifier;

        private decimal CurrentBalance = 5000;

        public BankAccount(ICalculateBonuses bonusCalculator, INotifyTheFeds fedNotifier)
        {
            BonusCalculator = bonusCalculator;
            FedNotifier = fedNotifier;
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
            FedNotifier.NotifyOfWithdrawal(this, amountToWithdraw);
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