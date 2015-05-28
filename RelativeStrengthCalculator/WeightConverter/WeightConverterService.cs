// --------------------------------
// <copyright file="WeightConverterService.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/24/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator.WeightConverter
{
    public class WeightConverterService : IWeightConverterService
    {
        private const decimal Kg = 0.45359237m;

        public decimal ToPounds(decimal kilograms) => kilograms / Kg;

        public decimal ToKilogram(decimal pounds) => pounds * Kg;
    }
}