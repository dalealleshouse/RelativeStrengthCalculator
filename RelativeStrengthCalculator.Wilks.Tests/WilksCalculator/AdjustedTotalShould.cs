// --------------------------------
// <copyright file="AdjustedTotalShould.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/24/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator.Wilks.Tests.WilksCalculator
{
    using System;
    using System.Diagnostics;

    using DotNetTestHelper;

    using global::RelativeStrengthCalculator.Tests.Helpers;
    using global::RelativeStrengthCalculator.WeightConverter;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using WilksCalculator = global::RelativeStrengthCalculator.Wilks.WilksCalculator;

    [TestClass]
    public class AdjustedTotalShould : CalculatorTestBase
    {
        // All data is tested against this page
        // http://tsampa.org/training/scripts/relative_strength/
        [TestMethod]
        [DeploymentItem("WilksCalculator\\TestData.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential)]
        public void GenerateCorrectTotal()
        {
            var sut = new SutBuilder<WilksCalculator>().AddDependency(new WeightConverterService()).Build();
            var testCase = this.GetTestCase();
            Debug.WriteLine(testCase);

            var result = sut.AdjustedTotal(WeightUnit.Pounds, testCase.Sex, testCase.Weight, testCase.Total);
            Assert.AreEqual(testCase.Score, Math.Round(result, 7));
        }

        [TestMethod]
        [DeploymentItem("WilksCalculator\\KiloTestData.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\KiloTestData.csv", "KiloTestData#csv", DataAccessMethod.Sequential)]
        public void GenerateCorrectTotalForKilo()
        {
            var sut = new SutBuilder<WilksCalculator>().AddDependency(new WeightConverterService()).Build();
            var testCase = this.GetTestCase();
            Debug.WriteLine(testCase);

            var result = sut.AdjustedTotal(WeightUnit.Kilograms, testCase.Sex, testCase.Weight, testCase.Total);
            Assert.AreEqual(testCase.Score, Math.Round(result, 9));
        }
    }
}