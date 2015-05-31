// --------------------------------
// <copyright file="CoefficientDto.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/30/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator.Api.Models
{
    /// <summary>
    /// Data transfer object for coefficient calculations
    /// </summary>
    public class CoefficientDto : CalculatorRequestDto
    {
        /// <summary>
        /// Calculated coefficient value
        /// </summary>
        public decimal Coefficient { get; set; }
    }
}