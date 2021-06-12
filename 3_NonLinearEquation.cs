using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    class NonLinearEquation
    {
        static float MyFunction_D2(float x)
        {
            double x1 = -1 / (4 * x * Math.Pow(x, 0.5));
            double x2 = -2 / (9 * x * Math.Pow(x, 2 / 3));
            double x3 = -3 / (16 * Math.Pow(x, 3 / 4) * Math.Abs(x));
            return Convert.ToSingle(x1 + x2 + x3);
        }

        static float MyFunction_D1(float x)
        {
            double x1 = 1 / (2 * Math.Pow(x, 0.5));
            double x2 = 1 / (3 * Math.Pow(x, 0.666667));
            double x3 = 1 / (4 * Math.Pow(x, 0.75));
            return Convert.ToSingle(1 + x1 + x2 + x3);
        }
        static float MyFunction(float x)
        {
            return Convert.ToSingle(x + Math.Pow(x, 0.5) + Math.Pow(x, 0.333333333) + Math.Pow(x, 0.25) - 5);
        }

        static float Nuton(float a, float b, float accuracy = 0.0001f)
        {
            float x = 0;
            if (MyFunction(a) * MyFunction_D2(a) > 0)
            {
                x = a;
            }
            else
            {
                x = b;
            }

            float x0 = 0;
            int k = 0;
            do
            {
                x0 = x;
                x = x0 - (MyFunction(x0) / MyFunction_D1(x0));
                Console.WriteLine($"k = {k};\t x = {x};\t |x(k)-x(k-1)| = {x - x0}\t");
                if (MyFunction(x) == 0)
                {
                    break;
                }
                k++;

            } while (Math.Abs(x - x0) > accuracy);
            return x;
        }

        static void Start(int type)
        {
            float a = 1.4f;
            float b = 1.6f;
            float accuracy = 0.0001f;

            if (type == 1)
            {
                Console.WriteLine($"Result is {Bisection(a, b, accuracy)}");
            }
            else if (type == 2)
            {
                Console.WriteLine($"Result is {Nuton(a, b, accuracy)}");
            }
        }

        static float Bisection(float a, float b, float accuracy = 0.0001f)
        {
            int k = 0;
            float x = 0;
            float missing = 0;
            do
            {
                missing = Math.Abs(b - a);
                x = (a + b) / 2;
                float function = MyFunction(x);
                Console.WriteLine($"k = {k};\t a = {a};\t b = {b};\t x = {x};\t |b-a| = {missing};\t fk = {function}");
                if (function == 0)
                {
                    break;
                }
                if (MyFunction(a) * MyFunction(x) < 0)
                {
                    b = x;
                }
                else
                {
                    a = x;
                }
                k++;
            } while (missing > accuracy);
            return x;
        }
    }
}
