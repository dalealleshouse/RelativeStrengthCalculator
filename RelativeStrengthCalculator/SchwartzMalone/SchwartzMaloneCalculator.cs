// --------------------------------
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

    internal class SchwartzMaloneCalculator : RelativeStrengthCalculator
    {
        public SchwartzMaloneCalculator(IWeightConverterService weightConverterService, WeightUnit desiredWeightUnit)
            : base(weightConverterService, desiredWeightUnit)
        {
        }

        protected override WeightUnit BaseWeightUnit => WeightUnit.Kilograms;

        public override Formula CalculatorType => Formula.SchwartzMalone;

        public override decimal Coefficient(Sex sex, decimal bodyWeight)
        {
            var table = SchwartzMaloneLookUpTable.GetLookupTable(sex);
            var baseWeight = this.GetBaseWeight(bodyWeight);
            var weight = (double)Math.Round(baseWeight, 1);

            return !table.ContainsKey(weight) ? 0 : table[weight];
        }

        public override decimal Score(Sex sex, decimal bodyWeight, decimal total)
        {
            var coefficient = this.Coefficient(sex, bodyWeight);

            // Normally you would have to convert to the base weight unit before calculating the total
            // Unfortunately, my coefficient tables are in kilo but the real base unit for Schwartz\Malone is lbs
            var weighInPounds = this.WeightConverterService.Convert(this.DesiredWeightUnit, WeightUnit.Pounds, total);
            return coefficient * weighInPounds;
        }
    }
}