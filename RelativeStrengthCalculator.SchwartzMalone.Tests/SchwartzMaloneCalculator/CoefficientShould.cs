namespace RelativeStrengthCalculator.SchwartzMalone.Tests.SchwartzMaloneCalculator
{
    using System.Diagnostics;

    using DotNetTestHelper;

    using WeightConverter;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SchwartzMaloneCalculator = SchwartzMalone.SchwartzMaloneCalculator;

    [TestClass]
    public class CoefficientShould
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DeploymentItem("SchwartzMaloneCalculator\\CoefficientTestData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\CoefficientTestData.xml", "Row", DataAccessMethod.Sequential)]
        public void GenerateCorrectCoefficient()
        {
            var sex = (Sex)int.Parse(this.TestContext.DataRow["Sex"].ToString());
            var weight = decimal.Parse(this.TestContext.DataRow["Weight"].ToString());
            var expected = decimal.Parse(this.TestContext.DataRow["Coefficient"].ToString());

            Debug.WriteLine(sex);
            Debug.WriteLine(weight);
            Debug.WriteLine(expected);

            var sut = new SutBuilder<SchwartzMaloneCalculator>().AddDependency(new WeightConverterService()).Build();

            var result = sut.Coefficient(sex, weight);
            Assert.AreEqual(expected, result);
        }
    }
}