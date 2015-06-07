module RelativeStrengthCalculator {
    export interface ICalculatorResults extends Array<ICalculatorResult> {
        $promise: ng.IPromise<ICalculatorResults>;
    }
}
