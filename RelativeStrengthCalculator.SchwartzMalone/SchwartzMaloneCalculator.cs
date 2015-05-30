﻿// --------------------------------
// <copyright file="SchwartzMaloneCalculator.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/24/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator.SchwartzMalone
{
    using System;

    using global::RelativeStrengthCalculator.WeightConverter;

    public class SchwartzMaloneCalculator : RelativeStrengthCalculator
    {
        public SchwartzMaloneCalculator(IWeightConverterService weightConverterService)
            : base(weightConverterService)
        {
        }

        protected override WeightUnit BaseWeightUnit => WeightUnit.Kilograms;

        public override CalculatorType CalculatorType => CalculatorType.SchwartzMalone;

        public override decimal Coefficient(WeightUnit unit, Sex sex, decimal bodyWeight)
        {
            var table = SchwartzMaloneLookUpTable.GetLookupTable(sex);
            var baseWeight = this.GetBaseWeight(unit, bodyWeight);
            var weight = (double)Math.Round(baseWeight, 1);

            return !table.ContainsKey(weight) ? 0 : table[weight];
        }

        public override decimal AdjustedTotal(WeightUnit unit, Sex sex, decimal bodyWeight, decimal total)
        {
            var coefficient = this.Coefficient(unit, sex, bodyWeight);

            // Normally you would have to convert to the base weight unit before calculating the total
            // Unfortunately, my coefficient tables are in kilo but the real base unit for Schwartz\Malone is lbs
            var weighInPounds = this.WeightConverterService.Convert(unit, WeightUnit.Pounds, total);
            return coefficient * weighInPounds;
        }
    }
}