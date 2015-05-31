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
    using System.Web.Http.Description;

    using Dea.Utilities.Reflection;

    using global::RelativeStrengthCalculator.Api.Models;
    using global::RelativeStrengthCalculator.WeightConverter;

    /// <summary>
    /// Provides relative strength calculations
    /// </summary>
    [EnableCors("*", "*", "*")]
    [RoutePrefix("")]
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

        /// <summary>
        /// bar
        /// </summary>
        /// <param name="algorithm"></param>
        /// <param name="units"></param>
        /// <param name="sex"></param>
        /// <param name="bodyWeight"></param>
        /// <returns>Some data here</returns>
        [ResponseType(typeof(CoefficientDto))]
        [Route("{algorithm}/{units}/{sex}/{bodyWeight}")]
        public IHttpActionResult Get(CalculatorType algorithm, WeightUnit units, Sex sex, decimal bodyWeight)
        {
            var calc = this._factory.Build(algorithm, units);

            var result = new CoefficientDto { Coefficient = calc.Coefficient(sex, bodyWeight) };
            return this.Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithm"></param>
        /// <param name="units"></param>
        /// <param name="sex"></param>
        /// <param name="bodyWeight"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        [ResponseType(typeof(ScoreDto))]
        [Route("{algorithm}/{units}/{sex}/{bodyWeight}/{weight}")]
        public IHttpActionResult Get(CalculatorType algorithm, WeightUnit units, Sex sex, decimal bodyWeight, decimal weight)
        {
            var calc = this._factory.Build(algorithm, units);

            var result = new ScoreDto { Coefficient = calc.Coefficient(sex, bodyWeight), Score = calc.AdjustedTotal(sex, bodyWeight, weight) };

            return this.Ok(result);
        }

    }
}