namespace RelativeStrengthCalculator.Tests.DecimalExtensions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PowerShould
    {
        [TestMethod]
        public void TakeADecimalToAPower()
        {
            var sut = new decimal(5);

            Assert.AreEqual(5, sut.Power(1));
            Assert.AreEqual(25, sut.Power(2));
            Assert.AreEqual(3125, sut.Power(5));
            Assert.AreEqual(0.008m, sut.Power(-3));
        }
    }
}