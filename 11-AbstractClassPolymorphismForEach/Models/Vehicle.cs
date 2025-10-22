using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_AbstractClassPolymorphismForEach.Models
{
    internal abstract class Vehicle
    {
        public string _brand;
        public string _model;
        public int _year;
        
        public double _fuelLevel = 100;

        public Vehicle(string brand, string model, int year)
        {
            this._brand = brand;
            this._model = model;
            this._year = year;
           
            
            
        }
        public string GetVehicleInfo()
        {
            return $"Brand:{_brand}, Madel:{_model}, Year:{_year}, Fuel Level:{_fuelLevel}";
        }
        public void ShowBasicInfo()
        {
            Console.WriteLine($"Brand:{_brand}, Madel:{_model}, Year:{_year}, Fuel Level:{_fuelLevel}");
        }
        public abstract double CalculateFuelCost();
        

    }
}
