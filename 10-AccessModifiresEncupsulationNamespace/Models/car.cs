using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_AccessModifiresEncupsulationNamespace.Models
{
    internal class Car
    {
        private int _horse_power;

        public int HorsPower
        {


            get
            {
                if (_horse_power <100)
                {
                    Console.WriteLine("cant drive");
                }

                return _horse_power;
            }



            set
            {
                if (value > 300)
                {
                    Console.WriteLine("acsdcacac");
                    return;
                }
                _horse_power = value;  
            }
        
        
        
        }
    }
}
