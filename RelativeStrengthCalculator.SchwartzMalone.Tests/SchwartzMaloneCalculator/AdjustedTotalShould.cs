// --------------------------------
// <copyright file="AdjustedTotalShould.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/24/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator.SchwartzMalone.Tests.SchwartzMaloneCalculator
{
    using System.Diagnostics;

    using DotNetTestHelper;

    using global::RelativeStrengthCalculator.Tests.Helpers;
    using global::RelativeStrengthCalculator.WeightConverter;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SchwartzMaloneCalculator = global::RelativeStrengthCalculator.SchwartzMalone.SchwartzMaloneCalculator;

    [TestClass]
    public class AdjustedTotalShould : CalculatorTestBase
    {
        [TestMethod]
        [DeploymentItem("SchwartzMaloneCalculator\\TestData.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential)]
        public void GenerateCorrectTotal()
        {
            var sut = new SutBuilder<SchwartzMaloneCalculator>().AddDependency(new WeightConverterService()).Build();
            var testCase = this.GetTestCase();
            Debug.WriteLine(testCase);

            var result = sut.AdjustedTotal(WeightUnit.Pounds, testCase.Sex, testCase.Weight, testCase.Total);
            Assert.AreEqual(testCase.Score, result);
        }

        [TestMethod]
        [DeploymentItem("SchwartzMaloneCalculator\\KiloTestData.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\KiloTestData.csv", "KiloTestData#csv", DataAccessMethod.Sequential)]
        public void GenerateCorrectTotalForKilograms()
        {
            var sut = new SutBuilder<SchwartzMaloneCalculator>().AddDependency(new WeightConverterService()).Build();
            var testCase = this.GetTestCase();
            Debug.WriteLine(testCase);

            var result = sut.AdjustedTotal(WeightUnit.Kilograms, testCase.Sex, testCase.Weight, testCase.Total);
            Assert.AreEqual(testCase.Score, result);
        }
    }
}