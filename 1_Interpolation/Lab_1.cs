using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.FirstLab
{
    public static class Lab_1
    {
        public static float GetValue(float x)
        {
            return Convert.ToSingle(Math.Log(Math.Pow(x, 2) + x + 1));
        }

        public static float GetFirstDerive(float x)
        {
            return Convert.ToSingle(((2 * x + 1) / (Math.Pow(x, 2) + x + 1)));
        }

        public static float GetSecondDerive(float x)
        {
            return Convert.ToSingle((-2 * Math.Pow(x, 2) - 2 * x + 1) / (Math.Pow(Math.Pow(x, 2) + x + 1, 2)));
        }

        private static void FirstPart()
        {
            var x_table = new List<float>() { 0.5f, 0.69f, 0.78f, 0.990f, 1.21f, 1.34f, 1.51f, 1.63f, 1.71f, 1.83f };
            var y_table = new List<float>() { 0.55962f, 0.77293f, 0.87062f, 1.0886f, 1.30313f, 1.41963f, 1.566561f, 1.66523f, 1.72884f, 1.82114f };

            var interpolation = new Interpolation(x_table, y_table);
            interpolation.SetXValues();

            var x_wanted = new List<float>();
            while (interpolation.a <= interpolation.b)
            {
                x_wanted.Add(interpolation.a);
                interpolation.a += interpolation.h;
            }

            Console.WriteLine("Введіть степінь поліному");
            int n = Int32.Parse(Console.ReadLine());

            Console.WriteLine($" x                y               Кускова інтерполяція {n} степіню         Глобальна інтерполяція");
            Console.WriteLine();
            foreach (float x in x_wanted)
            {
                var y_default = GetValue(x);
                var y_LagrangePiece = interpolation.Lagrang(x, InterpolationType.Piece, n);
                var y_LagrangeGlobal = interpolation.Lagrang(x, InterpolationType.Global);

                Console.WriteLine($"{ShowX(x)}          {ShowFunction(y_default)}                     {ShowFunction(y_LagrangePiece)}                       {ShowFunction(y_LagrangeGlobal)}");
                Console.WriteLine("____________________________________________________________________________________________________ \n");
            }
        }

        private static void SecondPart()
        {
            var x_table = new List<float>() { 0.5f, 0.69f, 0.78f, 0.990f, 1.21f, 1.34f, 1.51f, 1.63f, 1.71f, 1.83f };
            var y_table = new List<float>() { 0.55962f, 0.77293f, 0.87062f, 1.0886f, 1.30313f, 1.41963f, 1.566561f, 1.66523f, 1.72884f, 1.82114f };

            var interpolation = new Interpolation(x_table, y_table);
            interpolation.SetXValues();

            var y_wanted = new List<float>();
            var x_wanted = new List<float>();
            while (interpolation.a <= interpolation.b)
            {
                x_wanted.Add(interpolation.a);
                interpolation.a += interpolation.h;
            }

            Console.WriteLine("Введіть степінь поліному");
            int n = Int32.Parse(Console.ReadLine());

            Console.WriteLine("               y'(x)            похідна 1         апроксимація    |     похідна 2             апроксимація");
            Console.WriteLine("          ________________________________________________________|___________________________________________");
            Console.WriteLine("                                                                  |                                          ");
            for (int i = 0; i < x_wanted.Count; i++)
            {

                float derive_1, derive_2 = 0;
                if (i == 0) derive_1 = Differentiation.DifferentialCalculate_1(interpolation, x_wanted, i, n, DifferentialType.Right);
                else if (i == x_wanted.Count - 1) derive_1 = Differentiation.DifferentialCalculate_1(interpolation, x_wanted, i, n, DifferentialType.Left);
                else derive_1 = Differentiation.DifferentialCalculate_1(interpolation, x_wanted, i, n, DifferentialType.Central);

                if (i != 0 && i != x_wanted.Count - 1)
                    derive_2 = Differentiation.DifferentialCalculate_2(interpolation, x_wanted, i, n);


                string result;
                result = $"               {ShowX(x_wanted[i])}        {ShowFunction(GetFirstDerive(x_wanted[i]))}        {ShowFunction(derive_1)} ";
                result += $"        |     {ShowFunction(GetSecondDerive(x_wanted[i]))}             {derive_2}";
                Console.WriteLine(result);
                Console.WriteLine("          ________________________________________________________|___________________________________________");
                Console.WriteLine("                                                                  |                                          ");
            }
        }

        public static string ShowX(float x)
        {
            string result;
            result = Math.Round(x, 2).ToString();
            while (result.Length < 4)
            {
                result += " ";
            }
            return result;
        }

        public static string ShowFunction(float x)
        {
            string result = x.ToString();
            while (result.Length < 11)
            {
                result += " ";
            }
            return result;
        }
    }
}
