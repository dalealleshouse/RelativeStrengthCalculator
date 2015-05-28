// --------------------------------
// <copyright file="WeightConverterServiceTestBase.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/24/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator.Tests.WeightConverterService
{
    using DotNetTestHelper;

    using global::RelativeStrengthCalculator.WeightConverter;

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