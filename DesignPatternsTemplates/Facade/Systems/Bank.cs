namespace Facade.Systems
{
    public class Bank
    {
        public bool HasSufficientSavings(Customer c, int amount)
        {
            Console.WriteLine("Check savings for " + c.Name);
            if (amount > 50_000)
                return true;
            return false;
        }
    }
}
