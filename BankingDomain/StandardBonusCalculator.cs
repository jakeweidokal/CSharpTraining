namespace BankingDomain
{
    public class StandardBonusCalculator : ICalculateBonuses
    {
        public decimal GetBonusFor(IProvideBalances bankAccount, decimal amountToDeposit)
        {
            return bankAccount.GetBalance() >= 10000 ? amountToDeposit * 0.1M : 0;
        }
    }
}