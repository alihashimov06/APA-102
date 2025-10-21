using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Universitet_üçün_şəxs_idarəetmə_sistemi.NewFolder
{
    internal class Student : Person
    {
        public int studentNumber;
        public string faculty;
        public double GPA;
        public int year;


        public Student(string name, string surname, byte age, string email, int id , int sn, string faculty, double GPA, int year) : base(name,surname, age, email, id)
        {
            this.studentNumber = sn;
            this.faculty = faculty;
            this.GPA = GPA;
            this.year = year;


        }

        public string ShowStudentInfo()
        {


            return $"ad: {name} soyad: {surname} age: {age} email: {email} id: {id} student number: {studentNumber} facilty: {faculty} GPA: {GPA} kours: {year} ";

        }

        public int CalculateScholarship()
        {
            int teqaud = 0;
            
            if (GPA >= 90)
            {
                teqaud = 500;
                //return "500 manat teqaud"; 

            }
            else if(GPA >= 80)
            {
                teqaud = 350;
                // return "350 manat teqaud"; 

            }
            else if (GPA >= 70)
            {
                teqaud = 200;
                // return "200 manat teqaud"; 

            }
            else
            {
                teqaud = 0;
                //return "o manat teqaud "; 

            }
            return teqaud;
        }
    }
}
