module RelativeStrengthCalculator {
    enum Sex {
        Male = 1,
        Female = 2
    }

    function sexFilter(input: number) {
        return Sex[input];
    }

    angular.module(appName).filter('sex', () => sexFilter);
}