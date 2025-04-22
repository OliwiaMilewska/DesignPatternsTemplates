namespace Facade.Systems
{
    public class Credit
    {
        public bool HasGoodCredit(Customer c)
        {
            Console.WriteLine("Check credit score for " + c.Name);
            return c.HasGoodCredit;
        }
    }
}
