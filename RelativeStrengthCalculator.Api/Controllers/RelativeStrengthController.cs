// --------------------------------
// <copyright file="RelativeStrengthController.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/30/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator.Api.Controllers
{
    using System;
    using System.Web.Http;
    using System.Web.Http.Cors;

    using Dea.Utilities.Reflection;

    using global::RelativeStrengthCalculator.WeightConverter;

    [EnableCors("*", "*", "*")]
    [RoutePrefix("RelativeStrength")]
    public class RelativeStrengthController : ApiController
    {
        private readonly IRelativeStrengthCalculatorFactory _factory;

        public RelativeStrengthController()
            : this(new RelativeStrengthCalculatorFactory(new WeightConverterService(), new TypeLoader<RelativeStrengthCalculator>(new TypeLocator())))
        {
        }

        public RelativeStrengthController(IRelativeStrengthCalculatorFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            this._factory = factory;
        }

        [Route("{algorithm}/{units}/{sex}/{bodyWeight}")]
        public IHttpActionResult Get(CalculatorType algorithm, WeightUnit units, Sex sex, decimal bodyWeight)
        {
            var calc = this._factory.Build(algorithm, units);

            var result = new CoefficientDto { Coefficient = calc.Coefficient(sex, bodyWeight) };
            return this.Ok(result);
        }

        [Route("{algorithm}/{units}/{sex}/{bodyWeight}/{weight}")]
        public IHttpActionResult Get(CalculatorType algorithm, WeightUnit units, Sex sex, decimal bodyWeight, decimal weight)
        {
            var calc = this._factory.Build(algorithm, units);

            var result = new ScoreDto { Coefficient = calc.Coefficient(sex, bodyWeight), Score = calc.AdjustedTotal(sex, bodyWeight, weight) };

            return this.Ok(result);
        }

        private class CoefficientDto
        {
            public decimal Coefficient { get; set; }
        }

        private class ScoreDto
        {
            public decimal Coefficient { get; set; }

            public decimal Score { get; set; }
        }
    }

}