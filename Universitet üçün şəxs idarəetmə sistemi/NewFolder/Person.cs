using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Universitet_üçün_şəxs_idarəetmə_sistemi.NewFolder
{
    internal class Person
    {
        public string name;
        public string surname;
        public byte age = 17;
        public string email;
        public int id;

        public Person(string name, string surname, byte age, string email, int id)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.email = email;
            this.id = id;
        }

        public string GetFullName()
        {
            
            return name + surname;

        } 
        public string ShowBasicInfo()
        {
            return $"ad: {name} soyad: {surname} age: {age} email: {email} id: {id}";

            

        }




    }
}
