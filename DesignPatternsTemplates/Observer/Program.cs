using Observer;

var intel = new Stock("INTC", 35.00);
var uber = new Stock("UBER", 68.00);
var inpost = new Stock("INPST", 17.50);

var alice = new Investor("Alice");
alice.AddToWatchlist("INTC", targetPrice: 33.00);
alice.AddToWatchlist("UBER", targetPrice: 65.00);

var bob = new Investor("Bob");
bob.AddToWatchlist("INPST", targetPrice: 16.00);
bob.AddToWatchlist("INTC", targetPrice: 34.00);

intel.Attach(alice);
intel.Attach(bob);
uber.Attach(alice);
inpost.Attach(bob);

intel.Price = 34.50;
intel.Price = 32.90;   // Triggers alerts
uber.Price = 64.00;    // Triggers alert
inpost.Price = 15.80;  // Triggers alert

Console.ReadKey();