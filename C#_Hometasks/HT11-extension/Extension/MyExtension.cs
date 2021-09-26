using System;
using System.Collections.Generic;
using System.Linq;

namespace Extension
{
    public static class MyExtension
    {
        /// <summary>
        /// Mehod that return sum of  'n' digit
        /// </summary>        
        /// <param name="n">Element parameter</param>
        /// <returns>Integer value</returns>
        public static int SummaDigit(this int n)
        {
            if (n < 0)
            {
                n *= -1;
            }
            int m = 0;
            for (int i = 0; n / 10 >= 1; i++)
            {
                int temp = n % 10;
                n /= 10;
                m = temp + m;
            }
            m += n;
            return m;
        }

        /// <summary>
        /// Method that return sum of 'n' element and reverse of 'n'
        /// </summary>
        /// <param name="n">Element parameter</param>
        /// <returns>Ulong value</returns>
        public static ulong SummaWithReverse(this uint n)
        {
            List<uint> temp = new List<uint>();
            dynamic k = n;
            for (int i = 0; n / 10 >= 1; i++)
            {
                uint m = n % 10;
                n /= 10;
                temp.Add(m);
            }
            temp.Add(n);
            uint result = 0;
            for (int i = 0; i < temp.LongCount()-1; i++)
            {
                uint t = temp[i];
                result = (result + t) * 10;
            }
            result += + n;
            return k + result;

        }

        /// <summary>
        /// Method that count amount of elements in string , which are not letters of the latin alphabet.
        /// </summary>
        /// <param name="str">String parameter</param>
        /// <returns>Integer value</returns>
        public static int CountNotLetter(this string str)
        {
            int l = str.Length;
            int count = 0;
            for (int i = 0; i < l; i++)
            {
                if ((str[i] >= 'a' && str[i] <= 'z') || (str[i] >= 'A' && str[i] <= 'Z'))
                {
                    count++;
                }
            }
            int result = l - count;
            return result;
        }

        /// <summary>
        /// Method that checks whether day is weekend or not 
        /// </summary>
        /// <param name="day">DayOfWeek parameter</param>
        /// <returns>Bool value</returns>
        public static bool IsDayOff(this DayOfWeek day)
        {
            return day == DayOfWeek.Sunday || day == DayOfWeek.Saturday;
        }


        /// <summary>
        /// Method that return positive ,even  element from collection 
        /// </summary>
        /// <param name="numbers">Collection of elements</param>
        /// <returns>IEnumerable -int collection  </returns>
        public static IEnumerable<int> EvenPositiveElements(this IEnumerable<int> numbers)
        {
            foreach (var item in numbers)
            {
                if (item > 0 && item % 2 == 0)
                {
                    yield return item;
                }
            }
        }
    }
}
