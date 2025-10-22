using System.Reflection;
using _11_AbstractClassPolymorphismForEach.Models;

Car car = new Car("mercedes", "E200", 2023, 4, 500, true, 220);
car._distance = 500;
Car car1 = new Car("bmw", "320i", 2022, 4, 480, true, 235);
car1._distance = 500;
Car car2 = new Car("tayota", "camry", 2021, 4, 524, true, 210);
car2._distance = 500;
car.ShowCarInfo();