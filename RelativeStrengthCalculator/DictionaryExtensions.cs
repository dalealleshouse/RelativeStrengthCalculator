// --------------------------------
// <copyright file="DictionaryExtensions.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>06/06/2015</date>
// ---------------------------------
namespace RelativeStrengthCalculator
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public static class DictionaryExtensions
    {
        public static IReadOnlyDictionary<TKey, TValue> ToReadOnly<TKey, TValue>(this IDictionary<TKey, TValue> dictionary) => new ReadOnlyDictionary<TKey, TValue>(dictionary);
    }
}