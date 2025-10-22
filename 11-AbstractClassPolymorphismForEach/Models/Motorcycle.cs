//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace _11_AbstractClassPolymorphismForEach.Models
//{
//    internal class Motorcycle : Vehicle
//    {
       
//        public int EngineCapacity { get; set; }

//        public bool HasSidecar { get; set; }

//        public int MaxSpeed { get; set; }

//        public string Type { get; set; }
//        public double Distance { get; set; }
//        public Motorcycle(string brand, string model, int year, string paletNumber, double fuellevel, int engineCapacity, bool hasSidecer, int maxspeed, string Type, double distance) : base(brand, model, year, paletNumber, fuellevel)
//        {
//            this.EngineCapacity = engineCapacity;
//            this.HasSidecar = hasSidecer;
//            this.MaxSpeed = maxspeed;
//            this.Type = Type;
//            this.Distance = distance;
//        }
//        public string ShowMotorcycleInfo()
//        {
//            return $"Brand:{Brand}, Madel:{Model}, Year:{Year}, Registration Number:{PaletNumber}, Fuel Level:{FuelLevel}, Engine Capacity:{EngineCapacity}, Has Sidecar{HasSidecar}, Max Speeed:{MaxSpeed}, Type:{Type}";
//        }
//        public override double CalculateFuelCost()
//        {
//            return (Distance / 100) * 4 * 1.50;
//        }
//    }
//}
