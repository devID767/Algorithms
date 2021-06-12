using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_1
{
    public static class CommonFunctionInterpolation
    {
        static float Function1_1(float x, float y) => Convert.ToSingle(Math.Sin(x + 2) - y - 1.5);
        static float Function1_2(float x, float y) => Convert.ToSingle(x + Math.Cos(y - 2) - 0.5);

        static float Function2_1(float x1, float x2, float x3, float[,] arr) => arr[0, 0] * x1 + arr[0, 1] * x2 + arr[0, 2] * x3 - arr[0, 3];
        static float Function2_2(float x1, float x2, float x3, float[,] arr) => arr[1, 0] * x1 + arr[1, 1] * x2 + arr[1, 2] * x3 - arr[1, 3];
        static float Function2_3(float x1, float x2, float x3, float[,] arr) => arr[2, 0] * x1 + arr[2, 1] * x2 + arr[2, 2] * x3 - arr[2, 3];


        public static void Proverka(float[] vector)
        {
            float[] result_vector = new float[vector.Length];

            result_vector[0] = Function1_1(vector[0], vector[1]);
            result_vector[1] = Function1_2(vector[0], vector[1]);

            Console.Write($"r = (");
            for (int i = 0; i < result_vector.Length; i++)
            {
                if (i == result_vector.Length - 1)
                {
                    Console.WriteLine($"{result_vector[i]})");
                }
                else
                {
                    Console.Write($"{result_vector[i]}; ");
                }
            }
        }
        public static void Proverka(float[] vector, float[,] arr)
        {
            float[] result_vector = new float[vector.Length];

            result_vector[0] = Function2_1(vector[0], vector[1], vector[2], arr);
            result_vector[1] = Function2_2(vector[0], vector[1], vector[2], arr);
            result_vector[2] = Function2_3(vector[0], vector[1], vector[2], arr);

            Console.WriteLine($"{arr[0, 0]} * {vector[0]} + {arr[0, 1]} * {vector[1]} + {arr[0, 2]} * {vector[2]} - {arr[0, 3]}");

            Console.Write($"r = (");
            for (int i = 0; i < result_vector.Length; i++)
            {
                if (i == result_vector.Length - 1)
                {
                    Console.WriteLine($"{result_vector[i]})");
                }
                else
                {
                    Console.Write($"{result_vector[i]}; ");
                }
            }
        }

        public static float[] VectorMinus(float[] vector1, float[] vector2)
        {
            float[] result_vector = new float[vector1.Length];
            for (int i = 0; i < vector1.Length; i++)
            {
                result_vector[i] = vector1[i] - vector2[i];
            }
            return result_vector;
        }

        public static float Norma(float[] vector)
        {
            float result = vector[0];
            foreach (var item in vector)
            {
                if (Math.Abs(item) > result)
                    result = Math.Abs(item);
            }
            return result;
        }
        private static float GY(float x)
        {
            return Convert.ToSingle(Math.Sin(x + 2) - 1.5f);
        }
        private static float GX(float y)
        {
            return Convert.ToSingle(0.5f - Math.Cos(y - 2));
        }

        public static void Start()
        {
            //Iteration iteration = new Iteration(GX, GY);

            //var result = iteration.SimpleIteration(1, -1.5f);
            //Console.WriteLine();
            //Console.WriteLine($"Result: x = {result[0]}\t y = {result[1]}");

            //var result2 = iteration.ZeydelIteration(1, -1.5f);
            //Console.WriteLine();
            //Console.WriteLine($"Result: x = {result2[0]}\t y = {result2[1]}");

            //Proverka(result);
            //Proverka(result2);

            float[,] array = new float[3, 4] {
                {  5.6f,  2.7f, -1.7f,  1.9f },
                { -1.4f, -5.0f, -1.3f, -3.1f  },
                {   0.8f,  1.3f,  3.7f,  1.2f }
            };

            Iteration_SLAR slar = new Iteration_SLAR(array);

            var result = slar.SimpleIteration_SLAR(0);
            Console.WriteLine();
            Console.WriteLine($"Result: x1 = {result[0]}\t x2 = {result[1]}\t x3 = {result[2]}");

            var result2 = slar.ZeydalIteration_SLAR(0);
            Console.WriteLine();
            Console.WriteLine($"Result: x1 = {result2[0]}\t x2 = {result2[1]}\t x3 = {result2[2]}");

            Proverka(result, array);
            Proverka(result2, array);
        }
    }
}
