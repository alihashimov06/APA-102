using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace _07_HeapStackRefOutArrayResize
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3 };
            int[] nums2 = { 4, 5 };

            CostumArrSize(ref nums, ref nums2);


        }

        public static void CostumArrSize(ref int[] x, ref int[] y)
        {
            int[] newArr = new int[x.Length + y.Length];
            for (int i = 0; i < x.Length; i++)
            {
                newArr[i] = x[i];
            }
            for (int i = 0; i < y.Length; i++)
            {
                newArr[x.Length + i] = y[i];
            }
            for (int i = 0; i < newArr.Length; i++)
            {
                Console.WriteLine(newArr[i]);
            }


        }
    }
}

// buda return formmadadi sadece siz voidle istemisdiniz deye onu yazdim
//int[] arr1 = { 1, 2, 3 };
//int[] arr2 = { 5, 6 };

//int[] newArr = CustomArrResize(arr1, arr2);

//for (int i = 0; i < newArr.Length; i++)
//{
//    Console.Write(newArr[i] + " ");
//}
//        }
//        static int[] CustomArrResize(int[] x, int[] y)
//{
//    int[] newArr = new int[x.Length + y.Length];


//    for (int i = 0; i < x.Length; i++)
//    {
//        newArr[i] = x[i];
//    }
//    for (int i = 0; i < y.Length; i++)
//    {
//        newArr[x.Length + i] = y[i];
//    }

//    return newArr;
