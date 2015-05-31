// --------------------------------
// <copyright file="CalculatorRequestDto.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/31/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator.Api.Models
{
    /// <summary>
    /// Data transfer object that specifies a contract for requesting relative strength calculations
    /// </summary>
    public class CalculatorRequestDto
    {
        /// <summary>
        /// Id specified by the client, this is returned in the response to aid the client in identifying the record
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The sex to use in the relative strength calculation
        /// </summary>
        public Sex Sex { get; set; }

        /// <summary>
        /// The body weight to use in the relative strength calculation
        /// </summary>
        public decimal BodyWeight { get; set; }

        /// <summary>
        /// The weight used to use in the relative strength calculation
        /// </summary>
        public decimal Weight { get; set; }
    }
}