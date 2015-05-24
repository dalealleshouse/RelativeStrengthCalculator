namespace RelativeStrengthCalculator
{
    using System.Globalization;

    using Dea.Utilities.Reflection;

    using WeightConverter;

    public class RelativeStrengthCalculatorFactory : IRelativeStrengthCalculatorFactory
    {
        private readonly IWeightConverterService _weightConverterService;

        private readonly ITypeLoader<RelativeStrengthCalculator> _typeLoader;

        public RelativeStrengthCalculatorFactory(IWeightConverterService weightConverterService, ITypeLoader<RelativeStrengthCalculator> typeLoader)
        {
            this._weightConverterService = weightConverterService;
            this._typeLoader = typeLoader;
        }

        public RelativeStrengthCalculator Build(CalculatorType calculatorType)
        {
            var name = string.Format(CultureInfo.InvariantCulture, "{0}Calculator", calculatorType);
            var calc = this._typeLoader.LoadType(name, this._weightConverterService);
            return calc;
        }
    }
}