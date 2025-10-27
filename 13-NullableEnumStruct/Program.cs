using _13_NullableEnumStruct.Enum;
using _13_NullableEnumStruct.Models;

var order1 = new DrinkOrder(101, "Ali", DrinkType.Coffee, DrinkSize.Medium);
order1.DisplayOrder();
order1.UpdateStatus(OrderStatus.Preparing);
order1.UpdateStatus(OrderStatus.Ready);
order1.UpdateStatus(OrderStatus.Delivered);

var order2 = new DrinkOrder(102, "Leyla", DrinkType.Tea, DrinkSize.Large);
order2.DisplayOrder();
order2.UpdateStatus(OrderStatus.Ready);

var order3 = new DrinkOrder(103, "Vüqar", DrinkType.Juice, DrinkSize.Small);
order3.DisplayOrder();

Console.WriteLine("\n================ Enum Dəyerleri =================");


Console.WriteLine("DrinkType deyerleri:");
foreach (var drink in Enum.GetValues(typeof(DrinkType)))
    Console.WriteLine($"- {drink}");

Console.WriteLine("\nDrinkSize deyerleri:");
foreach (var size in Enum.GetValues(typeof(DrinkSize)))
    Console.WriteLine($"- {size}");

Console.WriteLine("\nOrderStatus deyerleri:");
foreach (var status in Enum.GetValues(typeof(OrderStatus)))
    Console.WriteLine($"- {status}");


Console.WriteLine($"\nToString nümuneleri:");
Console.WriteLine($"DrinkType.Coffee.ToString() → {DrinkType.Coffee.ToString()}");
Console.WriteLine($"DrinkSize.Large.ToString() → {DrinkSize.Large.ToString()}");


var parsedDrink = (DrinkType)Enum.Parse(typeof(DrinkType), "Tea");
var parsedSize = (DrinkSize)Enum.Parse(typeof(DrinkSize), "Medium");
Console.WriteLine($"\nParse nümuneləri:");
Console.WriteLine($"\"Tea\" → {parsedDrink}");
Console.WriteLine($"\"Medium\" → {parsedSize}");


Console.WriteLine("\n================ Statistika =================");
Console.WriteLine($"Ümumi sifariş sayı: 3");
Console.WriteLine($"1-ci sifarişin qiymeti: {order1.Price} AZN");
Console.WriteLine($"2-ci sifarişin qiymeti: {order2.Price} AZN");
Console.WriteLine($"3-cü sifarişin qiymeti: {order3.Price} AZN");

decimal total = order1.Price + order2.Price + order3.Price;
Console.WriteLine($"Ümumi mebleğ: {total} AZN");
