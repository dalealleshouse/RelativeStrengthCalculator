namespace RelativeStrengthCalculator.WeightConverter
{
    public interface IWeightConverterService
    {
        decimal ToPounds(decimal kilograms);

        decimal ToKilogram(decimal pounds);
    }
}