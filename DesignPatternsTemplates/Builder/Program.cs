using Builder;
using Builder.Builders;

// Create a HouseBuilder instance
var houseBuilder = new HouseBuilder();
// Create a Director and assign the HouseBuilder
var director = new Director(houseBuilder);

Console.WriteLine("House product:");
// Director constructs a home using the HouseBuilder
director.BuildHome();
Console.WriteLine(houseBuilder.GetProduct());

Console.WriteLine("Apartment product:");
// Create an ApartmentBuilder instance
var aptBuilder = new ApartmentBuilder();
// Change the builder in the Director to ApartmentBuilder
director.ChangeBuilder(aptBuilder);
// Director constructs a home using the ApartmentBuilder
director.BuildHome();
Console.WriteLine(aptBuilder.GetProduct());

Console.WriteLine("Custom Apartment product:");
// Reset the ApartmentBuilder to start a new product
aptBuilder.Reset();
// Manually construct parts of the apartment
aptBuilder.BuildPartA();
aptBuilder.BuildPartB();
Console.Write(aptBuilder.GetProduct());

Console.ReadKey();