// --------------------------------
// <copyright file="IRelativeStrengthCalculatorFactory.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/24/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator
{
    public interface IRelativeStrengthCalculatorFactory
    {
        RelativeStrengthCalculator Build(Formula calculatorType, WeightUnit desiredUnit);
    }
}