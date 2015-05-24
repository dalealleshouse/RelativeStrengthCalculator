//  --------------------------------
//  <copyright file="CoefficientShould.cs">
//      Copyright (c) 2014 All rights reserved.
//  </copyright>
//  <author>Alleshouse, Dale</author>
//  <date>08/09/2014</date>
//  ---------------------------------
namespace RelativeStrengthCalculator.Wilks.Tests.WilksCalculator
{
    using System;

    [TestClass]
    public class CoefficientShould
    {
        // All data is tested against this page
        // http://tsampa.org/training/scripts/relative_strength/
        [TestMethod]
        public void CalculateLowCoefficient()
        {
            var sut = new WilksCalculatorFactory().Build();

            var result = sut.Coefficient(Sex.Female, 80);
            Assert.AreEqual(1.5685932847m, Math.Round(result, 10));
        }

        [TestMethod]
        public void CalculateHighCoefficient()
        {
            var sut = new WilksCalculatorFactory().Build();

            var result = sut.Coefficient(Sex.Male, 450);
            Assert.AreEqual(0.5315986474m, Math.Round(result, 10));
        }

        [TestMethod]
        public void CalculateMaleCoefficient()
        {
            var sut = new WilksCalculatorFactory().Build();

            var result = sut.Coefficient(Sex.Male, 218.2m);
            Assert.AreEqual(0.611135577m, Math.Round(result, 9));
        }

        [TestMethod]
        public void CalculateMaleCoefficient2()
        {
            var sut = new WilksCalculatorFactory().Build();

            var result = sut.Coefficient(Sex.Male, 197.6m);
            Assert.AreEqual(0.6397389402m, Math.Round(result, 10));
        }

        [TestMethod]
        public void CalculateFemaleCoefficient()
        {
            var sut = new WilksCalculatorFactory().Build();

            var result = sut.Coefficient(Sex.Female, 142.6m);
            Assert.AreEqual(1.052925703m, Math.Round(result, 9));
        }

        [TestMethod]
        public void CalculateFemaleCoefficient2()
        {
            var sut = new WilksCalculatorFactory().Build();

            var result = sut.Coefficient(Sex.Female, 164.8m);
            Assert.AreEqual(0.952618962m, Math.Round(result, 9));
        }
    }
}