namespace RelativeStrengthCalculator.Tests.WeightConverterService
{
    using DotNetTestHelper;

    using WeightConverter;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public abstract class WeightConverterServiceTestBase
    {
        protected WeightConverterService Sut { get; private set; }

        [TestInitialize]
        public void Init()
        {
            this.Sut = new SutBuilder<WeightConverterService>().Build();
        }
    }
}