//  --------------------------------
//  <copyright file="WilksCalculatorFactory.cs">
//      Copyright (c) 2014 All rights reserved.
//  </copyright>
//  <author>Alleshouse, Dale</author>
//  <date>08/09/2014</date>
//  ---------------------------------
namespace RelativeStrengthCalculator.Wilks.Tests.WilksCalculator
{
    internal class WilksCalculatorFactory
    {
        public WilksCalculator Build()
        {
            var sut = new WilksCalculator(new WeightConverterService());
            return sut;
        }
    }
}