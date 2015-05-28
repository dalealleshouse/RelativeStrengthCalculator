// --------------------------------
// <copyright file="CalculatorTestBase.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/27/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator.Tests.Helpers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CalculatorTestBase
    {
        public TestContext TestContext { get; set; }

        protected CalculatorTestCase GetTestCase()
            =>
                new CalculatorTestCase
                    {
                        Sex = (Sex)int.Parse(this.TestContext.DataRow["Sex"].ToString()),
                        Weight = decimal.Parse(this.TestContext.DataRow["Weight"].ToString()),
                        Total = decimal.Parse(this.TestContext.DataRow["Total"].ToString()),
                        Coefficient = decimal.Parse(this.TestContext.DataRow["Coefficient"].ToString()),
                        Score = decimal.Parse(this.TestContext.DataRow["Score"].ToString())
                    }

                ;
    }
}