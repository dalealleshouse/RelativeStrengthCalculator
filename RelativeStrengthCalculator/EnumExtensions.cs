// --------------------------------
// <copyright file="EnumExtensions.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>06/06/2015</date>
// ---------------------------------
namespace RelativeStrengthCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class EnumExtensions
    {
        public static IDictionary<int, string> GetDictionary<T>() where T : struct, IConvertible
        {
            var type = typeof(T);
            if (!type.IsEnum)
            {
                throw new InvalidOperationException("This method can only be used on enum types");
            }

            return Enum.GetValues(type).Cast<object>().Where(o => (int)o != 0).ToDictionary(value => (int)value, value => value.ToString());
        }
    }
}