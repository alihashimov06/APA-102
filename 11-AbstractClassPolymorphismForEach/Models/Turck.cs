//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace _11_AbstractClassPolymorphismForEach.Models
//{
//    internal class Turck : Vehicle
//    {
//        public double CargoCapacity { get; set; }
//        public int AxleCount { get; set; }
//        public double CurrentLoad { get; set; }
//        public int MaxSpeed { get; set; }
//        public double Distance { get; set; }
//        public Turck(string brand, string model, int year, string paletNumber, double fuellevel, double cargoCapacity, int axleCount, double currentLoad, int maxSpeed, double distance) : base(brand, model, year, paletNumber, fuellevel)
//        {
//            this.CargoCapacity = cargoCapacity;
//            this.AxleCount = axleCount;
//            this.CurrentLoad = currentLoad;
//            this.MaxSpeed = maxSpeed;
//            this.Distance = distance;
//        }
//        public string ShowTruckInfo()
//        {
//            return $"Brand:{Brand}, Madel:{Model}, Year:{Year}, Registration Number:{PaletNumber}, Fuel Level:{FuelLevel}, Cargo Capacity:{CargoCapacity}, Axle Count: {AxleCount}, Currrent Load:{CurrentLoad}, Max Speed:{MaxSpeed}";
//        }

//        public override double CalculateFuelCost()
//        {
//            return (Distance / 100) * (25 + CurrentLoad * 2) * 1.80;
//        }
//    }
//}
