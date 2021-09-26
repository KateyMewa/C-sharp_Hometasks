using System;
using System.Linq;

namespace ArrayObject
{
    public static class ArrayTasks
    {
        /// <summary>
        /// Task 1
        /// </summary>
        public static void ChangeElementsInArray(int[] nums)
        {
            for (int i = 0, j = nums.Length - 1; i < j; i++, j--)
            {
                if (nums[i] % 2 == 0 && nums[j] % 2 == 0)
                {
                    int temp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp;
                }
            }
        }

        /// <summary>
        /// Task 2
        /// </summary>
        public static int DistanceBetweenFirstAndLastOccurrenceOfMaxValue(int[] nums)
        {
            return nums != null && nums.Any() ? Array.LastIndexOf(nums, nums.Max()) - Array.IndexOf(nums, nums.Max()) : 0;
        }

        /// <summary>
        /// Task 3 
        /// </summary>
        public static void ChangeMatrixDiagonally(Array matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j > i)
                    {
                        matrix.SetValue(1, i, j);           
                    }
                    else if (j < i)
                    {
                        matrix.SetValue(0, i, j);
                    }
                }
            }

        }
    }
}
