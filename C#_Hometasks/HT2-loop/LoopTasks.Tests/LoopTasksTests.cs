using NUnit.Framework;

namespace LoopTasks.Tests
{
    [TestFixture]
    public class LoopTasksTests
    {
        [TestCase(1, 1)]
        [TestCase(2, 0)]
        [TestCase(1234, 4)]
        [TestCase(246, 0)]
        public void SumOfOddDigits_ReturnsCorrectValue(int n, int expected)
        {
            var actual = LoopTasks.SumOfOddDigits(n);

            Assert.AreEqual(expected, actual, "SumOfOddDigits returns incorrect value.");
        }

        [TestCase(14, 3)]
        [TestCase(128, 1)]
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(5, 2)]
        public void NumberOfUnitsInBinaryRecord_ReturnsCorrectValue(int n, int expected)
        {
            var actual = LoopTasks.NumberOfUnitsInBinaryRecord(n);
            
            Assert.AreEqual(expected, actual, "NumberOfUnitsInBinaryRecord returns incorrect value.");
        }
        
        [TestCase(7, 20)]
        [TestCase(8, 33)]
        [TestCase(9, 54)]
        [TestCase(10, 88)]
        [TestCase(11, 143)]
        [TestCase(1, 0)]
        [TestCase(2, 1)]
        public void SumOfFirstNFibonacciNumbers_ReturnsCorrectValue(int n, int expected)
        {
            var actual = LoopTasks.SumOfFirstNFibonacciNumbers(n);
            
            Assert.AreEqual(expected, actual, "SumOfFirstNFibonacciNumbers returns incorrect value.");
        }
    }
}