// --------------------------------
// <copyright file="GetSexesShould.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>06/06/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator.Api.Tests.Controllers.MetadataController
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetSexesShould
    {
        [TestMethod]
        public void ReturnSexes()
        {
            var sut = TestHelper.BuildSut();

            var result = sut.GetSexes();

            TestHelper.TestEnumResult(result, typeof(Sex));
        }
    }
}