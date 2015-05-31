// --------------------------------
// <copyright file="ScoreDto.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/30/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator.Api.Models
{
    public class ScoreDto
    {
        public decimal Coefficient { get; set; }

        public decimal Score { get; set; }
    }
}