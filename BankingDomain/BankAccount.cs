using System;

namespace BankingDomain
{
    public class BankAccount
    {
        private decimal CurrentBalance = 5000;
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

        public virtual void Deposit(decimal amountToDeposit)
        {
            CurrentBalance += amountToDeposit;
        }
    }
}