using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_1
{
    public class Iteration_SLAR
    {
        //private static float[,] array = new float[3, 4] { 
        //    {  56,  27, -17,  19 }, 
        //    { 14, 50, 13, 31  }, 
        //    {   8,  13,  37,  12 } 
        //};

        private float[,] array { get; }

        public Iteration_SLAR(float[,] arr)
        {
            array = arr;
        }

        private float X1(float x2, float x3) => (array[0,3] - array[0, 1] * x2 - array[0, 2] * x3) / array[0, 0];

        private float X2(float x1, float x3) => (array[1, 3] - array[1, 0] * x1 - array[1, 2] * x3) / array[1, 1];

        private float X3(float x1, float x2) => (array[2, 3] - array[2, 0] * x1 - array[2, 1] * x2) / array[2, 2];

        public float[] SimpleIteration_SLAR(float x, float accuracy = 0.0001f)
        {
            float x1 = x;
            float x2 = x;
            float x3 = x;

            float X_1;
            float X_2;
            float X_3;

            float missing;
            float[] resultOld = new float[3];
            float[] result = new float[3] { x1, x2, x3 };

            int k = 1;
            while (k <= 1000)
            {
                resultOld[0] = x1;
                resultOld[1] = x2;
                resultOld[2] = x3;

                X_1 = X1(x2, x3);
                X_2 = X2(x1, x3);
                X_3 = X3(x1, x2);

                x1 = X_1;
                x2 = X_2;
                x3 = X_3;

                result[0] = x1;
                result[1] = x2;
                result[2] = x3;

                missing = CommonFunctionInterpolation.Norma(CommonFunctionInterpolation.VectorMinus(result, resultOld));
                Console.WriteLine($"k = {k};\t x1 = {x1};\t x2 = {x2};\t x3 = {x3};\t missing {missing}");
                if (missing < accuracy)
                {
                    return result;
                }
                else
                {
                    k++;
                }
            }
            throw new InvalidOperationException("інтераційний процесс є незбіжним");
        }

        public float[] ZeydalIteration_SLAR(float x, float accuracy = 0.0001f)
        {
            float x1 = x;
            float x2 = x;
            float x3 = x;

            float missing;
            float[] resultOld = new float[3];
            float[] result = new float[3] { x1, x2, x3 };

            int k = 1;
            while (k <= 1000)
            {
                resultOld[0] = x1;
                resultOld[1] = x2;
                resultOld[2] = x3;

                x1 = X1(x2, x3);
                x2 = X2(x1, x3);
                x3 = X3(x1, x2);

                result[0] = x1;
                result[1] = x2;
                result[2] = x3;

                missing = CommonFunctionInterpolation.Norma(CommonFunctionInterpolation.VectorMinus(result, resultOld));
                Console.WriteLine($"k = {k};\t x1 = {x1};\t x2 = {x2};\t x3 = {x3};\t missing = {missing}");
                if (missing < accuracy)
                {
                    return result;
                }
                else
                {
                    k++;
                }
            }
            throw new InvalidOperationException("інтераційний процесс є незбіжним");
        }
    }
}
