// --------------------------------
// <copyright file="IWeightConverterService.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/24/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator.WeightConverter
{
    public interface IWeightConverterService
    {
        decimal ToPounds(decimal kilograms);

        decimal ToKilogram(decimal pounds);
    }
}