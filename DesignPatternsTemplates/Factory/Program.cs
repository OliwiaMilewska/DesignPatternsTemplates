using Factory._1_SimpleFactory;
using Factory._2_FactoryMethod.Products;
using Factory._2_FactoryMethod;
using Factory.Shared.Interface;
using Factory._3_AbstractFactory;

// Simple Factory
IFurniture chair1 = FurnitureSimpleFactory.CreateFurniture(FurnitureType.Chair, MaterialType.Wood);
chair1.Create();
Console.WriteLine($"Material: {chair1.GetMaterial()}");

// Factory Method
FurnitureFactoryMethod factory = new MetalChairFactory();
IFurniture chair2 = factory.CreateFurniture();
chair2.Create();
Console.WriteLine($"Material: {chair2.GetMaterial()}");

// Abstract Factory
IFurnitureFactory furnitureFactory = new WoodenFurnitureFactory();
IFurniture chair3 = furnitureFactory.CreateChair();
chair3.Create();
Console.WriteLine($"Material: {chair3.GetMaterial()}");

Console.ReadKey();