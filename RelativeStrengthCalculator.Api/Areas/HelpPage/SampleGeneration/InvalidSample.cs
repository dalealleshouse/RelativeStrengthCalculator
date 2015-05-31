// --------------------------------
// <copyright file="InvalidSample.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/30/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator.Api.Areas.HelpPage
{
    using System;

    /// <summary>
    /// This represents an invalid sample on the help page. There's a display template named InvalidSample associated with this class.
    /// </summary>
    public class InvalidSample
    {
        public InvalidSample(string errorMessage)
        {
            if (errorMessage == null)
            {
                throw new ArgumentNullException(nameof(errorMessage));
            }
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }

        public override bool Equals(object obj)
        {
            InvalidSample other = obj as InvalidSample;
            return other != null && ErrorMessage == other.ErrorMessage;
        }

        public override int GetHashCode() => ErrorMessage.GetHashCode();

        public override string ToString() => ErrorMessage;
    }
}