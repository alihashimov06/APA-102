using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _13_NullableEnumStruct.Enum;

namespace _13_NullableEnumStruct.Models
{
    internal class DrinkOrder
    {
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public DrinkType Drink { get; set; }
        public DrinkSize Size { get; set; }
        public OrderStatus Status { get; set; }
        public decimal Price { get; set; }
        public DrinkOrder(int orderNumber, string customerName, DrinkType drink, DrinkSize size)
        {
            OrderNumber = orderNumber;
            CustomerName = customerName;
            Drink = drink;
            Size = size;
            Status = OrderStatus.New;
            Price = CalculatePrice();
        }
        private decimal CalculatePrice()
        {
            switch (Drink)
            {
                case DrinkType.Coffee:
                    if (Size == DrinkSize.Small) return 3m;
                    if (Size == DrinkSize.Medium) return 4m;
                    return 5m;

                case DrinkType.Tea:
                    if (Size == DrinkSize.Small) return 2m;
                    if (Size == DrinkSize.Medium) return 3m;
                    return 4m;

                case DrinkType.Juice:
                    if (Size == DrinkSize.Small) return 4m;
                    if (Size == DrinkSize.Medium) return 5m;
                    return 6m;

                case DrinkType.Water:
                    if (Size == DrinkSize.Small) return 1m;
                    if (Size == DrinkSize.Medium) return 1.5m;
                    return 2m;

                default:
                    return 0m;
            }
        }
        public void UpdateStatus(OrderStatus newStatus)
        {
            Status = newStatus;
            Console.WriteLine($"Sifariş #{OrderNumber} statusu: {newStatus}");
        }
        public void DisplayOrder()
        {
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($"Sifariş nömresi: {OrderNumber}");
            Console.WriteLine($"Müşteri: {CustomerName}");
            Console.WriteLine($"İçki: {Drink}");
            Console.WriteLine($"Ölçü: {Size}");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine($"Qiymet: {Price} AZN");
            Console.WriteLine("---------------------------------------------------");
        }
    }
}
