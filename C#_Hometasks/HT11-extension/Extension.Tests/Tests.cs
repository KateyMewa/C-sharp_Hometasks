using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Extension.Tests
{
    [TestFixture]
    public class Tests
    {
        [TestCase(1074, 12)]
        [TestCase(-4678, 25)]
        [TestCase(0, 0)]
        [TestCase(02, 2)]
        [TestCase(333333, 18)]
        public void SummaDigit_WithIntegerValue_ReturntSumOfDigits(int n, int expected)
        {
            //Act 
            var actualResult = n.SummaDigit();// MyExtensions.SummaDigit(n);

            //Assert 
            Assert.AreEqual(expected, actualResult, message: "SummaDigit method works incorrect ");
        }

        [TestCase((uint)132, (ulong)363)]
        [TestCase((uint)9, (ulong)18)]
        [TestCase((uint)0, (ulong)0)]
        [TestCase((uint)8421, (ulong)9669)]
        [TestCase((uint)74, (ulong)121)]
        public void SummaWithReverse_WithUintValue_ReturnSum(uint n, ulong expected)
        {
            //Act 
            var actualResult = n.SummaWithReverse();// MyExtensions.SummaWithReverse(n);
                                                    //Assert
            Assert.AreEqual(expected, actualResult, message: "SummaWithReverse works incorrect");
        }

        [TestCase("I like C#", 3)]
        [TestCase("Hello мир", 4)]
        [TestCase("", 0)]
        [TestCase("Пр4об5е9л",9 )]
        [TestCase("Hellouniverse", 0)]
        [TestCase("q7er51ty6i", 4)]
        [TestCase("@8/-u=", 5)]
        public void CountNotLetter_WithStringValue_ReturnAmountOfNonAlphabet(string str, int expected)
        {
            //Act
            var actualResult = str.CountNotLetter();// MyExtensions.CountNotLetter(str);
                                                    //Assert
            Assert.AreEqual(expected, actualResult, message: "CountNotLetter works incorrect ");
        }

        [TestCase(DayOfWeek.Monday, false)]
        [TestCase(DayOfWeek.Tuesday, false)]
        [TestCase(DayOfWeek.Wednesday, false)]
        [TestCase(DayOfWeek.Thursday, false)]
        [TestCase(DayOfWeek.Friday, false)]
        [TestCase(DayOfWeek.Saturday, true)]
        [TestCase(DayOfWeek.Sunday, true)]
        public void IsDayOff_WithDayOfWeekValue_ReturnCorrectValue(DayOfWeek day, bool expected)
        {

            //Act
            var actualResult = day.IsDayOff();// MyExtensions.IsDayOff(day);
                                              //Assert
            Assert.AreEqual(expected, actualResult, message: "IsDayOff works incorrect");


        }


        [Test,TestCaseSource("Collection")]
        public void EvenPositiveElements_WithCollectionParameter_ReturnEvenNumbers(IEnumerable<int> numbers,IEnumerable<int> expected)
        {            
                var actualResult = numbers.EvenPositiveElements();// MyExtensions.EvenPositiveElements(numbers);
                //Assert
                CollectionAssert.AreEqual(expected, actualResult, message: "EvenPositiveElements works incorrect ");           
        }

        static object[] Collection =
        {
            new object []{new int[]{5,1,8,24}, new int[] { 8,24} },
            new object []{new List<int>() { 2,2,2,5,47,18}, new List<int>() { 2, 2, 2, 18 } },
            new object[]{ new List<int>() { 3,7,0,1,0},new List<int>() },
            new object[]{ new int[] { 2, -2, 3, -7, 9, 12, 4, 9 },new List<int>(){2,12,4} },
            new object[]{ new List<int>() { 1, 3, -4, 11, 5, 18 } ,new int[] { 18}  }

        };
    }
}
