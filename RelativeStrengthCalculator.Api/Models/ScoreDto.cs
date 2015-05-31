// --------------------------------
// <copyright file="ScoreDto.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/30/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator.Api.Models
{
    /// <summary>
    /// Data transfer object for coefficients and scores
    /// </summary>
    public class ScoreDto : CoefficientDto
    {
        /// <summary>
        /// Calculated relative strength score
        /// </summary>
        public decimal Score { get; set; }
    }
}