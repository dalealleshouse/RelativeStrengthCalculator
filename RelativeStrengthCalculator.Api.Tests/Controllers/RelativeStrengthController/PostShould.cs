// --------------------------------
// <copyright file="PostShould.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/31/2015</date>
// ---------------------------------
namespace RelativeStrengthCalculator.Api.Tests.Controllers.RelativeStrengthController
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http.Results;

    using global::RelativeStrengthCalculator.Api.Controllers;
    using global::RelativeStrengthCalculator.Api.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class PostShould
    {
        [TestMethod]
        public void GenerateScores()
        {
            var request = new List<CalculatorRequestDto>()
                              {
                                  new CalculatorRequestDto { Id = "1", BodyWeight = 2m, Weight = 4m },
                                  new CalculatorRequestDto { Id = "2", BodyWeight = 3m, Weight = 3m },
                                  new CalculatorRequestDto { Id = "1", BodyWeight = 4m, Weight = 2m }
                              };

            var factory = new Mock<IRelativeStrengthCalculatorFactory>();
            factory.Setup(f => f.Build(It.IsAny<Formula>(), It.IsAny<WeightUnit>())).Returns(new MockCalculator());

            var sut = new RelativeStrengthController(factory.Object);
            var result = sut.Post(Formula.Invalid, WeightUnit.Invalid, request);

            var typedResult = result as OkNegotiatedContentResult<IEnumerable<ScoreDto>>;
            Assert.IsNotNull(typedResult);
            Assert.AreEqual(request.Count, typedResult.Content.Count());
        }

        [TestMethod]
        public void CopiesValuesFromRequest()
        {
            var testRequest = new CalculatorRequestDto { Id = "foo", Sex = Sex.Male, BodyWeight = 10m, Weight = 20m };
            const decimal MockCoefficient = 6.86m;
            const decimal MockScore = 5.698m;

            var request = new List<CalculatorRequestDto>() { testRequest };

            var factory = new Mock<IRelativeStrengthCalculatorFactory>();
            factory.Setup(f => f.Build(It.IsAny<Formula>(), It.IsAny<WeightUnit>()))
                .Returns(new MockCalculator() { MockCoefficient = MockCoefficient, MockScore = MockScore });

            var sut = new RelativeStrengthController(factory.Object);
            var result = sut.Post(Formula.Invalid, WeightUnit.Invalid, request);

            var typedResult = result as OkNegotiatedContentResult<IEnumerable<ScoreDto>>;
            Assert.IsNotNull(typedResult);

            var testResponse = typedResult.Content.First(r => r.Id == testRequest.Id);
            Assert.AreEqual(testRequest.Sex, testResponse.Sex);
            Assert.AreEqual(testRequest.BodyWeight, testResponse.BodyWeight);
            Assert.AreEqual(testRequest.Weight, testResponse.Weight);
            Assert.AreEqual(MockCoefficient, testResponse.Coefficient);
            Assert.AreEqual(MockScore, testResponse.Score);
        }
    }
}