using Facade.Systems;

namespace Facade.Tests
{
    public class MortgageTests
    {
        [Fact]
        public void IsEligible_AllConditionsMet_ReturnsTrue()
        {
            var customer = new Customer("John", true);

            var bank = new Bank();
            var loan = new Loan();
            var credit = new Credit();
            var mortgage = new Mortgage();

            var result = mortgage.IsEligible(customer, 60000, 20000);

            Assert.True(result);
        }

        [Fact]
        public void IsEligible_InsufficientSavings_ReturnsFalse()
        {
            var customer = new Customer("Alice", true);

            var bank = new Bank();
            var loan = new Loan();
            var credit = new Credit();
            var mortgage = new Mortgage();

            var result = mortgage.IsEligible(customer, 40000, 20000);

            Assert.False(result);
        }


        [Fact]
        public void IsEligible_HasBadLoans_ReturnsFalse()
        {
            var customer = new Customer("Bob", true);

            var bank = new Bank();
            var loan = new Loan();
            var credit = new Credit();
            var mortgage = new Mortgage();

            var result = mortgage.IsEligible(customer, 60000, 40000);

            Assert.False(result);
        }

    }
}