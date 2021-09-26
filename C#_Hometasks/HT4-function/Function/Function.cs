using System;

namespace Function
{
    public enum SortOrder { Ascending, Descending }
    public static class Function
    {
        public static bool IsSorted(int[] array, SortOrder order)
        {
            bool IsSorted(int a, int b) => order == SortOrder.Ascending ? a <= b : a >= b;

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (!IsSorted(array[i], array[i + 1]))
                {
                    return false;
                }
            }
            return true;
        }

        public static void Transform(int[] array, SortOrder order)
        {
            if (IsSorted(array, order) == true)
            {
                for (int i = 0; i <= array.Length - 1; i++)
                {
                    array[i] += i;
                }
            }
        }


        public static double MultArithmeticElements(double a, double t, int n)
        {
            if (n <= 0)
                return 0;

            double result = a;
            double multiplier = a;
            for (int i = 2; i <= n; i++)
            {
                multiplier += t;
                result *= multiplier;
            }
            return result;
        }


        public static double SumGeometricElements(double a, double t, double alim)
        {
            if (a < alim)
            {
                return 0;
            }

            double result = 0;
            double term = a;
            
            while (term >= alim)
            {
                result += term;
                term *= t;
            }

            return result;
        }

    }
}
