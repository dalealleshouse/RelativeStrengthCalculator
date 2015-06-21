module RelativeStrengthCalculator {
    'use strict';

    export class MockRelativeStrengthService implements IRelativeStrengthService {
        static id = 'relativeStrengthService';

        /*@ngInject*/
        constructor(private $q: ng.IQService) {}

        get baseUrl(): string {
            return 'http://rscalc.azurewebsites.net/';
        }

        buildRequestUrl(formula: number|string, weightUnits: number|string): string {
            if (!formula) {
                throw new Error('formula is falesy');
            }

            if (!weightUnits) {
                throw new Error('weightUnits is falesy');
            }

            return `${this.baseUrl}${formula}/${weightUnits}`;
        }

        metaData(): IRelativeStrengthMetaData {
            var metaData: IRelativeStrengthMetaData = {
                formulas: {},
                weightUnits: {},
                sexes: {},
                $promise: null
            };

            metaData.$promise = this.$q.when(metaData);

            return metaData;
        }

        results(formula: string | number, weightUnits: string | number, requests: ICalculatorRequest[]): ICalculatorResults {
            var results: any = [];

            results.$promise = this.$q.when(results);

            return results;
        }
    }
}
