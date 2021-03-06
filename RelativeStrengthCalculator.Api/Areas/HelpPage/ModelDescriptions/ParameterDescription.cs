// --------------------------------
// <copyright file="ParameterDescription.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/30/2015</date>
// ---------------------------------

#pragma warning disable 1591
namespace RelativeStrengthCalculator.Api.Areas.HelpPage.ModelDescriptions
{
    using System.Collections.ObjectModel;

    public class ParameterDescription
    {
        public ParameterDescription()
        {
            this.Annotations = new Collection<ParameterAnnotation>();
        }

        public Collection<ParameterAnnotation> Annotations { get; }

        public string Documentation { get; set; }

        public string Name { get; set; }

        public ModelDescription TypeDescription { get; set; }
    }
}