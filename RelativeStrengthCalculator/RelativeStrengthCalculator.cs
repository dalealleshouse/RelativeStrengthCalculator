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

        public abstract CalculatorType CalculatorType { get; }

        protected IWeightConverterService WeightConverterService { get; }

        public abstract decimal Coefficient(Sex sex, decimal bodyWeightInPounds);

        public abstract decimal AdjustedTotal(Sex sex, decimal bodyWeightInPounds, decimal totalInPounds);
    }
}