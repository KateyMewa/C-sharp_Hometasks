using System;
using ArrayObject;
using NUnit.Framework;

namespace Array.Tests
{
    [TestFixture]
    public class ArrayTasksTest
    {
        [Test]
        public void ChangeElementsInArray_Array_SwapedArray()
        {
            test(new int[] { 20, 15, -15, 0 }, new int[] { 0, 15, -15, 20 });
            test(new int[] { 11, 20, 30, 40, 55 }, new int[] { 11, 40, 30, 20, 55 });
            test(new int[] { 11, 20, 33, 40, 11, 55 }, new int[] { 11, 20, 33, 40, 11, 55 });
            test(new int[] { 4, -6, 8, 10, -12, -2 }, new int[] { -2, -12, 10, 8, -6, 4 });
            test(new int[] { 11, 33, 55, 77 }, new int[] { 11, 33, 55, 77 });
            test(new int[] { 1 }, new int[] { 1 });
            test(new int[] { }, new int[] { });

            void test(int[] nums, int[] expectedResult)
            {
                ArrayTasks.ChangeElementsInArray(nums);
                Assert.AreEqual(expectedResult, nums,
                    "ChangeElementsInArray worked incorrectly. Check your solution and change it.");
            }
        }

        [Test]
        public void DistanceBetweenFirstAndLastOccurrenceOfMaxValue_Array_Result()
        {
            test2(new int[] { 4, 3, 100, 4 }, 0);
            test2(new int[] { -5, 4, 50, 50, -5 }, 1);
            test2(new int[] { 100, 350, 350, 100, 350, 100 }, 3);
            test2(new int[] { 10, 10, 10, 10, 10 }, 4);
            test2(new int[] { -70, -50, -30, -10, -15 }, 0);
            test2(new int[] { 13 }, 0);
            test2(new int[] { }, 0);

            void test2(int[] nums, int expectedResult)
            {
                int actualResult = ArrayTasks.DistanceBetweenFirstAndLastOccurrenceOfMaxValue(nums);
                Assert.AreEqual(expectedResult, actualResult,
                    "DistanceBetweenFirstAndLastOccurrenceOfMaxValue worked incorrectly. Check your solution and change it.");
            }
        }

        [Test]
        public void ChangeMatrixDiagonally_TwoDimensionalArray_TwoDimensionalArrayWith0And1()
        {
            test3(new int[,] { { 1, 0, 0 }, { 1, 1, 0 }, { 1, 1, 1 } },
                new int[,] { { 1, 1, 1 }, { 0, 1, 1 }, { 0, 0, 1 } });
            test3(new int[,] { { 2, 4, 3, 3 }, { 5, 7, 8, 5 }, { 2, 4, 3, 3 }, { 5, 7, 8, 5 } },
                new int[,] { { 2, 1, 1, 1 }, { 0, 7, 1, 1 }, { 0, 0, 3, 1 }, { 0, 0, 0, 5 } });
            test3(new int[,] { { 10, -5 }, { -5, -15 } }, new int[,] { { 10, 1 }, { 0, -15 } });

            void test3(int[,] matrix, int[,] expectedResult)
            {
                ArrayTasks.ChangeMatrixDiagonally(matrix);
                Assert.AreEqual(expectedResult, matrix,
                    "ChangeMatrixDiagonally worked incorrectly. Check your solution and change it.");
            }
        }
    }
}
