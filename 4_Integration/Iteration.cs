using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_1
{
    public class Iteration
    {

        //private float gx(float x)
        //{
        //    return Convert.ToSingle(Math.Sin(x + 2) - 1.5f);
        //}

        //private float gy(float y)
        //{
        //    return Convert.ToSingle(0.5f - Math.Cos(y - 2));
        //}

        public Func<float, float> gX;
        public Func<float, float> gY;

        public Iteration(Func<float, float> funcX, Func<float, float> funcY)
        {
            gX = funcX;
            gY = funcY;
        }

        public float[] SimpleIteration(float startIterationX, float startIterationY, float accuracy = 0.0001f)
        {
            float x = startIterationX;
            float xy;
            float y = startIterationY;

            float[] x_vector = new float[2] { x, y };
            float[] x_vectorOld = new float[2];
            float missing;

            int k = 1;
            while (k <= 1000)
            {
                x_vectorOld[0] = x;
                x_vectorOld[1] = y;

                xy = x;
                x = gX(y);
                y = gY(xy);

                x_vector[0] = x;
                x_vector[1] = y;

                missing = CommonFunctionInterpolation.Norma(CommonFunctionInterpolation.VectorMinus(x_vector, x_vectorOld));
                Console.WriteLine($"k = {k};\t x = {x};\t y = {y};\t missing = {missing}");
                if (missing < accuracy)
                {
                    return x_vector;
                }
                else
                {
                    k++;
                }
            }
            throw new InvalidOperationException("Ітераційний процесс незбіжний");
        }
        public float[] ZeydelIteration(float startIterationX, float startIterationY, float accuracy = 0.0001f)
        {
            float x = startIterationX;
            float y = startIterationY;

            float[] x_vector = new float[2] { x, y };
            float[] x_vectorOld = new float[2];
            float missing;


            x_vector[0] = x;
            x_vector[1] = y;

            int k = 1;
            do
            {
                x_vectorOld[0] = x;
                x_vectorOld[1] = y;

                x = gX(y);
                y = gY(x);

                x_vector[0] = x;
                x_vector[1] = y;

                missing = CommonFunctionInterpolation.Norma(CommonFunctionInterpolation.VectorMinus(x_vector, x_vectorOld));
                Console.WriteLine($"k = {k};\t x = {x};\t y = {y};\t missing = {missing}");
                if (missing < accuracy)
                {
                    break;
                }
                else
                {
                    k++;
                }
            } while (k <= 10000);
            if (k == 10000)
            {
                throw new InvalidOperationException("Ітераційний процесс незбіжний");
            }
            return x_vector;
        }
    }
}
