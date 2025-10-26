using _12_InterfaceAbstraction.Iterface;

namespace _12_InterfaceAbstraction.moduls
{
    internal class Calculation : ICalculation
    {
        public double Calculate(double a, double b, char operation)
        {

            switch (operation)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    if (b == 0)
                    {
                        Console.WriteLine("0-a bölmek olmaz!");
                        return double.NaN;
                    }
                    return a / b;
                default:
                    Console.WriteLine("Yanlış emeliyyat simvolu daxil etdiniz!");
                    return double.NaN;
            }

        }

    }
}
