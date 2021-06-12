using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    class Sort
    {
        public static void Start()
        {
            int[] array = new int[10];
            SetArray(array, 100);
            ShowArr(array);

            ShellSort(array);
            ShowArr(array);

            int max = FindSecondMax(array);
            Console.WriteLine($"Second max number = {max}");
        }

        public static int Comparison { get; private set; }
        public static int Moving { get; private set; }

        public static void SetArray(int[] arr, int max)
        {
            Random randnum = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = randnum.Next(max);
            }
        }

        public static void ShowArr<T>(T[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        static int FindSecondMax(int[] arr)
        {
            int max = arr[arr.Length - 1];
            for (int i = arr.Length - 2; i >= 0; i--)
            {
                if (max != arr[i])
                {
                    max = arr[i];
                    break;
                }
            }
            return max;
        }

        public static void ShellSort(int[] array)
        {
            Comparison = 0;
            Moving = 0;

            int n = array.Length;
            int h;
            for (h = 1; h <= n / 9; h = h * 3 + 1) ;

            while (h >= 1)
            {
                for (int i = h; i < n; i++)
                {
                    var temp = array[i];
                    int j = i;

                    Comparison++;
                    for (; j >= h && temp < array[j - h]; j -= h)
                    {
                        array[j] = array[j - h];
                        Comparison++;
                        Moving++;
                    }
                    array[j] = temp;
                    //ShowArr(array);
                }
                h = (h - 1) / 3;
            }
        }

        public static void Swap<T>(ref T a, ref T b)
        {
            T ab = a;
            a = b;
            b = ab;
        }
    }   
}
