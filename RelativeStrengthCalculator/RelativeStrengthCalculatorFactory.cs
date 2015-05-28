// --------------------------------
// <copyright file="RelativeStrengthCalculatorFactory.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/24/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator
{
    using Dea.Utilities.Reflection;

    using global::RelativeStrengthCalculator.WeightConverter;

    public class RelativeStrengthCalculatorFactory : IRelativeStrengthCalculatorFactory
    {
        private readonly ITypeLoader<RelativeStrengthCalculator> _typeLoader;

        private readonly IWeightConverterService _weightConverterService;

        public RelativeStrengthCalculatorFactory(IWeightConverterService weightConverterService, ITypeLoader<RelativeStrengthCalculator> typeLoader)
        {
            this._weightConverterService = weightConverterService;
            this._typeLoader = typeLoader;
        }

        public RelativeStrengthCalculator Build(CalculatorType calculatorType)
        {
            var name = $"{calculatorType}Calculator";
            var calc = this._typeLoader.LoadType(name, this._weightConverterService);
            return calc;
        }
    }
}