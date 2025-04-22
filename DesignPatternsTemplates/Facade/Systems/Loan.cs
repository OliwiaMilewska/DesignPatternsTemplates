namespace Facade.Systems
{
    public class Loan
    {
        public bool HasNoBadLoans(Customer c, int debt)
        {
            Console.WriteLine("Check loans for " + c.Name);
            if (debt > 30_000)
                return false;
            return true;
        }
    }
}
