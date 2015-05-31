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

        /// <summary>
        /// Creates an instance of <see cref="RelativeStrengthController"/> with default implementation of constructor parameters
        /// </summary>
        public RelativeStrengthController()
            : this(new RelativeStrengthCalculatorFactory(new WeightConverterService(), new TypeLoader<RelativeStrengthCalculator>(new TypeLocator())))
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="RelativeStrengthController"/>
        /// </summary>
        /// <param name="factory"><see cref="IRelativeStrengthCalculatorFactory"/> responsible for generating <see cref="RelativeStrengthCalculator"/> implementations</param>
        /// <exception cref="ArgumentNullException"></exception>
        public RelativeStrengthController(IRelativeStrengthCalculatorFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            this._factory = factory;
        }

        /// <summary>
        /// Calculates the coefficient given the specified parameters.<br />
        /// <b>Note:</b> If the bodyWeight parameter has a decimal point, the request needs to end with a <mark>/</mark><br />
        /// <example>
        /// <div class="well">
        /// <a target="_blank" href="http://relativestrengthcalculatorapi.azurewebsites.net/1/1/1/100.25">http://relativestrengthcalculatorapi.azurewebsites.net/1/1/1/100.25</a> - This will result in a bad request error.<br />
        /// <a target="_blank" href="http://relativestrengthcalculatorapi.azurewebsites.net/1/1/1/100.25/">http://relativestrengthcalculatorapi.azurewebsites.net/1/1/1/100.25<mark>/</mark></a> - This is valid.
        /// </div>
        /// </example>
        /// </summary>
        /// <param name="algorithm">CalculatorType indicating which algorithm to use for relative strength calculations</param>
        /// <param name="units">WeightUnit indicating the unit that the bodyWeight parameter will be in</param>
        /// <param name="sex">Sex indicating the sex to use in the relative strength calculation</param>
        /// <param name="bodyWeight">Body weight to use in the coefficient calculation</param>
        /// <returns>CoefficientDto containing the calculated coefficient</returns>
        [ResponseType(typeof(CoefficientDto))]
        [Route("{algorithm}/{units}/{sex}/{bodyWeight}")]
        public IHttpActionResult Get(CalculatorType algorithm, WeightUnit units, Sex sex, decimal bodyWeight)
        {
            var calc = this._factory.Build(algorithm, units);

            var result = new CoefficientDto { Coefficient = calc.Coefficient(sex, bodyWeight) };
            return this.Ok(result);
        }

        /// <summary>
        /// Calculates the coefficient and score given the specified parameters.<br />
        /// <b>Note:</b> If the weight parameter has a decimal point, the request needs to end with a <mark>/</mark><br />
        /// <example>
        /// <div class="well">
        /// <a target="_blank" href="http://relativestrengthcalculatorapi.azurewebsites.net/1/1/1/100/200.25">http://relativestrengthcalculatorapi.azurewebsites.net/1/1/1/100/200.25</a> - This will result in a bad request error.<br />
        /// <a target="_blank" href="http://relativestrengthcalculatorapi.azurewebsites.net/1/1/1/100/200.25/">http://relativestrengthcalculatorapi.azurewebsites.net/1/1/1/100/200.25<mark>/</mark></a> - This is valid.
        /// </div>
        /// </example>
        /// </summary>
        /// <param name="algorithm">CalculatorType indicating which algorithm to use for relative strength calculations</param>
        /// <param name="units">WeightUnit indicating the unit that the weight and bodyWeight parameters will be in</param>
        /// <param name="sex">Sex indicating the sex to use in the relative strength calculation</param>
        /// <param name="bodyWeight">Body weight to use in the coefficient calculation</param>
        /// <param name="weight">Weight to use in the score calculation</param>
        /// <returns>ScoreDto containing the calculated coefficient and score</returns>
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