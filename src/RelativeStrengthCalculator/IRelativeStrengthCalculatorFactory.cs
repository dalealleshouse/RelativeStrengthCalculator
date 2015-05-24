namespace RelativeStrengthCalculator
{
    public interface IRelativeStrengthCalculatorFactory
    {
        RelativeStrengthCalculator Build(CalculatorType calculatorType);
    }
}