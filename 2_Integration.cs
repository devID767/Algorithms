using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    class NumberingIntegration
    {
        public static float MyFunction(float x)
        {
            return Convert.ToSingle(Math.Pow(Math.E, Math.Pow(x, 2)));
        }

        public static float Integral(float a, float b, float h) //trapezoid
        {
            int n = 0;
            if (h != 0)
            {
                n = Convert.ToInt32((b - a) / h);
            }

            float x = 0;
            float integral = h / 2 * (MyFunction(a) + MyFunction(b));
            for (int i = 1; i < n; i++)
            {
                x = a + h * i;
                integral += h * MyFunction(x);
            }

            return integral;
        }

        static void Start()
        {
            float a = 0;
            float b = 1;
            float h = 0.1f;
            int n = Convert.ToInt32((b - a) / h);

            float h_t = 0f;

            float accuracy = 0.0001f;
            float missing = 0;

            float integral = 0;
            float integral_2 = 0;


            for (int i = 0; i <= n; i++)
            {
                float count = 1;
                float x = a + h * i;
                while (true)
                {
                    h_t = (x - a) / count;
                    integral = Integral(a, x, h_t);
                    integral_2 = Integral(a, x, h_t * 2);
                    missing = Math.Abs((integral - integral_2) / 3);
                    if (missing < accuracy)
                    {
                        break;
                    }
                    else
                    {
                        count *= 2;
                    }
                }
                Console.WriteLine($"The result = {integral} \n" +
                $"The missing = { missing}\n" +
                $"The h = {h_t}\n" +
                $"The x = {x}\n");
                //Console.WriteLine($"{integral};\t{missing};\t{h_t};\t{x}\n");
            }
        }
    }
}
