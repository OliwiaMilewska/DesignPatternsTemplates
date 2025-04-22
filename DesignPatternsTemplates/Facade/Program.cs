using Facade;

Mortgage mortgage = new Mortgage();

Customer customer = new Customer("Jane McQueen", true);
bool eligible = mortgage.IsEligible(customer, 65000, 20000);

Console.WriteLine($"{customer.Name} has been {(eligible ? "Approved" : "Rejected")}");

Console.ReadKey();