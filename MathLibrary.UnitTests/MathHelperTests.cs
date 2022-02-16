using NUnit.Framework;
using System;

namespace MathLibrary.UnitTests
{
    public class MathHelperTests
    {
        [SetUp]
        public void Setup()
        {
        }

        // {MethodName}_{WhenCondition}_{ShouldExpectedResult}
        [Test]
        [TestCase(3, 2, 1 , 3)]
        [TestCase(1, 2, 3, 3)]
        [TestCase(-1, -2, -3, -1)]
        [TestCase(-1, 0, 100, 100)]
        public void GetMax_WhenCalled_ShouldFindMaxValue(int a, int b, int c, int expectedResult)
        {
            // Act
            var actualResult = MathHelper.GetMax(a, b, c);
            
            // Asset
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(new []{1, 2, 3, 4}, 4)]
        [TestCase(new[] { 0 }, 0)]
        [TestCase(new[] { -5, -17, 15, 20 }, 20)]
        public void GetMaxFromArray_WhenCalled_ShouldFindMaxValue(int[] array, int expectedResult)
        {
            // Act
            var actualResult = MathHelper.GetMaxFromArray(array);

            // Asset
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(null)]
        [TestCase(new int[] { })]
        public void GetMaxFromArray_WhenArrayEmptyOrNull_ShouldThrowArgumentException(int[] array)
        {
            Assert.Throws<ArgumentException>(() => MathHelper.GetMaxFromArray(array));
        }
    }
}