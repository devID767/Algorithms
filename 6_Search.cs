using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    class Search
    {
        public static void Start()
        {
            int[] A_array = new int[10];
            Sort.SetArray(A_array, 20);
            Sort.ShellSort(A_array);
            Sort.ShowArr(A_array);

            int[] B_array = new int[10];
            Sort.SetArray(B_array, 20);
            Sort.ShellSort(B_array);
            Sort.ShowArr(B_array);

            var searchedNums_A = Variat10(A_array, B_array);
            var searchedNums_B = Variat10(B_array, A_array);

            Console.WriteLine("In A: ");
            ShowList(searchedNums_A);
            Console.WriteLine("In B: ");
            ShowList(searchedNums_B);
        }

        static void ShowList<T>(List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"{list[i]} ");
            }
            Console.WriteLine();
        }

        static List<int> Variat10(int[] arr, int[] arr2)
        {
            int searchedNum = 0;
            var searchedNums = new List<int>();
            for (int j = 0; j < arr.Length; j++)
            {
                if (j == arr.Length - 1)
                {
                    if (arr[j] != searchedNum)
                    {
                        searchedNum = arr[j];
                        if (BinarianSearch(arr2, searchedNum) == -1)
                        {
                            searchedNums.Add(searchedNum);
                        }
                    }
                }
                else if (arr[j] != arr[j + 1] && arr[j] != searchedNum)
                {
                    searchedNum = arr[j];
                    if (BinarianSearch(arr2, searchedNum) == -1)
                    {
                        searchedNums.Add(searchedNum);
                    }
                }
                else
                {
                    searchedNum = arr[j];
                };
            }
            return searchedNums;
        }

        static int BinarianSearch(int[] arr, int key)
        {
            int Comparison = 0;

            int L = 0;
            int R = arr.Length - 1;
            int m = 0;
            while (L <= R)
            {
                m = (L + R) / 2;

                Comparison++;
                if (key == arr[m])
                {
                    Console.WriteLine($"Binarian comparison = {Comparison}");
                    return m;
                }

                else if (key > arr[m])
                    L = m + 1;
                else
                    R = m - 1;
            }
            return -1;
        }

        static int LinealSearchWithBoard(int[] arr, int key)
        {
            var temp = arr[arr.Length - 1];
            arr[arr.Length - 1] = key;

            int i = 0;
            int Comparison = 0;
            while (true)
            {
                Comparison++;
                if (arr[i] == key) break;
                i++;
            }

            Console.WriteLine($"Lineal Comparison = {Comparison}");
            arr[arr.Length - 1] = temp;
            return i;
        }
    }
}
