namespace Observer.Tests
{
    public class StockTests
    {
        [Fact]
        public void Investor_Receives_Notification_When_Stock_Reaches_Target()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            var stock = new Stock("INTC", 40);
            var investor = new Investor("Alice");
            investor.AddToWatchlist("INTC", 35);

            stock.Attach(investor);

            stock.Price = 34;

            var log = output.ToString();
            Assert.Contains("BUY: INTC dropped to", log);
            Assert.Contains("BUY signal", log);
        }

        [Fact]
        public void Investor_Does_Not_Receive_Notification_After_Detach()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            var stock = new Stock("UBER", 70);
            var investor = new Investor("Bob");
            investor.AddToWatchlist("UBER", 65);

            stock.Attach(investor);
            stock.Detach(investor);

            stock.Price = 60;

            var log = output.ToString();
            Assert.DoesNotContain("BUY: UBER dropped to", log);
        }

        [Fact]
        public void Multiple_Investors_React_Independently()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            var stock = new Stock("INPST", 20);
            var alice = new Investor("Alice");
            alice.AddToWatchlist("INPST", 18);
            var bob = new Investor("Bob");
            bob.AddToWatchlist("INPST", 19);

            stock.Attach(alice);
            stock.Attach(bob);

            stock.Price = 17.5;

            var log = output.ToString();
            Assert.Contains("Alice", log);
            Assert.Contains("Bob", log);
            Assert.Contains("BUY: INPST dropped to", log);
        }

        [Fact]
        public void Investor_Ignores_Unwatched_Stock()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            var stock = new Stock("INTC", 40);
            var investor = new Investor("Charlie");

            stock.Attach(investor);

            stock.Price = 30;

            var log = output.ToString();
            Assert.DoesNotContain("Charlie", log);
        }
    }
}