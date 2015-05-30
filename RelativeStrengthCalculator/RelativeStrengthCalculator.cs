// --------------------------------
// <copyright file="RelativeStrengthCalculator.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/24/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator
{
    using System;

    using global::RelativeStrengthCalculator.WeightConverter;

    public abstract class RelativeStrengthCalculator
    {
        protected RelativeStrengthCalculator(IWeightConverterService weightConverterService)
        {
            if (weightConverterService == null)
            {
                throw new ArgumentNullException(nameof(weightConverterService));
            }

            this.WeightConverterService = weightConverterService;
        }

        protected abstract WeightUnit BaseWeightUnit { get; }

        public abstract CalculatorType CalculatorType { get; }

        protected IWeightConverterService WeightConverterService { get; }

        public abstract decimal Coefficient(WeightUnit unit, Sex sex, decimal bodyWeight);

        public abstract decimal AdjustedTotal(WeightUnit unit, Sex sex, decimal bodyWeight, decimal total);

        protected decimal GetBaseWeight(WeightUnit desiredUnits, decimal weight) => this.WeightConverterService.Convert(desiredUnits, this.BaseWeightUnit, weight);
    }
}