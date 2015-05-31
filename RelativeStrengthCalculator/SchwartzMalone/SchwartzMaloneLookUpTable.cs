// --------------------------------
// <copyright file="SchwartzMaloneLookUpTable.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/24/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator.SchwartzMalone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using global::RelativeStrengthCalculator.Properties;

    public static class SchwartzMaloneLookUpTable
    {
        private static readonly Lazy<IReadOnlyDictionary<double, decimal>> Men = new Lazy<IReadOnlyDictionary<double, decimal>>(BuildMen);

        private static readonly Lazy<IReadOnlyDictionary<double, decimal>> Women = new Lazy<IReadOnlyDictionary<double, decimal>>(BuildWomen);

        public static IReadOnlyDictionary<double, decimal> GetLookupTable(Sex sex)
        {
            switch (sex)
            {
                case Sex.Male:
                    return Men.Value;
                case Sex.Female:
                    return Women.Value;
                default:
                    throw new ArgumentOutOfRangeException(nameof(sex));
            }
        }

        private static IReadOnlyDictionary<double, decimal> BuildMen()
            =>
                Resources.SwartzCoefficients.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Split(','))
                    .ToDictionary(a => Convert.ToDouble(a[0]), a => Convert.ToDecimal(a[1]));

        private static IReadOnlyDictionary<double, decimal> BuildWomen()
            =>
                Resources.MaloneCoefficients.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Split(','))
                    .ToDictionary(a => Convert.ToDouble(a[0]), a => Convert.ToDecimal(a[1]));
    }
}