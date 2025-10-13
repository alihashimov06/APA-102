using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Transactions;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1 ci misal
            //Emell(5, 10);





            //// 3 cu misal  variyant 1
            //int[] a = { 14, 20, 35, 40, 57, 60, 100 };

            //Console.WriteLine(Toplama(a));





            //// 3 cu misal  variyant 2
            //Console.WriteLine("arr ededlerin sayini daxil et:");
            //int m = Convert.ToInt32(Console.ReadLine());


            //int[] arr = new int[m];
            //for (int i = 0; i < m; i++)
            //{
            //    arr[i] = Convert.ToInt32(Console.ReadLine());

                
            //}
            //Console.WriteLine(Toplama(arr));

            // 2 ci misal
            Console.WriteLine("ededlerin sayini daxil et:");
            int n = Convert.ToInt32(Console.ReadLine());
           
            ChekNum(n);

            Console.WriteLine("cumleni daxil et:");
            string cumle = Console.ReadLine();

            Console.WriteLine("simvolu daxil et:");
            char sim =Convert.ToChar (Console.ReadLine());

            int say1 = SimSay(cumle,sim);
            Console.WriteLine("{0} simvollarinin sayi {1}",sim,say1);
            

        }

        #region 1.Hər biri 2 parametr qəbul edib və riyazi əməlləri yerinə yetiren method yazin.
        public static void Emell(double num1, double num2)
        {
            Console.WriteLine(num1 + num2);
            Console.WriteLine(num2 * num1);
            Console.WriteLine(num1 - num2);
            if (num1 != 0)
            {
                Console.WriteLine(num1 / num2);
            }
            else
            {
                Console.WriteLine("0 a bolme mumkun deyil");
            }
        }
        #endregion

        #region 3.Verilmis arreyde elementlerin həm 4-ə, həm də 5-ə bölününen elementlerin cemini tapin.[14, 20, 35, 40, 57, 60, 100]
        public static int Toplama(params int[] x)
        {
            int s = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] % 20 == 0)
                {
                    s = s + x[i];

                }
            }

            return s;
        }
        #endregion


        #region 2.tek cut olmasinin yoxlanmasi
        public static int ChekNum(int x)
        {
            for (int i = 0; i < x; i++)
            {
                int k = Convert.ToInt32(Console.ReadLine());

                if (k % 2 == 0)
                {
                    Console.WriteLine("{0} cuttur", k);
                }
                else
                {
                    Console.WriteLine("{0} tekdir", k);
                }

            }


            return 0;
        }
        #endregion

        #region 4.Daxil edilmiş cümlədə daxil edilmis simvoldan nece eded olduğunu tapan Proqramın alqoritmini yazin.(Cumle serbestdir).

        public static int SimSay(string s, char c)
        {
            int say = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == c)
                {
                    say += 1;
                }
            }

            return say;
        }
    } 
    #endregion

}

