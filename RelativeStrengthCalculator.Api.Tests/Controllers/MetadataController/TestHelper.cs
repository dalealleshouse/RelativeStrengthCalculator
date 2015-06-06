// --------------------------------
// <copyright file="TestHelper.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>06/06/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator.Api.Tests.Controllers.MetadataController
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Web.Http.Results;

    using global::RelativeStrengthCalculator.Api.Controllers;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public static class TestHelper
    {
        public static MetadataController BuildSut() => new MetadataController();

        public static void TestEnumResult(IHttpActionResult result, Type enumType)
        {
            var typedResult = result as OkNegotiatedContentResult<IDictionary<int, string>>;
            Assert.IsNotNull(typedResult);
            Assert.AreEqual(Enum.GetValues(enumType).Length - 1, typedResult.Content.Count);
        }
    }
}