// --------------------------------
// <copyright file="CoefficientShould.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/30/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator.Tests.Wilks.WilksCalculator
{
    using System;
    using System.Diagnostics;

    using global::RelativeStrengthCalculator.Tests.Helpers;
    using global::RelativeStrengthCalculator.WeightConverter;
    using global::RelativeStrengthCalculator.Wilks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CoefficientShould : CalculatorTestBase
    {
        // All data is tested against this page
        // http://tsampa.org/training/scripts/relative_strength/
        [TestMethod]
        [DeploymentItem("Wilks\\WilksCalculator\\WilksTestData.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\WilksTestData.csv", "WilksTestData#csv", DataAccessMethod.Sequential)]
        public void GenerateCorrectCoefficient()
        {
            var sut = new WilksCalculator(new WeightConverterService(), WeightUnit.Pounds);
            var testCase = this.GetTestCase();
            Debug.WriteLine(testCase);

            var result = sut.Coefficient(testCase.Sex, testCase.Weight);
            Assert.AreEqual(testCase.Coefficient, Math.Round(result, 9));
        }

        [TestMethod]
        [DeploymentItem("Wilks\\WilksCalculator\\WilksKiloTestData.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\WilksKiloTestData.csv", "WilksKiloTestData#csv", DataAccessMethod.Sequential)]
        public void GenerateCorrectCoefficientForKilograms()
        {
            var sut = new WilksCalculator(new WeightConverterService(), WeightUnit.Kilograms);
            var testCase = this.GetTestCase();
            Debug.WriteLine(testCase);

            var result = sut.Coefficient(testCase.Sex, testCase.Weight);
            Assert.AreEqual(testCase.Coefficient, Math.Round(result, 9));
        }
    }
}