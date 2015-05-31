// --------------------------------
// <copyright file="GetShould.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/30/2015</date>
// ---------------------------------
namespace RelativeStrengthCalculator.Api.Tests.Controllers.RelativeStrengthController
{
    using System.Web.Http.Results;

    using global::RelativeStrengthCalculator.Api.Controllers;
    using global::RelativeStrengthCalculator.WeightConverter;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class GetShould
    {
        private const decimal MockCoefficient = 5.635m;
        private const decimal MockTotal = 6.535m;

        [TestMethod]
        public void GenerateCoefficient()
        {
            var factory = new Mock<IRelativeStrengthCalculatorFactory>();
            factory.Setup(f => f.Build(It.IsAny<CalculatorType>(), It.IsAny<WeightUnit>())).Returns(new MockCalculator());

            var sut = new RelativeStrengthController(factory.Object);

            var result = sut.Get(CalculatorType.Invalid, WeightUnit.Invalid, Sex.Invalid, 10m);

            var typedResult = result as OkNegotiatedContentResult<RelativeStrengthController.CoefficientDto>;
            Assert.IsNotNull(typedResult);
            Assert.AreEqual(MockCoefficient, typedResult.Content.Coefficient);
        }

        [TestMethod]
        public void GenerateTotal()
        {
            var factory = new Mock<IRelativeStrengthCalculatorFactory>();
            factory.Setup(f => f.Build(It.IsAny<CalculatorType>(), It.IsAny<WeightUnit>())).Returns(new MockCalculator());

            var sut = new RelativeStrengthController(factory.Object);

            var result = sut.Get(CalculatorType.Invalid, WeightUnit.Invalid, Sex.Invalid, 10m, 10m);

            var typedResult = result as OkNegotiatedContentResult<RelativeStrengthController.ScoreDto>;
            Assert.IsNotNull(typedResult);
            Assert.AreEqual(MockCoefficient, typedResult.Content.Coefficient);
            Assert.AreEqual(MockTotal, typedResult.Content.Score);
        }

        private class MockCalculator : RelativeStrengthCalculator
        {
            public MockCalculator()
                : base(new WeightConverterService(), WeightUnit.Invalid)
            {
            }

            protected override WeightUnit BaseWeightUnit => WeightUnit.Invalid;

            public override CalculatorType CalculatorType => CalculatorType.Invalid;

            public override decimal Coefficient(Sex sex, decimal bodyWeight) => MockCoefficient;

            public override decimal AdjustedTotal(Sex sex, decimal bodyWeight, decimal total) => MockTotal;
        }
    }
}