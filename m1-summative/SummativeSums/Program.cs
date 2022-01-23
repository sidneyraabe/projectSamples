using System;

namespace SummativeSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = new[] { 1, 90, -33, -55, 67, -16, 28, -55, 15 };
            int[] array2 = new[] { 999, -60, -77, 14, 160, 301 };
            int[] array3 = new[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160, 170, 180, 190, 200, -99 };

            Console.WriteLine("#1 Array Sum: " + AddArray(array1));
            Console.WriteLine("#2 Array Sum: " + AddArray(array2));
            Console.WriteLine("#3 Array Sum: " + AddArray(array3));
        }
        static int AddArray(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
                sum += array[i];
            return sum;
        }
    }
}
