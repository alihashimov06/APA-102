using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_AccessModifiresEncupsulationNamespace.Models
{
    internal class Person
    {
        private string name;
        public string surname;
        public Person(string name)
        {
            this.name = name;
        }
        public void GetInfo()
        {
            Console.WriteLine(name);
        }

    }



}
