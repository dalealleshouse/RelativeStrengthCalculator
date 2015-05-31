// --------------------------------
// <copyright file="ImageSample.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/30/2015</date>
// ---------------------------------

#pragma warning disable 1591
namespace RelativeStrengthCalculator.Api.Areas.HelpPage.SampleGeneration
{
    using System;

    /// <summary>
    /// This represents an image sample on the help page. There's a display template named ImageSample associated with this class.
    /// </summary>
    public class ImageSample
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageSample"/> class.
        /// </summary>
        /// <param name="src">The URL of an image.</param>
        public ImageSample(string src)
        {
            if (src == null)
            {
                throw new ArgumentNullException(nameof(src));
            }

            this.Src = src;
        }

        public string Src { get; }

        public override bool Equals(object obj)
        {
            ImageSample other = obj as ImageSample;
            return other != null && this.Src == other.Src;
        }

        public override int GetHashCode() => this.Src.GetHashCode();

        public override string ToString() => this.Src;
    }
}