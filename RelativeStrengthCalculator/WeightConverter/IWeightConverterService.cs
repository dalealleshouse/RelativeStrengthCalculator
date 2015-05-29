// --------------------------------
// <copyright file="IWeightConverterService.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/24/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator.WeightConverter
{
    using System;

    public interface IWeightConverterService
    {
        decimal Convert(WeightUnit from, WeightUnit to, decimal weight);

        [Obsolete("Migrated to Convert(WeightUnit, WeightUnit)")]
        decimal ToPounds(decimal kilograms);

        [Obsolete("Migrated to Convert(WeightUnit, WeightUnit)")]
        decimal ToKilogram(decimal pounds);
    }
}