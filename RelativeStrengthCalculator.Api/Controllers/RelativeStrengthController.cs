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
    using System.Collections.Generic;
    using System.Linq;
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
        /// <a target="_blank" href="http://rscalc.azurewebsites.net/Wilks/Pounds/Female/100.25">http://rscalc.azurewebsites.net/Wilks/Pounds/Female/100.25</a> - This will result in a bad request error.<br />
        /// <a target="_blank" href="http://rscalc.azurewebsites.net/Wilks/Pounds/Female/100.25/">http://rscalc.azurewebsites.net/Wilks/Pounds/Female/100.25<mark>/</mark></a> - This is valid.
        /// </div>
        /// </example>
        /// </summary>
        /// <param name="formula">Formula to use for relative strength calculations</param>
        /// <param name="units">WeightUnit indicating the unit that the bodyWeight parameter will be in</param>
        /// <param name="sex">Sex indicating the sex to use in the relative strength calculation</param>
        /// <param name="bodyWeight">Body weight to use in the coefficient calculation</param>
        /// <returns>CoefficientDto containing the calculated coefficient</returns>
        [ResponseType(typeof(CoefficientDto))]
        [Route("{formula}/{units}/{sex}/{bodyWeight}")]
        public IHttpActionResult Get(Formula formula, WeightUnit units, Sex sex, decimal bodyWeight)
        {
            var calc = this._factory.Build(formula, units);

            var result = CalculatorResultFactory.BuildCoefficient(calc, new CalculatorRequestDto { Sex = sex, BodyWeight = bodyWeight });
            return this.Ok(result);
        }

        /// <summary>
        /// Calculates the coefficient and score given the specified parameters.<br />
        /// <b>Note:</b> If the weight parameter has a decimal point, the request needs to end with a <mark>/</mark><br />
        /// <example>
        /// <div class="well">
        /// <a target="_blank" href="http://rscalc.azurewebsites.net/Wilks/Pounds/Female/100/200.25">http://rscalc.azurewebsites.net/Wilks/Pounds/Female/100/200.25</a> - This will result in a bad request error.<br />
        /// <a target="_blank" href="http://rscalc.azurewebsites.net/Wilks/Pounds/Female/100/200.25/">http://rscalc.azurewebsites.net/Wilks/Pounds/Female/100/200.25<mark>/</mark></a> - This is valid.
        /// </div>
        /// </example>
        /// </summary>
        /// <param name="formula">Formula to use for relative strength calculations</param>
        /// <param name="units">WeightUnit indicating the unit that the weight and bodyWeight parameters will be in</param>
        /// <param name="sex">Sex indicating the sex to use in the relative strength calculation</param>
        /// <param name="bodyWeight">Body weight to use in the coefficient calculation</param>
        /// <param name="weight">Weight to use in the score calculation</param>
        /// <returns>ScoreDto containing the calculated coefficient and score</returns>
        [ResponseType(typeof(ScoreDto))]
        [Route("{formula}/{units}/{sex}/{bodyWeight}/{weight}")]
        public IHttpActionResult Get(Formula formula, WeightUnit units, Sex sex, decimal bodyWeight, decimal weight)
        {
            var calc = this._factory.Build(formula, units);
            var result = CalculatorResultFactory.BuildScore(calc, new CalculatorRequestDto { Sex = sex, BodyWeight = bodyWeight, Weight = weight });
            return this.Ok(result);
        }

        /// <summary>
        /// Calculates the coefficient and score for each object in the requests collection.<br />
        /// If you want just coefficients, set the weight property of the request objects to 0.
        /// </summary>
        /// <param name="formula">Formula to use for relative strength calculations</param>
        /// <param name="units">WeightUnit indicating the unit that the weight and bodyWeight parameters will be in</param>
        /// <param name="requests">Collection of ScoreDto objects with the coefficient and score populated</param>
        /// <returns>Collection of CalculatorRequestDto objects to perform calculations on</returns>
        [ResponseType(typeof(IEnumerable<ScoreDto>))]
        [Route("{formula}/{units}")]
        public IHttpActionResult Post(Formula formula, WeightUnit units, [FromBody] IEnumerable<CalculatorRequestDto> requests)
        {
            var calc = this._factory.Build(formula, units);
            var result = requests.Select(r => CalculatorResultFactory.BuildScore(calc, r));
            return this.Ok(result);
        }
    }
}