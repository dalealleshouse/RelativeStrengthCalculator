module RelativeStrengthCalculator {
    'use strict';

    export class MainController {
        static id = 'MainController';

        loading = true;
        metaData: IRelativeStrengthMetaData = null;
        weightUnits = 1;
        formula = 1;
        results: ICalculatorResults;

        /*@ngInject*/
        constructor(private relativeStrengthService: IRelativeStrengthService, private calculationInputParser: ICalculationInputParser) {
            this.metaData = relativeStrengthService.metaData();

            this.metaData.$promise.finally(() => {
                this.loading = false;
            });
        }

        calc(calcs: string) {
            var requests = this.calculationInputParser.parse(calcs);
            this.results = this.relativeStrengthService.results(this.formula, this.weightUnits, requests);
        }
    }

    angular.module(appName).controller(MainController.id, MainController);
}
