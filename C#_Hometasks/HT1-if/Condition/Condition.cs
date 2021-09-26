using System;

namespace Condition
{
    public static class Condition
    {
        /// <summary>
        /// Implement code according to description of  task 1
        /// </summary>        
        public static int Task1(int n)
        {
            if (n > 0)
            {
                return n*n;
            }
            if (n < 0)
            {
                return Math.Abs(n);
            }
            return n;
        }

        /// <summary>
        /// Implement code according to description of  task 2
        /// </summary>  
        public static int Task2(int n)
        {
            int z = n % 10;
            int y = (n / 10) % 10;
            int x = (n / 10) / 10;
            
            if (z >= y)
            {
                if (z >= x)
                {
                    if (x >= y)
                    {
                        return z * 100 + x * 10 + y;
                    }
                    return z * 100 + y * 10 + x;
                }
                return x * 100 + z * 10 + y;
            }
            if (x >= y)
            {
                return x * 100 + y * 10 + z;
            }
            if (x >= z)
            {
                return y * 100 + x * 10 + z;
            }
            return y * 100 + z * 10 + x;
        }
    }
}
