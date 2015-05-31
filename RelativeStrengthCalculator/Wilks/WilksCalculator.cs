// --------------------------------
// <copyright file="WilksCalculator.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/24/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator.Wilks
{
    using System;

    using global::RelativeStrengthCalculator.WeightConverter;

    internal class WilksCalculator : RelativeStrengthCalculator
    {
        public WilksCalculator(IWeightConverterService weightConverterService, WeightUnit desiredWeightUnit)
            : base(weightConverterService, desiredWeightUnit)
        {
        }

        protected override WeightUnit BaseWeightUnit => WeightUnit.Kilograms;

        public override CalculatorType CalculatorType => CalculatorType.Wilks;

        public override decimal Coefficient(Sex sex, decimal bodyWeight)
        {
            var coefficients = this.BuildCoefficients(sex);
            var baseWeight = this.GetBaseWeight(bodyWeight);

            return 500
                   / (coefficients.A + (coefficients.B * baseWeight) + (coefficients.C * baseWeight.Power(2)) + (coefficients.D * baseWeight.Power(3))
                      + (coefficients.E * baseWeight.Power(4)) + (coefficients.F * baseWeight.Power(5)));
        }

        private Coefficients BuildCoefficients(Sex sex)
        {
            switch (sex)
            {
                case Sex.Male:
                    return new Coefficients
                               {
                                   A = new decimal(-216.0475144),
                                   B = new decimal(16.2606339),
                                   C = new decimal(-0.002388645),
                                   D = new decimal(-0.00113732),
                                   E = new decimal(7.01863E-06),
                                   F = new decimal(-1.291E-08)
                               };
                case Sex.Female:
                    return new Coefficients
                               {
                                   A = new decimal(594.31747775582),
                                   B = new decimal(-27.23842536447),
                                   C = new decimal(0.82112226871),
                                   D = new decimal(-0.00930733913),
                                   E = new decimal(0.00004731582),
                                   F = new decimal(-0.00000009054)
                               };
                default:
                    throw new ArgumentOutOfRangeException(nameof(sex));
            }
        }

        private class Coefficients
        {
            public decimal A { get; set; }

            public decimal B { get; set; }

            public decimal C { get; set; }

            public decimal D { get; set; }

            public decimal E { get; set; }

            public decimal F { get; set; }
        }
    }
}