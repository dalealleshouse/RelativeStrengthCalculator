namespace RelativeStrengthCalculator
{
    using System.ComponentModel;

    public enum Sex
    {
        Invalid = 0,

        [Description("M")]
        Male = 1,

        [Description("F")]
        Female = 2
    }
}