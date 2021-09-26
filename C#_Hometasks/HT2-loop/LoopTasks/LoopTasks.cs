using System;

namespace LoopTasks
{
    public static class LoopTasks
    {
        /// <summary>
        /// Task 1
        /// </summary>
        public static int SumOfOddDigits(int n)
        {
            int sum = 0;
            while (n % 10 != 0)
            {
                if ((n % 10) % 2 != 0)
                {
                    sum += n % 10;
                }
                n /= 10;
            }
            return sum;
        }

        /// <summary>
        /// Task 2
        /// </summary>
        public static int NumberOfUnitsInBinaryRecord(int n)
        {
            int sum = 0;
            do
            {
                sum += n % 2;
                n /= 2;
            }
            while (n >= 1);
            return sum;
        }

        /// <summary>
        /// Task 3 
        /// </summary>
        public static int SumOfFirstNFibonacciNumbers(int n)
        {
            int f1 = 0;
            int f2 = 1;
            int f = 0;
            int sum = 0;

            for (int i = 2; i <= n; i++)
            {
                f1 = f2;
                f2 = f;
                f = f1 + f2;
                sum += f;
            }
            return sum;
        }
    }
}