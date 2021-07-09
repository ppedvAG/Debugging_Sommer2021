using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calculator.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void Sum_3_and_4_results_7()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(3, 4);

            //Assert
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void Sum_N5_and_N8_results_N13()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(-5, -8);

            //Assert
            Assert.AreEqual(-13, result);
        }

        [TestMethod]
        public void Sum_0_and_0_results_0()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(0, 0);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Sum_MAX_and_1_OverflowException()
        {
            //Arrange
            var calc = new Calc();

            //Act
            Assert.ThrowsException<OverflowException>(() => calc.Sum(int.MaxValue, 1));
        }
    }
}
