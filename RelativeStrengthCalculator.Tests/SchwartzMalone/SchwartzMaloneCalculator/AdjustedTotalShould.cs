// --------------------------------
// <copyright file="AdjustedTotalShould.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/30/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator.Tests.SchwartzMalone.SchwartzMaloneCalculator
{
    using System;
    using System.Diagnostics;

    using global::RelativeStrengthCalculator.SchwartzMalone;
    using global::RelativeStrengthCalculator.Tests.Helpers;
    using global::RelativeStrengthCalculator.WeightConverter;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AdjustedTotalShould : CalculatorTestBase
    {
        [TestMethod]
        [DeploymentItem("SchwartzMalone\\SchwartzMaloneCalculator\\SchwartzMaloneTestData.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\SchwartzMaloneTestData.csv", "SchwartzMaloneTestData#csv",
            DataAccessMethod.Sequential)]
        public void GenerateCorrectTotal()
        {
            var sut = new SchwartzMaloneCalculator(new WeightConverterService(), WeightUnit.Pounds);
            var testCase = this.GetTestCase();
            Debug.WriteLine(testCase);

            var result = sut.AdjustedTotal(testCase.Sex, testCase.Weight, testCase.Total);
            Assert.AreEqual(testCase.Score, result);
        }

        [TestMethod]
        [DeploymentItem("SchwartzMalone\\SchwartzMaloneCalculator\\SchwartzMaloneKiloTestData.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\SchwartzMaloneKiloTestData.csv", "SchwartzMaloneKiloTestData#csv",
            DataAccessMethod.Sequential)]
        public void GenerateCorrectTotalForKilograms()
        {
            var sut = new SchwartzMaloneCalculator(new WeightConverterService(), WeightUnit.Kilograms);
            var testCase = this.GetTestCase();
            Debug.WriteLine(testCase);

            var result = sut.AdjustedTotal(testCase.Sex, testCase.Weight, testCase.Total);
            Assert.AreEqual(testCase.Score, Math.Round(result, 9));
        }
    }
}