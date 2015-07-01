module RelativeStrengthCalculator {
    export interface IRelativeStrengthService {
        baseUrl: string;
        buildRequestUrl: (formula: number|string, weightUnits: number|string) => string;
        metaData: () => IRelativeStrengthMetaData;
        results: (formula: string|number, weightUnits: string|number, requests: Array<ICalculatorRequest>) => ICalculatorResults;
    }

    export class RelativeStrengthService implements IRelativeStrengthService {
        static id = 'relativeStrengthService';

        /*@ngInject*/
        constructor(private $q: ng.IQService, private $http: ng.IHttpService) {}

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
            var promise = this.$q.defer();

            var metaData: IRelativeStrengthMetaData = {
                formulas: {},
                weightUnits: {},
                sexes: {},
                $promise: promise.promise
            };

            this.$q.all([
                this.$http.get(`${this.baseUrl}api/metadata/formulas`),
                this.$http.get(`${this.baseUrl}api/metadata/weightUnits`),
                this.$http.get(`${this.baseUrl}api/metadata/sexes`)
            ]).then((data: any[]) => {
                metaData.formulas = data[0].data;
                metaData.weightUnits = data[1].data;
                metaData.sexes = data[2].data;
                promise.resolve(metaData);
            }).catch((err: any) => {
                promise.reject(err);
            });

            return metaData;
        }

        results(formula: string | number, weightUnits: string | number, requests: ICalculatorRequest[]): ICalculatorResults {
            var promise = this.$q.defer();

            var results: any = [];

            results.$promise = this.$http.post(this.buildRequestUrl(formula, weightUnits), requests);

            results.$promise.then((data: any) => {
                angular.copy(data.data, results);
                promise.resolve(results);
            }).catch((err: any) => {
                promise.reject(err);
            });

            return results;
        }
    }

    angular.module(appName).service(RelativeStrengthService.id, RelativeStrengthService);
}
