using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    class Grafs
    {
        private int[,] A;
        //int[,] A = new int[,]
        //    {
        //        //a
        //        {0, 5, 3, int.MaxValue, int.MaxValue, int.MaxValue},
        //        //b
        //        {int.MaxValue, 0, int.MaxValue, 6, int.MaxValue, int.MaxValue},
        //        //c
        //        {int.MaxValue, int.MaxValue, 0, int.MaxValue, 2, 5},
        //        //d
        //        {int.MaxValue, int.MaxValue, int.MaxValue, 0, 7, 2},
        //        //f
        //        {int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, 0, 1},
        //        //g
        //        {int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, 0}
        //    };

        private int[,] S;

        public int Heights { get; private set; }


        private void SetS()
        {
            S = new int[Heights, Heights];

            for (int i = 0; i < Heights; i++)
            {
                for (int j = 0; j < Heights; j++)
                {
                    S[i, j] = i == j ? 0 : i + 1; 
                }
            }
        }

        private void SetA()
        {
            for (int i = 0; i < Heights; i++)
            {
                for (int j = 0; j < Heights; j++)
                {
                    if(A[i,j] == int.MaxValue)
                    {
                        A[i, j] = int.MaxValue / 2;
                    }
                }
            }
        }

        public Lab_7(int Heights, int[,] A)
        {
            this.Heights = Heights;
            this.A = A;

            SetS();
            SetA();
        }

        public void Floyd()
        {
            int k = 0;
            while (++k < Heights)
            {
                for (int i = 0; i < Heights; i++)
                {
                    for (int j = 0; j < Heights; j++)
                    {
                        if (i != j && i != k && j != k)
                        {
                            if (A[i, k] + A[k, j] < A[i, j])
                            {
                                A[i, j] = A[i, k] + A[k, j];
                                S[i, j] = S[k, j];
                            }
                        }
                    }
                }
            }
        }

        public int GetLength(int startPoint, int EndPoint)
        {
            return A[startPoint - 1, EndPoint - 1] == 1073741823 ? 0 : A[startPoint - 1, EndPoint - 1];
        }

        public List<int> GetWay(int a, int b)
        {
            var way = new List<int>();

            way.Add(a);
            int element = S[a - 1, b - 1];
            while (true)
            {
                if (a == element || element == 0)
                {
                    break;
                }
                way.Add(element);
                element = S[a - 1, element - 1];
            }
            way.Add(b);

            return way;
        }
    }
}
