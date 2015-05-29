// --------------------------------
// <copyright file="ConvertShould.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/29/2015</date>
// ---------------------------------
namespace RelativeStrengthCalculator.Tests.WeightConverterService
{
    using System;

    using AssertExLib;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ConvertShould : WeightConverterServiceTestBase
    {
        [TestMethod]
        public void ReturnSameUnitIfFromAndToAreTheSame()
        {
            const decimal Expected = 23.69916456465m;

            var result = this.Sut.Convert(WeightUnit.Kilograms, WeightUnit.Kilograms, Expected);
            Assert.AreEqual(Expected, result);

            result = this.Sut.Convert(WeightUnit.Pounds, WeightUnit.Pounds, Expected);
            Assert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void ThrowIfFromOrToIsInvalid()
        {
            AssertEx.Throws<InvalidOperationException>(() => this.Sut.Convert(WeightUnit.Invalid, WeightUnit.Invalid, 1));
            AssertEx.Throws<InvalidOperationException>(() => this.Sut.Convert(WeightUnit.Invalid, WeightUnit.Pounds, 1));
            AssertEx.Throws<InvalidOperationException>(() => this.Sut.Convert(WeightUnit.Pounds, WeightUnit.Invalid, 1));
        }

        [TestMethod]
        public void ConvertKilogramToPounds()
        {
            var result = this.Sut.Convert(WeightUnit.Kilograms, WeightUnit.Pounds, 1);
            Assert.AreEqual(2.204622622m, Math.Round(result, 9));

            result = this.Sut.Convert(WeightUnit.Kilograms, WeightUnit.Pounds, 2175);
            Assert.AreEqual(4795.054203m, Math.Round(result, 6));

            result = this.Sut.Convert(WeightUnit.Kilograms, WeightUnit.Pounds, 41);
            Assert.AreEqual(90.3895275m, Math.Round(result, 7));
        }

        [TestMethod]
        public void ConvertPoundsToKilograms()
        {
            var result = this.Sut.Convert(WeightUnit.Pounds, WeightUnit.Kilograms, 1);
            Assert.AreEqual(0.45359237m, Math.Round(result, 9));

            result = this.Sut.Convert(WeightUnit.Pounds, WeightUnit.Kilograms, 4795);
            Assert.AreEqual(2174.975414m, Math.Round(result, 6));

            result = this.Sut.Convert(WeightUnit.Pounds, WeightUnit.Kilograms, 90);
            Assert.AreEqual(40.8233133m, Math.Round(result, 7));
        }
    }
}