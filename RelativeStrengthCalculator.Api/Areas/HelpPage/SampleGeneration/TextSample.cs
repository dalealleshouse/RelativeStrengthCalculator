// --------------------------------
// <copyright file="TextSample.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/30/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator.Api.Areas.HelpPage.SampleGeneration
{
    using System;

    /// <summary>
    /// This represents a preformatted text sample on the help page. There's a display template named TextSample associated with this class.
    /// </summary>
    public class TextSample
    {
        public TextSample(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            this.Text = text;
        }

        public string Text { get; }

        public override bool Equals(object obj)
        {
            TextSample other = obj as TextSample;
            return other != null && this.Text == other.Text;
        }

        public override int GetHashCode() => this.Text.GetHashCode();

        public override string ToString() => this.Text;
    }
}