// --------------------------------
// <copyright file="GetFormulasShould.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>06/06/2015</date>
// ---------------------------------
namespace RelativeStrengthCalculator.Api.Tests.Controllers.MetadataController
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetFormulasShould
    {
        [TestMethod]
        public void ReturnFormulas()
        {
            var sut = TestHelper.BuildSut();

            var result = sut.GetFormulas();

            TestHelper.TestEnumResult(result, typeof(Formula));
        }
    }
}