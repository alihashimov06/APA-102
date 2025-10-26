using _12_InterfaceAbstraction.moduls;

namespace _12_InterfaceAbstraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                Calculation calc = new();

                Console.Write("Birinci ededi daxil et: ");
                double num1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Emeliyyatı daxil et (+, -, *, /): ");
                char op = Convert.ToChar(Console.ReadLine());

                Console.Write("İkinci ededi daxil et: ");
                double num2 = Convert.ToDouble(Console.ReadLine());
                                    
                Console.WriteLine($"Netice: {calc.Calculate(num1, num2, op)}");
            }
        }
    }
}
