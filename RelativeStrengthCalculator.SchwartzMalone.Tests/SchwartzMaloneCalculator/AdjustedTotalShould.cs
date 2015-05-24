namespace RelativeStrengthCalculator.SchwartzMalone.Tests.SchwartzMaloneCalculator
{
    using System.Diagnostics;

    using DotNetTestHelper;

    using WeightConverter;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SchwartzMaloneCalculator = SchwartzMalone.SchwartzMaloneCalculator;

    [TestClass]
    public class AdjustedTotalShould
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DeploymentItem("RelativeStrength\\SchwartzMaloneCalculator\\CoefficientTestData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\CoefficientTestData.xml", "Row", DataAccessMethod.Sequential)]
        public void GenerateCorrectCoefficient()
        {
            var sex = (Sex)int.Parse(this.TestContext.DataRow["Sex"].ToString());
            var weight = decimal.Parse(this.TestContext.DataRow["Weight"].ToString());
            var total = decimal.Parse(this.TestContext.DataRow["Total"].ToString());
            var expected = decimal.Parse(this.TestContext.DataRow["Score"].ToString());
            var coefficient = decimal.Parse(this.TestContext.DataRow["Coefficient"].ToString());

            Debug.WriteLine(sex);
            Debug.WriteLine(weight);
            Debug.WriteLine(total);
            Debug.WriteLine(coefficient);

            var sut = new SutBuilder<SchwartzMaloneCalculator>().AddDependency(new WeightConverterService()).Build();

            var result = sut.AdjustedTotal(sex, weight, total);
            Assert.AreEqual(expected, result);
        }
    }
}