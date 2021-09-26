using NUnit.Framework;
using System;

namespace Condition.Tests
{
    [TestFixture]
    public class Tests
    {
        [TestCase(2, 4)]
        [TestCase(0, 0)]
        [TestCase(-11, 11)]
        public void Task1_ReturnCorrectValue(int n, int expected)
        {
            var actualResult = Condition.Task1(n);
            if (actualResult != expected)
            {
                Assert.Fail(message: "Method 'Task1'  returnt incorrect value");
            }
        }


        [TestCase(401, 410)]
        [TestCase(999, 999)]
        [TestCase(370,730)]
        [TestCase(625,652)]        
        public void Task2_ReturnCorrectValue(int n, int expected)
        {
            var actualResult = Condition.Task2(n);
            if (actualResult != expected)
            {
                Assert.Fail(message: "Method 'Task2'  returnt incorrect value");
            } 
        }
    }
}
