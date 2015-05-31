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
        protected RelativeStrengthCalculator(IWeightConverterService weightConverterService, WeightUnit desiredWeightUnit)
        {
            if (weightConverterService == null)
            {
                throw new ArgumentNullException(nameof(weightConverterService));
            }

            this.WeightConverterService = weightConverterService;
            this.DesiredWeightUnit = desiredWeightUnit;
        }

        protected abstract WeightUnit BaseWeightUnit { get; }

        public abstract CalculatorType CalculatorType { get; }

        protected IWeightConverterService WeightConverterService { get; }

        protected WeightUnit DesiredWeightUnit { get; set; }

        public abstract decimal Coefficient(Sex sex, decimal bodyWeight);

        public virtual decimal AdjustedTotal(Sex sex, decimal bodyWeight, decimal total)
        {
            var coefficient = this.Coefficient(sex, bodyWeight);
            var baseWeight = this.GetBaseWeight(total);
            return coefficient * baseWeight;
        }

        protected decimal GetBaseWeight(decimal weight) => this.WeightConverterService.Convert(this.DesiredWeightUnit, this.BaseWeightUnit, weight);
    }
}