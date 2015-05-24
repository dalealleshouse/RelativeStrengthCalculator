namespace RelativeStrengthCalculator.Tests.WeightConverterService
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ToPoundsShould : WeightConverterServiceTestBase
    {
        [TestMethod]
        public void ConvertOnePoundToKilogram()
        {
            var result = this.Sut.ToPounds(1);
            Assert.AreEqual(2.204622622m, Math.Round(result, 9));
        }

        [TestMethod]
        public void ConvertPoundsToKilogram()
        {
            var result = this.Sut.ToPounds(2175);
            Assert.AreEqual(4795.054203m, Math.Round(result, 6));
        }

        [TestMethod]
        public void ConvertPoundsToKilogram2()
        {
            var result = this.Sut.ToPounds(41);
            Assert.AreEqual(90.3895275m, Math.Round(result, 7));
        }
    }
}