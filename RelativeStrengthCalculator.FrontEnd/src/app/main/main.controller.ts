module RelativeStrengthCalculator {
    'use strict';

    export class MainController {
        static id = 'MainController';

        loading = true;
        metaData: IRelativeStrengthMetaData = null;
        weightUnits = 1;
        formula = 1;

        /*@ngInject*/
        constructor(private relativeStrengthService: IRelativeStrengthService, private calculationInputParser: ICalculationInputParser) {
            this.metaData = relativeStrengthService.metaData();

            this.metaData.$promise.finally(() => {
                this.loading = false;
            });
        }

        calc(calcs) {
            var requests = this.calculationInputParser.parse(calcs);
            var results = this.relativeStrengthService.results(this.formula, this.weightUnits, requests);

            results.$promise.then((data) => {
                console.log(results);
            });
        }
    }

    angular.module(appName).controller(MainController.id, MainController);
}
