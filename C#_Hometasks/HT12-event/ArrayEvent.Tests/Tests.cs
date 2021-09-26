using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ArrayEvent.Tests
{
    [TestFixture]
    public class Tests
    {
       
        [Test]
        public void Array_Get_ShouldReturnSameReference()
        {
            //arrange
            var array = new int[] { 1, 2, 3, 4 };
            int first = -5;
            //act
            var custom = new CustomArray<int>(first, array);
            //assert
            Assert.AreSame(array, custom.Array, message: "Array property works incorrectly");
        }

        [Test]
        public void Array_Get_WithListShouldRetrurnSameReference()
        {
            var expected_list = new List<int>() { 6, 2, -8, 0 };
            int first = 4;

            var custom = new CustomArray<int>(first, expected_list);
            var actual_array = custom.Array;

            Assert.AreEqual(expected_list, actual_array, message: "Array property or constructor works incorrectly");

        }

        [TestCase(-4, 5, -3, 10)]
        [TestCase(1, 7, 2, 4)]
        [TestCase(0, 3, 1, 9)]
        public void Indexer_GetElementAtPosition_ShouldReturnValue(int first, int length, int n, int element)
        {
            //Act
            var custom = new CustomArray<int>(first, length);
            custom[n] = element;
            //Assert
            Assert.AreEqual(element, custom[n], message: "Index get property works incorrectly");

        }
        [TestCase(-1, 6)]
        [TestCase(0, 7)]
        [TestCase(5, 2)]
        public void Length_Get_ShouldReturnCorrectValue(int first, int length)
        {
            // Act
            var custom = new CustomArray<string>(first, length);
            //Assert
            Assert.AreEqual(length, custom.Length, message: "Length get  property works incorrectly ");
        }
        [TestCase(-1, 5)]
        [TestCase(0, 11)]
        [TestCase(7, 3)]
        public void First_Get_ShouldReturnCorrectValue(int first, int length)
        {
            // Act
            var custom = new CustomArray<int>(first, length);

            //Assert
            Assert.AreEqual(first, custom.First, message: "First get property works incorrectly ");
        }
        [TestCase(-8, 4, -5)]
        [TestCase(0, 8, 7)]
        [TestCase(3, 5, 7)]
        public void Last_Get_ShouldReturnCorrectValue(int first, int length, int last)
        {
            //Act
            var custom = new CustomArray<bool>(first, length);

            //Assert
            Assert.AreEqual(last, custom.Last, message: "Last get property works incorrectly ");

        }
        [Test]
        public void CustomArrayProperties_Get_ShouldReturnCorrectValues()
        {
            //Arrange
            int first = 4;
            int length = 4;
            int last = 7;

            //Act
            var custom = new CustomArray<int>(first, 5, 7, 3, 7);
            //Assert
            Assert.AreEqual(first, custom.First, message: "First get property works incorrectly");
            Assert.AreEqual(length, custom.Length, message: "Length get property works incorrectly");
            Assert.AreEqual(last, custom.Last, message: "Last get property works incorrectly");

        }


       

      
        [Test]
        public void CreateCustomArray_WithNullArray_ShoulThrowNullReferenceException()
        {
            //arrange
            int first = 1;
            int[] array = null;
            var expectedEx = typeof(ArgumentNullException);
            //act
            var actEx = Assert.Catch(() => new CustomArray<int>(first, array));
            //assert
            Assert.AreEqual(expectedEx, actEx.GetType(),
                message: "CustomArray can't be created with null array");

        }

        [Test]
        public void CreateCustomArray_WithEmptyArray_ShoulThrowNullReferenceException()
        {
            //arrange
            int first = 1;
            int[] array = new int[] { };
            var expectedEx = typeof(ArgumentException);
            //act
            var actEx = Assert.Catch(() => new CustomArray<int>(first, array));
            //assert
            Assert.AreEqual(expectedEx, actEx.GetType(),
                message: "CustomArray can't be created with null array");

        }
        [TestCase(0)]
        [TestCase(-8)]
        [TestCase(-4)]
        public void Length_SetElementLessThan0_ShouldThrowArgumentException(int length)
        {
            //Arrange
            int first = 3;
            var expectedEx = typeof(ArgumentException);
            //Act
            var actEx = Assert.Catch(() => { var custom = new CustomArray<int>(first, length); });
            //Assert
            Assert.AreEqual(expectedEx, actEx.GetType(),
                message: "Set property in Length should throw ArgumentException in case of length parameter smaller or equal 0  ");

        }

        [TestCase(4, 6, 3)]
        [TestCase(0, 11, 11)]
        [TestCase(-8, 3, -5)]
        public void Indexer_SetElementOutOfRange_ShouldThrowIArgumentException(int first, int length, int index)
        {
            //Arrange
            int value = -5;
            //Act
            var custom = new CustomArray<long>(first, length);
            var expectedEx = typeof(ArgumentException);
            //Assert
            var actEx = Assert.Catch(() => custom[index] = value);
            Assert.AreEqual(expectedEx, actEx.GetType(),
                message: "Indexer  should throw ArgumentException ,if index parameter  out of array range");

        }

        [TestCase(-6, 4, -9)]
        [TestCase(0, 3, 7)]
        [TestCase(9, 17, 5)]
        public void Indexer_GetElementOutOfRange_ShouldThrowArgumentException(int first, int length, int index)
        {
            //Arrange
            var custom = new CustomArray<int>(first, length);
            int result = 0;
            //Act -Assert 
            var actEx = Assert.Throws<ArgumentException>(() => result = custom[index], message: "Get indexer works incorrect");

        }

        [Test]
        public void Indexer_WithNullValue_ShouldThrowArgumentNullException()
        {
            //arrange
            int first = 1;
            int length = 7;
            string value = null;
            int index = 5;
            var custom = new CustomArray<string>(first, length);

            //act &assert 
            Assert.Throws<ArgumentNullException>(() => custom[index] = value, message: "Indexer set not throw exception if value is null ");
        }



        [Test]
        public void CreateCustomArray_WithListWithoutParams_ShouldThrowArgumentException()
        {
            //Arrange
            int first = 4;
            List<int> list = new List<int>();
            var expectedEx = typeof(ArgumentException);
            //Act
            var actEx = Assert.Catch(() => { var custom = new CustomArray<int>(first, list); });
            //Arrange
            Assert.AreEqual(expectedEx, actEx.GetType(),
                message: "CustomArray can't be created with list without elements ");

        }

        [Test]
        public void CreateCustomArray_WithListNull_ShouldThrowNullReferenceException()
        {
            //Arrange
            int first = 1;
            List<int> list = null;
            var expectedEx = typeof(NullReferenceException);
            //Act
            var actEx = Assert.Catch(() => { var custom = new CustomArray<int>(first, list); });
            //Arrange
            Assert.AreEqual(expectedEx, actEx.GetType(),
                message: "CustomArray can't be created with null list ");

        }


        [Test]
        public void GetEnumerator_OfListAndCustomArray_ShouldHaveEqualElements()
        {
            List<int> list = new List<int>()
            {
                5,10,14
            };

            int first = 7;
            CustomArray<int> array = new CustomArray<int>(first, list);

            var en2 = list.GetEnumerator();
            var en = array.GetEnumerator();
            for (int i = 0; i < array.Length; i++)
            {
                if (en.MoveNext() && en2.MoveNext())
                {
                    Assert.AreEqual(en.Current, en2.Current, message: "GetEnumerator works incorretly ");
                }
            }

        }

        [Test]
        public void GetEnumerator_UsingIEnumerableExplicitlyOfListAndCustomArray_ShouldHaveEqualElements()
        {
            //Arrange

            List<int> expected_list = new List<int>()
            {
                5,10,14
            };
            int first = 7;
            List<int> actual = new List<int>();

            //Act
            CustomArray<int> array = new CustomArray<int>(first, expected_list);
            IEnumerable enumerable = array;

            //Assert
            foreach (var item in enumerable)
            {
                actual.Add((int)item);
            }
            Assert.AreEqual(expected_list, actual);

        }


        [TestCase(3, 6, 5, 10)]
        [TestCase(-10, 6, -8, 18)]
        [TestCase(0, 21, 0, 11)]
        public void OnChangeElement_Invoke(int first, int length, int index, int element)
        {
            //Arrange           
            int? actualValue = null;

            //Act
            CustomArray<int> custom = new CustomArray<int>(first, length);
            custom.OnChangeElement += (o, e) => actualValue = e.Value;
            custom[index] = element;

            //Assert
            Assert.AreEqual(element, actualValue, message: "OnchangeElement event doesen't invoke or indexer set works incorrect");
        }

        [TestCase(9, 7, 13, 13)]
        [TestCase(-11, 5, -9, -9)]
        [TestCase(0, 5, 4, 4)]
        public void OnChangeEqualElement_Invoke(int first, int length, int index, int element)
        {
            //Arrange
            var expectedValue = element;
            int? actualValue = null;
            int? actualIndex = null;

            //Act
            var custom = new CustomArray<int>(first, length);

            custom.OnChangeEqualElement += (o, e) =>
            {
                actualValue = e.Value;
                actualIndex = e.Index;
            };

            custom[index] = element;
            if (expectedValue == actualValue && index == actualIndex)
            {
                Assert.True(true);
            }
            else
            {
                Assert.Fail("OnChangeEqualElement event invokes in wrong place or indexer set works incorrect");
            }


        }

        [TestCase(0, 6, 2, "Hello")]
        [TestCase(-10, 4, -7, "World")]
        [TestCase(4, 10, 6, "Hello")]
        public void OnChangeElement_WithEqualValues_NotInvoke(int first, int length, int index, string value)
        {
            //arrange

            var custom = new CustomArray<string>(first, length);
            custom[index] = value;
            string actualValue = null;

            //act

            custom.OnChangeElement += (o, e) => 
            { actualValue = e.Value; };
            custom[index] = value;


            //assert 
            Assert.AreEqual(null, actualValue, message: "OnChangeElement event invokes in wrong place or indexer set works incorrect ");
        }

        [TestCase(5, 3, 6, 11)]
        [TestCase(-7, 4, -5, 23)]
        public void OnChangeElement_Invoke_VerifySender(int first, int length, int index, int value)
        {
            //Arrange           
            CustomArray<int> actualSender = null;

            //Act
            CustomArray<int> expectedSender = new CustomArray<int>(first, length);
            expectedSender.OnChangeElement += (o, e) => actualSender = (CustomArray<int>)o;
            expectedSender[index] = value;

            // expectedSender = null;

            if (expectedSender == actualSender)
            {
                Assert.True(true);
            }
            else
            {
                Assert.Fail(message: "Sender object in OnChangeElement event isn't correct ");
            }

        }

        [TestCase(5, 3, 6, 6)]
        [TestCase(-7, 4, -5, -5)]
        public void OnChangeEqualElement_Invoke_VerifySender(int first, int length, int index, int value)
        {
            //Arrange           
            CustomArray<int> actualSender = null;

            //Act
            CustomArray<int> expectedSender = new CustomArray<int>(first, length);
            expectedSender.OnChangeEqualElement += (o, e) => actualSender = (CustomArray<int>)o;
            expectedSender[index] = value;

            // Assert

            if (expectedSender == actualSender)
            {
                Assert.True(true);
            }
            else
            {
                Assert.Fail(message: "Sender object in OnChangeEqualElement event isn't correct ");
            }

        }



     

    }
}
