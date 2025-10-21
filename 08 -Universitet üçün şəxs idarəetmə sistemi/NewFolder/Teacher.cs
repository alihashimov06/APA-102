using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universitet_üçün_şəxs_idarəetmə_sistemi.NewFolder
{
    internal class Teacher : Person
    {
        public string departman;
        public string mainSubject;
        public decimal baseSalary;
        public int exprienceYear;


        public Teacher(string name, string surname, byte age, string email, int id, string departman, string ms, decimal bs, int ey) : base(name,surname, age, email, id)
        {
            this.departman = departman;
            this.mainSubject = ms;
            this.baseSalary = bs;
            this.exprienceYear= ey;


        }
        public string ShowTeacherInfo()
        {

            return $"ad: {name} soyad: {surname} age: {age} email: {email} id: {id} departmant: {departman} main subject: {mainSubject} base salary: {baseSalary} exprience year: {exprienceYear} ";

        }
        public decimal CalculateSalary()
        {


            return baseSalary + (exprienceYear * 50);

        }

    }
}
