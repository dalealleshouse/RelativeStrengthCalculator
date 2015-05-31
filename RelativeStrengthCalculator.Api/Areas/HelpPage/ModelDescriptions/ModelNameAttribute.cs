// --------------------------------
// <copyright file="ModelNameAttribute.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/30/2015</date>
// ---------------------------------

#pragma warning disable 1591
namespace RelativeStrengthCalculator.Api.Areas.HelpPage.ModelDescriptions
{
    using System;

    /// <summary>
    /// Use this attribute to change the name of the <see cref="ModelDescription"/> generated for a type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum, Inherited = false)]
    public sealed class ModelNameAttribute : Attribute
    {
        public ModelNameAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}