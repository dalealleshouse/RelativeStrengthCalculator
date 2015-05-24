//  --------------------------------
//  <copyright file="AdjustedTotalShould.cs">
//      Copyright (c) 2014 All rights reserved.
//  </copyright>
//  <author>Alleshouse, Dale</author>
//  <date>08/09/2014</date>
//  ---------------------------------
namespace RelativeStrengthCalculator.Wilks.Tests.WilksCalculator
{
    using System;

    [TestClass]
    public class AdjustedTotalShould
    {
        // All data is tested against this page
        // http://tsampa.org/training/scripts/relative_strength/
        [TestMethod]
        public void CalculateLowCoefficient()
        {
            var sut = new WilksCalculatorFactory().Build();

            var result = sut.AdjustedTotal(Sex.Female, 80, 600);
            Assert.AreEqual(426.90116735m, Math.Round(result, 8));
        }

        [TestMethod]
        public void CalculateHighCoefficient()
        {
            var sut = new WilksCalculatorFactory().Build();

            var result = sut.AdjustedTotal(Sex.Male, 450, 2100);
            Assert.AreEqual(506.37108977m, Math.Round(result, 8));
        }

        [TestMethod]
        public void CalculateMaleCoefficient()
        {
            var sut = new WilksCalculatorFactory().Build();

            var result = sut.AdjustedTotal(Sex.Male, 218.2m, 1765);
            Assert.AreEqual(489.26935697m, Math.Round(result, 8));
        }

        [TestMethod]
        public void CalculateMaleCoefficient2()
        {
            var sut = new WilksCalculatorFactory().Build();

            var result = sut.AdjustedTotal(Sex.Male, 197.6m, 1823);
            Assert.AreEqual(528.99941990m, Math.Round(result, 8));
        }

        [TestMethod]
        public void CalculateFemaleCoefficient()
        {
            var sut = new WilksCalculatorFactory().Build();

            var result = sut.AdjustedTotal(Sex.Female, 142.6m, 1790);
            Assert.AreEqual(854.90232676m, Math.Round(result, 8));
        }

        [TestMethod]
        public void CalculateFemaleCoefficient2()
        {
            var sut = new WilksCalculatorFactory().Build();

            var result = sut.AdjustedTotal(Sex.Female, 164.8m, 1125);
            Assert.AreEqual(486.11327924m, Math.Round(result, 8));
        }
    }
}