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
    using global::RelativeStrengthCalculator.Api.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class GetShould
    {
        private const decimal MockCoefficient = 5.635m;

        private const decimal MockScore = 6.535m;

        [TestMethod]
        public void GenerateCoefficient()
        {
            var sut = BuildSut();

            var result = sut.Get(Formula.Invalid, WeightUnit.Invalid, Sex.Invalid, 10m);

            var typedResult = result as OkNegotiatedContentResult<CoefficientDto>;
            Assert.IsNotNull(typedResult);
            Assert.AreEqual(MockCoefficient, typedResult.Content.Coefficient);
        }

        [TestMethod]
        public void CopyValueFromCoefficientRequest()
        {
            const decimal Expected = 45m;
            const Sex ExpectedSex = Sex.Male;
            var sut = BuildSut();

            var result = sut.Get(Formula.Invalid, WeightUnit.Invalid, ExpectedSex, Expected);

            var typedResult = result as OkNegotiatedContentResult<CoefficientDto>;
            Assert.IsNotNull(typedResult);
            Assert.AreEqual(ExpectedSex, typedResult.Content.Sex);
            Assert.AreEqual(Expected, typedResult.Content.BodyWeight);
        }

        [TestMethod]
        public void GenerateScore()
        {
            var sut = BuildSut();

            var result = sut.Get(Formula.Invalid, WeightUnit.Invalid, Sex.Invalid, 10m, 10m);

            var typedResult = result as OkNegotiatedContentResult<ScoreDto>;
            Assert.IsNotNull(typedResult);
            Assert.AreEqual(MockCoefficient, typedResult.Content.Coefficient);
            Assert.AreEqual(MockScore, typedResult.Content.Score);
        }

        [TestMethod]
        public void CopyValueFromScoreRequest()
        {
            const decimal ExpectedBodyWeight = 45m;
            const decimal ExpectedWeight = 450m;
            const Sex ExpectedSex = Sex.Male;
            var sut = BuildSut();

            var result = sut.Get(Formula.Invalid, WeightUnit.Invalid, ExpectedSex, ExpectedBodyWeight, ExpectedWeight);

            var typedResult = result as OkNegotiatedContentResult<ScoreDto>;
            Assert.IsNotNull(typedResult);
            Assert.AreEqual(ExpectedSex, typedResult.Content.Sex);
            Assert.AreEqual(ExpectedBodyWeight, typedResult.Content.BodyWeight);
            Assert.AreEqual(ExpectedWeight, typedResult.Content.Weight);
        }

        private static RelativeStrengthController BuildSut()
        {
            var factory = new Mock<IRelativeStrengthCalculatorFactory>();
            factory.Setup(f => f.Build(It.IsAny<Formula>(), It.IsAny<WeightUnit>()))
                .Returns(new MockCalculator() { MockCoefficient = MockCoefficient, MockScore = MockScore });

            return new RelativeStrengthController(factory.Object);
        }
    }
}