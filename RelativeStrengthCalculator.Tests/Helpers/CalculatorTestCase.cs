// --------------------------------
// <copyright file="CalculatorTestCase.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/27/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator.Tests.Helpers
{
    public class CalculatorTestCase
    {
        public Sex Sex { get; set; }

        public decimal Weight { get; set; }

        public decimal Total { get; set; }

        public decimal Coefficient { get; set; }

        public decimal Score { get; set; }

        public override string ToString()
            => $"Sex = {this.Sex}\nWeight = {this.Weight}\nTotal = {this.Total}\nCoefficient = {this.Coefficient}\nScore = {this.Score}";
    }
}