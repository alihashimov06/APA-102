using System;
using Universitet_üçün_şəxs_idarəetmə_sistemi.NewFolder;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Student student = new Student("ali", "hashimov", 19, "alihashimov2006az@gmail.com", 2, 200, "ITT", 88.5, 3);
            Student student1 = new Student("ehmed", "hashimov", 19, "ehmed2006az@gmail.com", 2, 200, "ITT", 92, 3);
            Student student2 = new Student("huseyin", "hashimov", 19, "huseyin2006az@gmail.com", 2, 200, "ITT", 68.5, 3);
            Console.WriteLine(student.ShowStudentInfo());
            Console.WriteLine(student.CalculateScholarship());
            Console.WriteLine(student1.ShowStudentInfo());
            Console.WriteLine(student1.CalculateScholarship());
            Console.WriteLine(student2.ShowStudentInfo());
            Console.WriteLine(student2.CalculateScholarship());
            int a = student.CalculateScholarship();
            int b = student1.CalculateScholarship();
            int c = student2.CalculateScholarship();
            Console.WriteLine($"umumu teqaud {a + b + c}");

            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------");

            Teacher teacher = new Teacher("zamin", "tahirov", 47, "zamin@gmail.com", 3, "diller", "azdili", 900, 15);
            Teacher teacher1 = new Teacher("hesen", "tahirov", 47, "hesen@gmail.com", 3, "diller", "azdili", 900, 8);
            Console.WriteLine(teacher.ShowTeacherInfo());
            Console.WriteLine(teacher.CalculateSalary());
            Console.WriteLine(teacher1.ShowTeacherInfo());
            Console.WriteLine(teacher1.CalculateSalary());
            decimal ts = teacher.CalculateSalary();
            decimal ts1 = teacher1.CalculateSalary();
            Console.WriteLine($"mlmler ucun umumi teqaut {ts + ts1}");

            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------");


            Adminstrator adminstrator = new Adminstrator("qember", "qudretov", 26, "qember@gmail.com", 4, "dekan", "IT", 3);
            Console.WriteLine(adminstrator.ShowAdminInfo());
            Console.WriteLine(adminstrator.GrantAccess(student1));




        }

        
    }
}
