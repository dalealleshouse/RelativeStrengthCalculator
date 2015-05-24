namespace RelativeStrengthCalculator.Tests.WeightConverterService
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ToKilogramShould : WeightConverterServiceTestBase
    {
        [TestMethod]
        public void ConvertOneKilogramToPound()
        {
            var result = this.Sut.ToKilogram(1);
            Assert.AreEqual(0.45359237m, Math.Round(result, 8));
        }

        [TestMethod]
        public void ConvertKilogramToPound()
        {
            var result = this.Sut.ToKilogram(4795);
            Assert.AreEqual(2174.975414m, Math.Round(result, 6));
        }

        [TestMethod]
        public void ConvertKilogramToPound2()
        {
            var result = this.Sut.ToKilogram(90);
            Assert.AreEqual(40.8233133m, Math.Round(result, 7));
        }
    }
}