using _10_AccessModifiresEncupsulationNamespace.Models;

namespace _10_AccessModifiresEncupsulationNamespace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Student student = new Student("Ali");

            //student.name = "dsncsodjn" // yaza bilmirik cunki biz artiq person clasimizda privite verdiyimiz ucun student clasi onu gore bilmir
            // istifade etmek ucun reflekshindan istifade etmeliyik
            //student.GetInfo();
           
            Car car = new Car();
            car.HorsPower = 90;
            Console.WriteLine(car.HorsPower);

        }
        
    }
}
