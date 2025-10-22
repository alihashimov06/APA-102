using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_AbstractClassPolymorphismForEach.Models
{
    internal class Car : Vehicle
    {
        public double _distance;
        public int _doorsCount;
        public int _trunkCapacity;
        public bool _isAutomatic;
        public int _maxSpeed;


        public Car(string brand, string model, int year, int doorCount, int trunkCapacity, bool isAutomatic, int maxSpeed) : base(brand, model, year)
        {
            this._doorsCount = doorCount;
            this._trunkCapacity = trunkCapacity;
            this._isAutomatic = isAutomatic;
            this._maxSpeed = maxSpeed;
            
           


        }
        public string ShowCarInfo()
        {
            return $"Brand:{_brand}, Madel:{_model}, Year:{_year}, Fuel Level:{_fuelLevel}, Doors Count:{_doorsCount}, Trunk Capacity: {_trunkCapacity}, IsAutomatic:{_isAutomatic}, Max Speed:{_maxSpeed}";
        }

        public override  double CalculateFuelCost()
        {

            return (_distance / 100) * 8 * 1.5;
        }
    }
}
