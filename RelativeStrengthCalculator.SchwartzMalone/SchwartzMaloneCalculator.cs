namespace RelativeStrengthCalculator.SchwartzMalone
{
    using System;

    using WeightConverter;

    public class SchwartzMaloneCalculator : RelativeStrengthCalculator
    {
        public SchwartzMaloneCalculator(IWeightConverterService weightConverterService)
            : base(weightConverterService)
        {
        }

        public override CalculatorType CalculatorType => CalculatorType.SchwartzMalone;

        public override decimal Coefficient(Sex sex, decimal bodyWeightInPounds)
        {
            var table = SchwartzMaloneLookUpTable.GetLookupTable(sex);
            var kiloWeight = this.WeightConverterService.ToKilogram(bodyWeightInPounds);
            var weight = (double)Math.Round(kiloWeight, 1);

            return !table.ContainsKey(weight) ? 0 : table[weight];
        }

        public override decimal AdjustedTotal(Sex sex, decimal bodyWeightInPounds, decimal totalInPounds)
        {
            var coefficient = this.Coefficient(sex, bodyWeightInPounds);
            return coefficient * totalInPounds;
        }
    }
}