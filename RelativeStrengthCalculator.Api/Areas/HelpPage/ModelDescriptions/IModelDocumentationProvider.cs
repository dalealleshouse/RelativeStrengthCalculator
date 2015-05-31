// --------------------------------
// <copyright file="IModelDocumentationProvider.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/30/2015</date>
// ---------------------------------

#pragma warning disable 1591
namespace RelativeStrengthCalculator.Api.Areas.HelpPage.ModelDescriptions
{
    using System;
    using System.Reflection;

    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}