// --------------------------------
// <copyright file="MockCalculator.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/31/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator.Api.Tests.Controllers.RelativeStrengthController
{
    using global::RelativeStrengthCalculator.WeightConverter;

    public class MockCalculator : RelativeStrengthCalculator
    {
        public MockCalculator()
            : base(new WeightConverterService(), WeightUnit.Invalid)
        {
            this.MockCoefficient = 10m;
            this.MockScore = 10m;
        }

        public decimal MockCoefficient { get; set; }

        public decimal MockScore { get; set; }

        protected override WeightUnit BaseWeightUnit => WeightUnit.Invalid;

        public override Formula CalculatorType => Formula.Invalid;

        public override decimal Coefficient(Sex sex, decimal bodyWeight) => this.MockCoefficient;

        public override decimal Score(Sex sex, decimal bodyWeight, decimal total) => this.MockScore;
    }
}