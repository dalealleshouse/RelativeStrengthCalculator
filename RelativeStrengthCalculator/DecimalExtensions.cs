namespace RelativeStrengthCalculator
{
    using System;

    public static class DecimalExtensions
    {
        public static decimal Power(this decimal num, int raiseToThePowerOf)
        {
            if (raiseToThePowerOf == 0)
            {
                return 1;
            }

            var temp = num;

            for (var i = 0; i < Math.Abs(raiseToThePowerOf) - 1; i++)
            {
                temp = temp * num;
            }

            return raiseToThePowerOf < 0 ? 1 / temp : temp;
        }
    }
}