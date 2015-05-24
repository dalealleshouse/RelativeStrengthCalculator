namespace RelativeStrengthCalculator
{
    using System;

    using WeightConverter;

    public abstract class RelativeStrengthCalculator
    {
        protected RelativeStrengthCalculator(IWeightConverterService weightConverterService)
        {
            if (weightConverterService == null)
            {
                throw new ArgumentNullException(nameof(weightConverterService));
            }

            WeightConverterService = weightConverterService;
        }

        public abstract CalculatorType CalculatorType { get; }

        protected IWeightConverterService WeightConverterService { get; }

        public abstract decimal Coefficient(Sex sex, decimal bodyWeightInPounds);

        public abstract decimal AdjustedTotal(Sex sex, decimal bodyWeightInPounds, decimal totalInPounds);
    }
}