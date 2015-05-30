// --------------------------------
// <copyright file="WeightConverterService.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/24/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator.WeightConverter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class WeightConverterService : IWeightConverterService
    {
        private static readonly Lazy<HashSet<Multiplier>> LazyMultipliers = new Lazy<HashSet<Multiplier>>(BuildMultipliers);

        public decimal Convert(WeightUnit from, WeightUnit to, decimal weight)
        {
            if (from == WeightUnit.Invalid || to == WeightUnit.Invalid)
            {
                throw new InvalidOperationException("Invalid WeightUnit");
            }

            var m = FindMultiplier(from, to);
            return weight * m.ConversionMultiplier;
        }

        public decimal ToPounds(decimal kilograms) => this.Convert(WeightUnit.Kilograms, WeightUnit.Pounds, kilograms);

        public decimal ToKilogram(decimal pounds) => this.Convert(WeightUnit.Pounds, WeightUnit.Kilograms, pounds);

        private static Multiplier FindMultiplier(WeightUnit from, WeightUnit to)
        {
            var mu = LazyMultipliers.Value.FirstOrDefault(m => m.From == from && m.To == to);

            if (mu == null)
            {
                throw new InvalidOperationException($"Cannot find multiplier for {from} to {to}");
            }

            return mu;
        }

        private static HashSet<Multiplier> BuildMultipliers()
            =>
                new HashSet<Multiplier>
                    {
                        new Multiplier(WeightUnit.Pounds, WeightUnit.Pounds, 1),
                        new Multiplier(WeightUnit.Kilograms, WeightUnit.Kilograms, 1),
                        new Multiplier(WeightUnit.Pounds, WeightUnit.Kilograms, 0.45359237m),
                        new Multiplier(WeightUnit.Kilograms, WeightUnit.Pounds, 2.204622622m)
                    }

;

        private class Multiplier
        {
            public Multiplier(WeightUnit from, WeightUnit to, decimal conversionMultiplier)
            {
                this.From = from;
                this.To = to;
                this.ConversionMultiplier = conversionMultiplier;
            }

            public WeightUnit From { get; }

            public WeightUnit To { get; }

            public decimal ConversionMultiplier { get; }
        }
    }
}