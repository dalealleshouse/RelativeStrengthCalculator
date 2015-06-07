module RelativeStrengthCalculator {
    export interface IRelativeStrengthMetaData {
        formulas: { [path: number]: string; };
        weightUnits: { [path: number]: string; };
        sexes: { [path: number]: string; };
        $promise: ng.IPromise<IRelativeStrengthMetaData>;
    }
}
