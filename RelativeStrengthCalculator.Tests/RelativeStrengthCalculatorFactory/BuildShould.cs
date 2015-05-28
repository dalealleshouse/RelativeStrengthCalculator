// --------------------------------
// <copyright file="BuildShould.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/27/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator.Tests.RelativeStrengthCalculatorFactory
{
    using Dea.Utilities.Reflection;

    using DotNetTestHelper;

    using global::RelativeStrengthCalculator.SchwartzMalone;
    using global::RelativeStrengthCalculator.WeightConverter;
    using global::RelativeStrengthCalculator.Wilks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using RelativeStrengthCalculatorFactory = global::RelativeStrengthCalculator.RelativeStrengthCalculatorFactory;

    [TestClass]
    public class BuildShould
    {
        private RelativeStrengthCalculatorFactory _sut;

        [TestInitialize]
        public void Init()
        {
            this._sut =
                new SutBuilder<RelativeStrengthCalculatorFactory>().AddDependency(new WeightConverterService())
                    .AddDependency(new TypeLoader<RelativeStrengthCalculator>(new TypeLocator()))
                    .Build();
        }

        [TestMethod]
        public void CreateSchwartzMaloneCalculator()
        {
            var result = this._sut.Build(CalculatorType.SchwartzMalone);
            Assert.IsInstanceOfType(result, typeof(SchwartzMaloneCalculator));
        }

        [TestMethod]
        public void CreateWilksCalculator()
        {
            var result = this._sut.Build(CalculatorType.Wilks);
            Assert.IsInstanceOfType(result, typeof(WilksCalculator));
        }
    }
}