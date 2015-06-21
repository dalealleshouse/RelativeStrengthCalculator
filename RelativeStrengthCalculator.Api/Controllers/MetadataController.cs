// --------------------------------
// <copyright file="MetadataController.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>06/06/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator.Api.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using System.Web.Http.Description;

    /// <summary>
    /// Provides meta data for relative strength requests
    /// </summary>
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/metadata")]
    public class MetadataController : ApiController
    {
        /// <summary>
        /// Key value pairs representing all formulas supported by the relative strength calculator
        /// </summary>
        /// <returns>Dictionary containing all supported formulas</returns>
        [ResponseType(typeof(Dictionary<int, string>))]
        [Route("formulas")]
        public IHttpActionResult GetFormulas() => this.Ok(EnumExtensions.GetDictionary<Formula>());

        /// <summary>
        /// Key value pairs representing all weight units supported by the relative strength calculator
        /// </summary>
        /// <returns>Dictionary containing all supported weight units</returns>
        [ResponseType(typeof(Dictionary<int, string>))]
        [Route("weightunits")]
        public IHttpActionResult GetWeightUnits() => this.Ok(EnumExtensions.GetDictionary<WeightUnit>());

        /// <summary>
        /// Key value pairs representing sexes used by the relative strength calculator
        /// </summary>
        /// <returns>Dictionary containing Sexes</returns>
        [ResponseType(typeof(Dictionary<int, string>))]
        [Route("sexes")]
        public IHttpActionResult GetSexes() => this.Ok(EnumExtensions.GetDictionary<Sex>());
    }
}