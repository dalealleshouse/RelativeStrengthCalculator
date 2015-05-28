// --------------------------------
// <copyright file="DecimalExtensions.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/24/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator
{
    using System;
    using System.Linq;

    public static class DecimalExtensions
    {
        public static decimal Power(this decimal num, int raiseToThePowerOf)
        {
            var temp = Enumerable.Repeat(num, Math.Abs(raiseToThePowerOf)).DefaultIfEmpty(1).Aggregate((sum, val) => sum * val);
            return raiseToThePowerOf < 0 ? 1 / temp : temp;
        }
    }
}