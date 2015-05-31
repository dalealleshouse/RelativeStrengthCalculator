// --------------------------------
// <copyright file="CalculatorResultFactory.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/31/2015</date>
// ---------------------------------

#pragma warning disable 1591

namespace RelativeStrengthCalculator.Api.Models
{
    public static class CalculatorResultFactory
    {
        public static ScoreDto BuildScore(RelativeStrengthCalculator calc, CalculatorRequestDto request)
            =>
                new ScoreDto
                    {
                        Id = request.Id,
                        Sex = request.Sex,
                        BodyWeight = request.BodyWeight,
                        Weight = request.Weight,
                        Coefficient = calc.Coefficient(request.Sex, request.BodyWeight),
                        Score = calc.Score(request.Sex, request.BodyWeight, request.Weight)
                    }

;

        public static CoefficientDto BuildCoefficient(RelativeStrengthCalculator calc, CalculatorRequestDto request)
            =>
                new CoefficientDto
                    {
                        Id = request.Id,
                        Sex = request.Sex,
                        BodyWeight = request.BodyWeight,
                        Weight = request.Weight,
                        Coefficient = calc.Coefficient(request.Sex, request.BodyWeight)
                    }

;
    }
}