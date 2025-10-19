using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universitet_üçün_şəxs_idarəetmə_sistemi.NewFolder
{
    internal class Adminstrator : Person
    {
        public string position;
        public string department;
        public int accesLevel;


        public Adminstrator(string name, string surname, byte age, string email, int id, string position, string department, int al) : base(name, surname, age, email, id)
        {
            this.position = position;
            this.department = department;
            this.accesLevel = al;
        }
        public string ShowAdminInfo()
        {

            return $"ad: {name} soyad: {surname} age: {age} email: {email} id: {id} departmant: {department} position: {position} access level: {accesLevel} ";

        }
        public string GrantAccess(Student student)
        {
            return $"{student.GetFullName} telebeye sisteme giris icazesi verilir";

        }


    }
}
