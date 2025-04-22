using Facade.Systems;

namespace Facade
{
    public class Mortgage
    {
        private Bank _bank = new Bank();
        private Loan _loan = new Loan();
        private Credit _credit = new Credit();

        public bool IsEligible(Customer customer, int savings, int debt)
        {
            if (!_bank.HasSufficientSavings(customer, savings) ||
                !_loan.HasNoBadLoans(customer, debt) ||
                !_credit.HasGoodCredit(customer))
                return false;

            return true;
        }
    }
}
